namespace lxnet
{
	public class const_network
	{
		/* 认证结果枚举 */
		////////////////////////////////////////////////////////////////////////////////////////////////


		/// 认证成功
		public const int enum_auth_succeed = 0;

		/// 认证失败
		public const int enum_auth_failed = 1;

		/// 版本不匹配
		public const int enum_auth_version_not_eq = 2;

		/// 系统繁忙
		public const int enum_auth_system_busy = 3;

		/// 请重新进行登录流程(短链接认证无法进行)
		public const int enum_auth_need_restart_login_process = 4;

		// 渠道错误
		public const int enum_auth_channel_error = 5;




		/* 核心消息类型 */
		////////////////////////////////////////////////////////////////////////////////////////////////
//		public const int OPCODE_AUTH_S2C_SYNC_SERVER_TIME = 1001;				//服务器：告知客户端当前服务器utc时间，单位：秒
//		public const int OPCODE_AUTH_S2C_CLIENT_CONNECT_TO_NEW_GATEWAY = 1002;						//服务器：告知客户端连接指定的网关
//		public const int OPCODE_AUTH_S2C_SYNC_RANDOM_FACTOR = 1003;				//服务器：告知客户端随机因子，准备认证
//		public const int OPCODE_AUTH_C2S_FIRST_AUTH_RESULT = 1004;							//客户端：请求进行首次认证
//		public const int OPCODE_AUTH_C2S_RECONNECT_ON_LOSS_AND_AUTH = 1005;					//客户端：请求进行短链接认证
//		public const int OPCODE_AUTH_S2C_AUTH_RESULT = 1006;				//服务器：告知客户端认证结果
//		public const int MSG_TELL_CLIENT_SHORT_LINK_READY = 1007;			//服务器：告知客户端已经为短链接准备好
//
//
//		public const int OPCODE_AUTH_S2C_ACCOUNT_DUPLICATE_LOGIN = 1051;		//服务器：告知客户端此账号在别处登录

		
		/** 客户端请求: 首次登录认证 */
		public const int OPCODE_AUTH_C2S_FIRST_AUTH_RESULT = 10000;	
		
		/** 客户端请求: 客户端断线重连 */
		public const int OPCODE_AUTH_C2S_RECONNECT_ON_LOSS_AND_AUTH = 10001;	
		
		/** 服务器：响应客户端登录验证结果 */
		public const int OPCODE_AUTH_S2C_AUTH_RESULT = 10002;				
		
		/** 服务器：通知客户端重新连接新网关 */
		public const int OPCODE_AUTH_S2C_CLIENT_CONNECT_TO_NEW_GATEWAY = 10003;						
		
		/** 服务器：同步服务器时间到客户端 */
		public const int OPCODE_AUTH_S2C_SYNC_SERVER_TIME = 10004;				
		
		/** 服务器：同步随机因子到客户端 */
		public const int OPCODE_AUTH_S2C_SYNC_RANDOM_FACTOR = 10005;				
		
		/** 服务器：通知客户端账号在别处登录 */
		public const int OPCODE_AUTH_S2C_ACCOUNT_DUPLICATE_LOGIN = 10006;	
		
		/** 服务器：告知客户端已经为短链接准备好 */
		public const int MSG_TELL_CLIENT_SHORT_LINK_READY = 1007;	


		public const_network ()
		{
		}
	}
}
