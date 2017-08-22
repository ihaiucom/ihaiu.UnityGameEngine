using System.IO;
using Games.PB;

namespace lxnet
{
	using System;
	using System.Collections.Generic;

	public partial class SocketNet
	{

		/** 注册登录验证协议监听 */
		private void RegisterAuthorizationProto()
		{

			/** 服务器：响应客户端登录验证结果 */
			AddCallback<ResponseLoginAuthorizationResult> (const_network.OPCODE_AUTH_S2C_AUTH_RESULT, OnResponseLoginAuthorizationResult);


			/** 服务器：通知客户端重新连接新网关 */
			AddCallback<NotifyClientConnectToNewGateway> (const_network.OPCODE_AUTH_S2C_CLIENT_CONNECT_TO_NEW_GATEWAY, OnNotifyClientConnectToNewGateway);


			/** 服务器：通知客户端账号在别处登录 */
			AddCallback<NotifyClientAccountDuplicateLogin> (const_network.OPCODE_AUTH_S2C_CENTER_NOTIFY_CLIENT_ACCOUNT_DUPLICATE_LOGIN, OnNotifyClientAccountDuplicateLogin);


			/** 服务器：同步随机因子到客户端 */
			AddCallback<SyncRandomFactor> (const_network.OPCODE_S2C_SYNC_RANDOM_FACTOR, OnSyncRandomFactor);

			/** 服务器：同步服务器时间到客户端 */
			AddCallback<SyncServerTimestamp> (const_network.OPCODE_S2C_SYNC_SERVER_TIMESTAMP, OnSyncServerTimestamp);
		}



		/** 服务器：响应客户端登录验证结果 */
		private void OnResponseLoginAuthorizationResult(int id, ResponseLoginAuthorizationResult msg)
		{
			uint res = msg.error_code;
			if (res == const_network.enum_auth_succeed)
			{
				/** 认证成功 */
				string auth_string = msg.authorization_str;
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


		/** 服务器：通知客户端重新连接新网关 */
		private void OnNotifyClientConnectToNewGateway(int id, NotifyClientConnectToNewGateway msg)
		{
			_ip 	= msg.ip;
			_port 	= (int) msg.port;

			reset_connect();

		}


		/** 服务器：通知客户端账号在别处登录 */
		private void OnNotifyClientAccountDuplicateLogin(int id, NotifyClientAccountDuplicateLogin msg)
		{
			close_connect();
			_funclist["on_account_in_other_local_login"](null);
		}


		/** 服务器：同步随机因子到客户端 */
		private void OnSyncRandomFactor(int id, SyncRandomFactor msg)
		{

			/** 变更状态为连接上 */
			_state = enum_state_connected;
			_funclist["on_connected_to_server"](null);

			/** 记录服务器随机因子 */
			string now_S = msg.random_factor;

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


		/** 服务器：同步服务器时间到客户端 */
		private void OnSyncServerTimestamp(SyncServerTimestamp msg)
		{
			ServerTime.UpdateServerTime ((Int64)msg.timestamp);
		}





	}


}
