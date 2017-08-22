using System;
using System.Collections.Generic;
using System.Reflection;
using lxnet;

public partial class NetworkMgr
{
	////////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////////

	/**
	 * http请求成功的回调函数指针
	 * */
	public delegate void HttpSucceedFunc(string url, byte[] userdata, string cookie);

	/**
	 * http请求失败的回调函数指针
	 * */
	public delegate void HttpFailedFunc(string url, int httpcode);


	/**
	 * 定义处理消息的函数指针
	 * */
	public delegate void ProcessMsgFunc(Msg msg);







	////////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////////

	/**
	 * rpc 对象
	 * */
	public class RpcMapObj
	{
		/**
		 * rpc 请求消息表
		 * 			请求消息号 => 回应消息号
		 * */
		public Dictionary<int, int> request = new Dictionary<int, int> ();

		/**
		 * rpc 回应消息号
		 * 消息号 => true
		 * */
		public Dictionary<int, bool> response = new Dictionary<int, bool> ();
	}



	////////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////////


	/** 初始化标记 */
	private static bool _isinit = false;

	/** socket网络对象 */
	private static SocketNet _socket_net = new SocketNet();

	/** 函数表 */
	private static Dictionary<string, Action<object>> _funclist = null;

	/** 消息处理表 */
	private static Dictionary<int, ProcessMsgFunc> _msg_handler = new Dictionary<int, ProcessMsgFunc>();

	/** rpc消息表 */
	private static RpcMapObj _rpc_maping = new RpcMapObj ();

	/** 帧计数 */
	private static int _frame_count = 0;

	public static SocketNet Socketer
	{
		get
		{
			return _socket_net;
		}
	}



	public NetworkMgr ()
	{
	}

	~NetworkMgr()
	{
	}

	/**
	 * 初始化，设置事件函数表
	 * @param {table} event_funclist 事件函数表
	 * 需要定义的函数表如下：

		--当连接断开时
		on_disconnect()

		--当正在连接服务器时
		on_connecting_to_server()

		--网络连接错误或服务器未开启
		on_connect_error_or_server_not_open()

		--当连接到服务器时
		on_connected_to_server()

		--正在认证时
		--@param {boolean} short_link 是否为短链接认证？
		on_authing_as_server(short_link)

		--认证成功时
		--@param {boolean} short_link 是否为短链接认证？
		on_auth_succeed(short_link)

		--认证失败时
		on_auth_failed()

		--版本不匹配时
		on_version_not_match()

		--系统忙，请稍后再试
		on_system_busy()

		--请重新进行web登录流程(短链接认证无法进行)
		on_need_restart_do_web_auth()

		--渠道错误
		on_channel_error()

		--账号在别处登录
		on_account_in_other_local_login()

		--当发送RPC请求时
		on_rpc_request()

		--当收到rpc回应时
		on_rpc_response()

	 * @param {boolean} is_tcp 是否为tcp，为true为tcp，为false为udp，默认为true
	 */
	public static void Init(Dictionary<string, Action<object>> event_funclist, 
																	bool is_tcp = true)
	{
		if (_isinit)
			return;

		// 初始化服务器时间模块
		ServerTime.Init ();

		// 初始化网络
		bool res = lxnet_manager.Init (512, 1, 1024 * 16, 64, 2, 8);
		if (res)
		{
		}

		// 初始化socket网络对象
		_funclist = event_funclist;
		_socket_net.Init (_funclist, _rpc_maping, is_tcp);

		init_msg_handler ();
		_isinit = true;
	}

