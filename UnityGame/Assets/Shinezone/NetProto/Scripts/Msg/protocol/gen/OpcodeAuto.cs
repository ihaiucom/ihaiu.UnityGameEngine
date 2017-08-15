// 此协议描述是自动生成的，请勿修改！
namespace MessageProtocol
{
	public class OpcodeAuto
	{


		//服务器：提示一则信息
		public const int MSG_HINT_MESSAGE                                    = 1052;

		//服务器：告知客户端角色列表
		public const int MSG_CHAR_LIST_TO_CLIENT                             = 1053;

		//客户端：请求创建角色
		public const int MSG_REQ_CREATE_CHAR                                 = 1054;

		//服务器：告知客户端增加角色信息到角色列表
		public const int MSG_ADD_CHAR_TO_CHARLIST_CLIENT                     = 1055;

		//客户端：请求删除角色
		public const int MSG_REQ_DELETE_CHAR                                 = 1056;

		//服务器：告知客户端移除指定的角色
		public const int MSG_TELL_DELETE_CHAR                                = 1057;

		//客户端：请求用指定的角色进入游戏
		public const int MSG_REQ_START_GAME_BY_CHAR                          = 1058;

		//服务器：告知客户端当前账号存在正在游戏的角色，目前只能使用此正在角色的游戏进行游戏
		public const int MSG_ACCOUNT_HAS_GAMEING_CHAR_ONLY_USE_IT            = 1059;

		//服务器：告知客户端加载必须数据，等待服务器加载角色详细数据
		public const int MSG_TELL_CLIENT_LOAD_DATA                           = 1060;

		//服务器：告知客户端角色详细数据
		public const int MSG_TELL_CHAR_DATA                                  = 1061;

		//服务器：告知客户端准备加载指定地图以进入(客户端此时加载与详细数据相关的资源，当客户端加载完毕时，向服务器请求进入游戏)
		public const int MSG_TELL_CLIENT_LOAD_MAP                            = 1062;

		//服务器：告知客户端进入游戏
		public const int MSG_TELL_CLIENT_ENTER_GAME                          = 1063;

		//服务器：告知客户端充值成功，充值了X元宝
		public const int MSG_RECHARGE_SUCCEED_ADD_GOLD                       = 1064;

		//申请匹配
		public const int MSG_REQ_START_MATCH                                 = 2034;

		//申请匹配
		public const int MSG_RSP_START_MATCH                                 = 2035;

		//申请匹配
		public const int MSG_NOTIFY_ADD_PLAYER                               = 2037;

		//匹配成功
		public const int MSG_NOTIFY_MATCH_SUCCESS                            = 2039;

		//玩家通知服务器准备就绪
		public const int MSG_REQ_TELL_READY                                  = 2040;

		//玩家通知服务器准备就绪
		public const int MSG_RSP_TELL_READY                                  = 2041;

		//准备战斗
		public const int MSG_NOTIFY_START_BATTLE                             = 2042;

		//玩家通知服务器战斗场景加载完毕
		public const int MSG_REQ_TELL_START_BATTLE_READY                     = 2044;

		//玩家通知服务器准备战斗
		public const int MSG_RSP_TELL_START_BATTLE_READY                     = 2045;

		//匹配成功
		public const int MSG_NOTIFY_ENTER_BATTLE                             = 2047;

		//客户端：告知服务器地图加载完毕，请求进入游戏（此时是告知逻辑服，然后若玩家是第一次在此逻辑服进入游戏，则告知全局，让全局变更相关状态，并由全局发送触发客户端进入游戏的消息；否则逻辑服直接发送触发客户端进入游戏的消息）
		public const int MSG_REQ_ENTER_TO_GAME                               = 3001;

		//服务器：告知客户端增加角色元宝
		public const int MSG_TELL_CLIENT_ADD_GOLD                            = 3002;

		//服务器：告知客户端减少角色元宝
		public const int MSG_TELL_CLIENT_DEC_GOLD                            = 3003;

		//服务器：告知客户端增加角色金钱
		public const int MSG_TELL_CLIENT_ADD_MONEY                           = 3004;

		//服务器：告知客户端减少角色金钱
		public const int MSG_TELL_CLIENT_DEC_MONEY                           = 3005;

		//发送事件帧
		public const int MSG_REQ_FRAME_UPDATE                                = 3050;

		//转发事件帧
		public const int MSG_NOTIFY_FRAME_UPDATE                             = 3051;

		//结束战斗
		public const int MSG_REQ_END_BATTLE                                  = 3052;

		//战斗结束返回包
		public const int MSG_RSP_END_BATTLE                                  = 3053;

		//战斗结束通知
		public const int MSG_NOTIFY_BATTLE_RESULT                            = 3055;






		public OpcodeAuto()
		{
		}

	}
}