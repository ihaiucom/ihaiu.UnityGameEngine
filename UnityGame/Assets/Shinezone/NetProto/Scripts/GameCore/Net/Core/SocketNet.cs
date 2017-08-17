namespace lxnet
{
	using System;
	using System.Collections.Generic;

	public class SocketNet
	{
		public const int enum_state_nil = 0;				//未创建socket
		public const int enum_state_create = 1;			//已经创建socket
		public const int enum_state_connecting = 2;		//正在连接
		public const int enum_state_connected = 3;			//连接成功
		public const int enum_state_authing = 4;			//正在认证
		public const int enum_state_authsucceed = 5;		//认证成功



		////////////////////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////////////////////////////////

		/** 初始化标记 */
		private bool _isinit = false;

		/** 心跳间隔，单位：毫秒 */
		private int _ping_delay = 15000;

		/** 当前测得的ping延时，单位：毫秒 */
		private int _state_ping_delay = 0;

		/** 连接超时值，单位：毫秒 */
		private int _connect_timeout_max = 30000;

		/** 当前时间 */
		private Int64 _current_time = 0;

		/** 服务器ip */
		private string _ip = "";

		/** 服务器端口 */
		private int _port = 0;

		/** 是否为tcp */
		private bool _is_tcp = true;

		/** socket对象 */
		private Socketer _con = null;

		/** 是否需要连接 */
		private bool _need_connect = false;

		/** 上一次ping的时间 */
		private Int64 _last_pingtime = 0;

		/** 连接状态 */
		private int _state = 0;

		/** 尝试连接的时间，用来判断间隔多久还未连接成功时，认为服务器未开启 */
		private Int64 _try_connecttime = 0;

		/** --消息处理表 */
		private Dictionary<int, NetworkMgr.ProcessMsgFunc> _msg_handler = new Dictionary<int, NetworkMgr.ProcessMsgFunc>();

		/** 函数表 */
		private Dictionary<string, Action<object>> _funclist = null;


		/** 账号id */
		private Int64 _accountid = 0;

		/** 是否为短链接认证？ */
		private bool _is_short_link = false;


		/** 认证对象 */
		private AuthObj _auth_obj = new AuthObj();

		
		public int State { get{ return _state;} }
		public bool Isinit { get{ return _isinit;} }

		////////////////////////////////////////////////////////////////////////////////////////////////
		/**
		 * 当前rpc请求(同时只能存在一个请求)
		 * */

		/** 等待回应 */
		private bool _now_request_waiting = false;

		/** 消息 */
		private Msg _now_request_msg = null;


		/** rpc消息表(参见NetworkMgr单例) */
		private NetworkMgr.RpcMapObj _rpc_maping = null;


		////////////////////////////////////////////////////////////////////////////////////////////////




		public SocketNet()
		{
			init_msg_handler ();
		}

		~SocketNet()
		{
		}

		/**
		 * 初始化，设置相关回调函数
		 * @param {table} funclist 函数表
		 * @param {table} rpc_maping rpc映射表
		 * @param {boolean} is_tcp 是否为tcp，为true为tcp，为false为udp
		 * */
		public void Init(Dictionary<string, Action<object>> funclist, 
											NetworkMgr.RpcMapObj rpc_maping, bool is_tcp)
		{
			if (_isinit)
				return;

			_funclist = funclist;
			_rpc_maping = rpc_maping;
			_is_tcp = is_tcp;
			_isinit = true;
		}

		/** 连接指定服务器
		 * @param {string} ip ip地址
		 * @param {number} port 端口
		 * */
		public void Connect(string ip, int port)
		{
			_ip = ip;
			_port = port;
			_need_connect = true;
			reset_connect ();
			_funclist ["on_connecting_to_server"] (null);
		}

		/** 重连(当前有短链接，故只是重置下) */
		public void Reconnect()
		{
			reset_connect ();
		}

		/** 断开连接 */
		public void Disconnect()
		{
			if (_con != null)
			{
				_con = null;
			}

			_con = null;
			_need_connect = false;
			_state = enum_state_nil;

			reset_auth_obj();
		}

		/**
		 * 设置认证信息
		 * @param {number} accountid 账号id
		 * @param {string} session 认证session
		 * */
		public void SetAuthInfo(Int64 accountid, string session)
		{
			reset_auth_obj ();
			_accountid = accountid;
			_auth_obj.from_web_M = session;
		}

		/**
		 * 设置ping间隔
		 * @param {number} interval 间隔，单位：毫秒
		 */
		public void SetPingInterval(int interval)
		{
			if (interval <= 0)
				interval = 500;

			_ping_delay = interval;
		}

		/**
		 * 获取延时
		 * @return {number}
		 */
		public int GetPingDelay()
		{
			return _state_ping_delay;
		}

		/**
		 * 发送消息
		 * @param {Message} msg 消息对象
		 * */
		public void SendMsg(Msg msg)
		{
			int msgtype = msg.GetMsgType();

			/* 若新的消息为RPC请求
			 * 则查看当前是否存在未决的rpc请求，若存在，报错
			 * */
			if (_rpc_maping.request.ContainsKey(msgtype))
			{
				if (_now_request_msg != null)
				{
					Loger.LogError("have unfinished RPC request, can not make new RPC request, new request msg type:" + msgtype);
					return;
				}
				else
				{
					_now_request_msg = msg;
					_now_request_waiting = true;
					Loger.Log(msgtype + "  RPC request ---->");

					_funclist["on_rpc_request"](null);
				}
			}

			if (_con != null)
				_con.SendMsg(msg);
		}




		////////////////////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////////////////////////////////
		private void real_run_once(Int64 currenttime)
		{
			_current_time = currenttime;
			if (!_need_connect || _con == null)
				return;

			_con.RunOnce();

			/** 已经创建socket */
			if (_state == enum_state_create) {
				try_connect ();
				return;
			}

			/** 保持心跳 */
			ping ();

			/** 检测是否断开连接 */
			if (_con.IsClose ()) {
				Reconnect ();

				/** 连接断开 */
				_funclist ["on_disconnect"] (null);
				return;
			}

			/** 处理消息 */
			on_try_process_msg ();

			if (_con != null) {
				_con.CheckSend ();
				_con.CheckRecv ();
			}
		}

		/** 每帧run */
		public void RunOnce(Int64 currenttime)
		{
			real_run_once(currenttime);

			if (_con != null)
			{
				_con.RunOnceEnd();
			}
		}

		/** 当程序挂起时 */
		public void OnPause()
		{
		}

		/** 当程序恢复，继续运行时 */
		public void OnResume()
		{
			if (_con == null || _state <= enum_state_create)
				return;

			ping ();
		}

		public void OnExit()
		{
			if (_con != null)
			{
				_con.Release ();
				_con = null;
			}
		}

		/** 重置认证对象 */
		private void reset_auth_obj()
		{
			reset_now_rpc_request ();

			_accountid = 0;

			_auth_obj.reset ();
		}

		private void reset_now_rpc_request()
		{
			_now_request_waiting = false;
			_now_request_msg = null;
		}

		private bool is_waiting_rpc_response()
		{
			return _now_request_waiting;
		}

		private void on_recv_msg(int msgtype)
		{
			if (!_rpc_maping.response.ContainsKey(msgtype))
				return;

			/** 是rpc回应，但是不存在rpc请求，则报错 */
			if (_now_request_msg == null) {
				Loger.LogError ("received the RPC response, but not have RPC request. this response msg type:" + msgtype);
				return;
			}

			/** 不是rpc请求所期望的回应 */
			if (_rpc_maping.request [_now_request_msg.GetMsgType ()] != msgtype) {
				/** 不是所等待的rpc，报错 */
				Loger.LogError ("received the RPC response is not desired, look forward to receiving msg type:" + _now_request_msg.GetMsgType ());
				return;
			}

			/** 是正在等待的rpc回应 */
			_now_request_msg = null;
			_now_request_waiting = false;

			Loger.Log ("           <---- RPC response  " + msgtype);

			_funclist ["on_rpc_response"] (null);
		}

		private void process_msg(int msgtype, Msg msg, NetworkMgr.ProcessMsgFunc msgfunc)
		{
			on_recv_msg (msgtype);
			if (_msg_handler.ContainsKey(msgtype))
			{
				NetworkMgr.ProcessMsgFunc func = _msg_handler [msgtype];
				if (func != null)
					func(msg);
			}
			else
			{
				msgfunc(msg);
			}
		}

		private void on_try_process_msg()
		{
			while (true)
			{
				Msg newmsg = _con.GetMsg ();
				if (newmsg == null)
					break;

				process_msg (newmsg.GetMsgType (), newmsg, NetworkMgr.on_process_msg);
			}
		}

		/** 关闭连接 */
		private void close_connect()
		{
			if (_con != null)
				_con.Close ();
		}

		/** 心跳 */
		private void ping()
		{
			/** 间隔*s */
			if (_current_time - _ping_delay > _last_pingtime)
			{
				Msg msg = new Msg ();
				msg.SetMsgType (1);
				_con.SendMsg (msg);
				_last_pingtime = _current_time;
			}
		}

		/** 尝试连接 */
		private void try_connect()
		{
			if (_con.Connect (_ip, _port))
			{
				Msg msg = new Msg ();
				msg.SetMsgType (1);
				if (_con.SendMsg (msg))
				{
					_last_pingtime = _current_time;
					_con.CheckSend ();
					if (!_con.IsClose ())
						_state = enum_state_connecting;
					else
						reset_connect ();
				}
				else
				{
					reset_connect ();
				}
			}

			/** 尝试连接超时，则认为网络连接错误或服务器未开启 */
			if (_current_time - _try_connecttime > _connect_timeout_max)
			{
				_need_connect = false;

				/** 网络连接错误或服务器未开启 */
				_funclist ["on_connect_error_or_server_not_open"] (null);
				return;
			}
		}

		/** 重置连接 */
		private void reset_connect()
		{
			if (_con != null)
			{
				_con.Close ();
				_con = null;
			}

			_con = new Socketer ();
			_con.CheckInit (_is_tcp);
			if (!_is_tcp)
			{
				_con.SetUdpTimeout(5, 5000, 5000);
			}

			_con.UseMsgSeq (true);
			_con.UseUncompress ();
			_con.UseEncrypt ();
			_con.UseDecrypt ();

			_last_pingtime = 0;
			_state = enum_state_create;
			_try_connecttime = _current_time;
		}

		/** 请求进行首次认证 */
		private void req_first_auth()
		{
			/** 计算session */
			string session = lxnet_manager.Md5Sum (_auth_obj.from_web_M + _auth_obj.now_server_S);

			/** 请求首次认证 */
			Msg msg = new Msg ();
			msg.SetMsgType(const_network.OPCODE_AUTH_C2S_FIRST_AUTH_RESULT);
			msg.PushInt64 (_accountid);
			msg.PushString (session);
			msg.PushString ("phone version");
			msg.PushString ("default_self");
			SendMsg (msg);

			_is_short_link = false;
		}

		/** 请求进行短链接认证 */
		private void req_short_link_auth()
		{
			string session = lxnet_manager.Md5Sum(_auth_obj.now_server_S + _auth_obj.prev_server_S + _auth_obj.first_auth_string + _auth_obj.prev_auth_string);

			session = session.ToLower();

			Msg msg = new Msg ();
			msg.SetMsgType(const_network.OPCODE_AUTH_C2S_RECONNECT_ON_LOSS_AND_AUTH);
			msg.PushInt64(_accountid);
			msg.PushString(session);
			SendMsg (msg);

			_is_short_link = true;
		}

		private void on_ping(Msg msg)
		{
			/// 收到ping回馈
			_state_ping_delay = (int)(_current_time - _last_pingtime) / 2;
		}

		private void on_change_gate(Msg msg)
		{
			_ip = msg.GetString();
			_port = msg.GetInt32();

			reset_connect();
		}

		/** 当收到服务器随机因子时 */
		private void on_rand_factor(Msg msg)
		{
			/** 变更状态为连接上 */
			_state = enum_state_connected;
			_funclist["on_connected_to_server"](null);

			/** 记录服务器随机因子 */
			string now_S = msg.GetString();

			_auth_obj.prev_server_S = _auth_obj.now_server_S;
			_auth_obj.now_server_S = now_S;

			bool need_short_link = (_auth_obj.first_auth_string != "");
			if (need_short_link)
			{
				/** 请求短链接认证 */
				req_short_link_auth();
			}
			else
			{
				/* 请求首次认证 */
				req_first_auth();
			}

			/** 状态变为认证中 */
			_state = enum_state_authing;
			_funclist["on_authing_as_server"](need_short_link);
		}

		private void on_auth_result(Msg msg)
		{
			int res = msg.GetInt8();
			if (res == const_network.enum_auth_succeed)
			{
				/** 认证成功 */
				string auth_string = msg.GetString();
				if (_auth_obj.first_auth_string == "")
				{
					_auth_obj.first_auth_string = auth_string;
				}

				_auth_obj.prev_auth_string = auth_string;

				/**
				 * 注：短链接成功包含短链接认证成功、短链接准备完毕两个阶段，
				 * 两个阶段完毕表示短链接认证成功
				 * */
				if (!_is_short_link)
				{
					/** 首次认证成功 */
					_funclist["on_auth_succeed"](false);
				}

				_state = enum_state_authsucceed;
			}
			else if (res == const_network.enum_auth_failed)
			{
				/** 认证失败 */
				_funclist["on_auth_failed"](null);
			}
			else if (res == const_network.enum_auth_version_not_eq)
			{

				/** 版本不匹配 */
				Disconnect();
				_funclist["on_version_not_match"](null);
			}
			else if (res == const_network.enum_auth_system_busy)
			{
				/** 系统忙 */
				_funclist["on_system_busy"](null);
			}
			else if (res == const_network.enum_auth_need_restart_login_process)
			{
				/** 请重新进行登录流程(短链接认证无法进行) */
				Disconnect();
				_funclist["on_need_restart_do_web_auth"](null);
			}
			else if (res == const_network.enum_auth_channel_error)
			{
				/** 渠道错误 */
				Disconnect();
				_funclist["on_channel_error"](null);
			}
		}

		private void on_short_link_ready(Msg msg)
		{
			/** 此时服务器短链接准备完毕，短链接整个成功 */
			if (_is_short_link)
			{
				_funclist["on_auth_succeed"](true);
			}

			/** 若还存在未完成的rpc请求，则发送 */
			if (_now_request_msg != null)
			{
				_now_request_waiting = true;

				SendMsg(_now_request_msg);
			}
		}

		private void on_account_in_other_local_login(Msg msg)
		{
			close_connect();
			_funclist["on_account_in_other_local_login"](null);
		}

		private void init_msg_handler()
		{
			_msg_handler[1] = on_ping;
			_msg_handler [const_network.OPCODE_AUTH_S2C_CLIENT_CONNECT_TO_NEW_GATEWAY] = on_change_gate;
			_msg_handler [const_network.OPCODE_AUTH_S2C_SYNC_RANDOM_FACTOR] = on_rand_factor;
			_msg_handler [const_network.OPCODE_AUTH_S2C_AUTH_RESULT] = on_auth_result;
			_msg_handler [const_network.MSG_TELL_CLIENT_SHORT_LINK_READY] = on_short_link_ready;
			_msg_handler [const_network.OPCODE_AUTH_S2C_ACCOUNT_DUPLICATE_LOGIN] = on_account_in_other_local_login;
		}
	}

	public class AuthObj
	{
		/** 客户端发往web的随机因子 */
		public string to_web_random_string = "";

		/** 登陆web成功后，web回馈的值M */
		public string from_web_M = "";

		/** 首次认证字符串 */
		public string first_auth_string = "";

		/** 上次认证字符串 */
		public string prev_auth_string = "";

		/** 上次服务器随机因子S */
		public string prev_server_S = "";

		/** 当前服务器随机因子S */
		public string now_server_S = "";


		public void reset()
		{
			to_web_random_string = "";
			from_web_M = "";
			first_auth_string = "";
			prev_auth_string = "";
			prev_server_S = "";
			now_server_S = "";
		}
	}
}