	/**
	 * 注册rpc消息
	 */
	/*
	public static void RegisterRPC()
	{
		/**
		 请求：MSG_RPC_XXX_REQ
		 回应：MSG_RPC_XXX_RES
		 */
	/*

		string end_req = "_REQ";
		int end_req_len = end_req.Length;
		string end_res = "_RES";
		int end_res_len = end_res.Length;

		string name_before = "MSG_RPC_";
		int name_before_len = name_before.Length;

		int n_len;
		string tmpname = "";


		Opcode opcode_obj = new Opcode ();
		FieldInfo[] msgtype_table = opcode_obj.GetType ().GetFields ();
		int table_len = msgtype_table.Length;
		for (int i = 0; i < table_len; ++i)
		{
			FieldInfo info = msgtype_table[i];
			string typename = info.Name;
			int msgtype = (int)info.GetValue(opcode_obj);
			if (typename.Substring(0, name_before_len) == name_before)
			{
				// 是rpc消息定义
				n_len = typename.Length;
				if (typename.Substring(n_len - end_req_len) == end_req)
				{
					tmpname = name_before + typename.Substring(name_before_len, n_len - name_before_len - end_req_len) + end_res;

					FieldInfo tmpinfo = opcode_obj.GetType().GetField(tmpname);
					if (tmpinfo == null)
					{
						Loger.LogError("register network rpc failed, not find rpc response:" + tmpname);
						return;
					}

					int res_msgtype = (int)tmpinfo.GetValue(opcode_obj);
					_rpc_maping.response[res_msgtype] = true;
					_rpc_maping.request[msgtype] = res_msgtype;
				}
				else if (typename.Substring(n_len - end_res_len) == end_res)
				{
				}
				else
				{
					Loger.LogError("register network rpc failed, msg name:" + typename + ", msg type:" + msgtype);
				}
			}
		}
	}
	*/

	/**
	 * 注册消息处理函数
	 */
	public static void RegisterProtocol(int msgtype, ProcessMsgFunc func)
	{
		if (_msg_handler.ContainsKey(msgtype))
		{
			Loger.LogError("on register protocol, but msg type already exist, msg type:" + msgtype);
			return;
		}

		_msg_handler [msgtype] = func;
	}

	/**
	 * 设置认证信息
	 * @param {number} accountid 账号id
	 * @param {string} session 认证session
	 */
	public static void SetAuthInfo(Int64 accountid, string session)
	{
		_socket_net.SetAuthInfo (accountid, session);
	}

	/**
	 * 设置ping间隔
	 * @param {number} interval 间隔，单位：毫秒
	 */
	public static void SetPingInterval(int interval)
	{
		_socket_net.SetPingInterval(interval);
	}

	/**
	 * 获取延时
	 * @return {number}
	 */
	public static int GetPingDelay()
	{
		return _socket_net.GetPingDelay();
	}

	/**
	 * 发送消息到服务器
	 * @param {Message} msg 消息对象
	 */
	public static void SendMsgToServer(Msg msg)
	{
		on_send_msg (msg.GetMsgType ());
		_socket_net.SendMsg (msg);
	}

	/**
	 * 初始化socket网络
	 * @param {string} ip ip地址
	 * @param {number} port 端口
	 */
	public static void InitSocketNet(string ip, int port)
	{
		_socket_net.Connect (ip, port);
	}

	/**
	 * 重连
	 */
	public static void Reconnect()
	{
		_socket_net.Reconnect ();
	}

	/**
	 * 断开网络连接
	 */
	public static void Disconnect()
	{
		_socket_net.Disconnect ();
	}

	public static void Run(long currenttime)
	{
		_frame_count++;
		if (_frame_count < 0)
			_frame_count = 0;

		if (_frame_count % 3 == 0)
			HttpReqMgr.Run ();

		if (_frame_count % 200 == 0)
			lxnet_manager.Run ();

		_socket_net.RunOnce (currenttime);
	}

	public static void OnPause()
	{
		_socket_net.OnPause ();
	}

	public static void OnResume()
	{
		_socket_net.OnResume ();
	}

	public static void OnExit()
	{
		_socket_net.OnExit ();
	}



	////////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////////

	private static void on_send_msg(int msgtype)
	{
		if (!_rpc_maping.request.ContainsKey(msgtype))
		{
			Loger.Log(msgtype + " ---->");
		}
	}

	public static void on_process_msg(Msg msg)
	{
		int msgtype = msg.GetMsgType ();
		if (!_rpc_maping.response.ContainsKey(msgtype))
		{
			Loger.Log("           <---- " + msgtype);
		}

		if (_msg_handler.ContainsKey(msgtype))
		{
			ProcessMsgFunc func = _msg_handler [msgtype];
			if (func != null)
				func (msg);
		}
		else
		{
			Loger.LogError ("unknow from server msg type:" + msgtype);
		}
	}

	private static void on_server_update_time(Msg msg)
	{
		Int64 now_utctime = msg.GetInt64 ();
		ServerTime.UpdateServerTime (now_utctime);
	}

	private static void init_msg_handler()
	{
//		_msg_handler [const_network.OPCODE_S2C_SYNC_SERVER_TIMESTAMP] = on_server_update_time;
	}

}
