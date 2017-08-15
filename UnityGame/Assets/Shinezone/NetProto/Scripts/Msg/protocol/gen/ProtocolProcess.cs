using System;
using System.Collections.Generic;
using lxnet;


// 此代码自动生成，请勿修改！
namespace MessageProtocol
{
	public class ProtocolProcess
	{

		private static ProtocolInterface m_instace;

		/**
		 * 初始化，注册协议处理函数
		 * */
		public static void Init(ProtocolInterface instance)
		{
			m_instace = instance;



			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_HINT_MESSAGE, on_hint_message);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_CHAR_LIST_TO_CLIENT, on_char_list_to_client);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_ADD_CHAR_TO_CHARLIST_CLIENT, on_add_char_to_charlist_client);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_TELL_DELETE_CHAR, on_tell_delete_char);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_ACCOUNT_HAS_GAMEING_CHAR_ONLY_USE_IT, on_account_has_gameing_char_only_use_it);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_TELL_CLIENT_LOAD_DATA, on_tell_client_load_data);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_TELL_CHAR_DATA, on_tell_char_data);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_TELL_CLIENT_LOAD_MAP, on_tell_client_load_map);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_TELL_CLIENT_ENTER_GAME, on_tell_client_enter_game);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_RECHARGE_SUCCEED_ADD_GOLD, on_recharge_succeed_add_gold);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_RSP_START_MATCH, on_rsp_start_match);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_NOTIFY_ADD_PLAYER, on_notify_add_player);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_NOTIFY_MATCH_SUCCESS, on_notify_match_success);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_RSP_TELL_READY, on_rsp_tell_ready);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_NOTIFY_START_BATTLE, on_notify_start_battle);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_RSP_TELL_START_BATTLE_READY, on_rsp_tell_start_battle_ready);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_NOTIFY_ENTER_BATTLE, on_notify_enter_battle);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_TELL_CLIENT_ADD_GOLD, on_tell_client_add_gold);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_TELL_CLIENT_DEC_GOLD, on_tell_client_dec_gold);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_TELL_CLIENT_ADD_MONEY, on_tell_client_add_money);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_TELL_CLIENT_DEC_MONEY, on_tell_client_dec_money);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_NOTIFY_FRAME_UPDATE, on_notify_frame_update);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_RSP_END_BATTLE, on_rsp_end_battle);
			NetworkMgr.RegisterProtocol(OpcodeAuto.MSG_NOTIFY_BATTLE_RESULT, on_notify_battle_result);
		}




		////////////////////////////////////////////////////////////////////////////////
		//消息处理接口
		////////////////////////////////////////////////////////////////////////////////



		// 服务器：提示一则信息
		private static void on_hint_message(Msg msg)
		{
			Int16 id = msg.GetInt16();

			ProtocolLogAuto.debug_log_hint_message(id);

			m_instace.on_hint_message(id);
		}


		// 服务器：告知客户端角色列表
		private static void on_char_list_to_client(Msg msg)
		{
			List<CharInfo> char_list = auto_gen_packet.packet_get_CharInfo_array(msg);

			ProtocolLogAuto.debug_log_char_list_to_client(char_list);

			m_instace.on_char_list_to_client(char_list);
		}


		// 服务器：告知客户端增加角色信息到角色列表
		private static void on_add_char_to_charlist_client(Msg msg)
		{
			CharInfo one_info = auto_gen_packet.packet_get_CharInfo_object(msg);

			ProtocolLogAuto.debug_log_add_char_to_charlist_client(one_info);

			m_instace.on_add_char_to_charlist_client(one_info);
		}


		// 服务器：告知客户端移除指定的角色
		private static void on_tell_delete_char(Msg msg)
		{
			Int64 dbid = msg.GetInt64();

			ProtocolLogAuto.debug_log_tell_delete_char(dbid);

			m_instace.on_tell_delete_char(dbid);
		}


		// 服务器：告知客户端当前账号存在正在游戏的角色，目前只能使用此正在角色的游戏进行游戏
		private static void on_account_has_gameing_char_only_use_it(Msg msg)
		{
			Int64 dbid = msg.GetInt64();

			ProtocolLogAuto.debug_log_account_has_gameing_char_only_use_it(dbid);

			m_instace.on_account_has_gameing_char_only_use_it(dbid);
		}


		// 服务器：告知客户端加载必须数据，等待服务器加载角色详细数据
		private static void on_tell_client_load_data(Msg msg)
		{

			ProtocolLogAuto.debug_log_tell_client_load_data();

			m_instace.on_tell_client_load_data();
		}


		// 服务器：告知客户端角色详细数据
		private static void on_tell_char_data(Msg msg)
		{
			Int64 dbid = msg.GetInt64();
			Int64 gold = msg.GetInt64();
			Int64 money = msg.GetInt64();
			CharDataObj dataobj = auto_gen_packet.packet_get_CharDataObj_object(msg);

			ProtocolLogAuto.debug_log_tell_char_data(dbid, gold, money, dataobj);

			m_instace.on_tell_char_data(dbid, gold, money, dataobj);
		}


		// 服务器：告知客户端准备加载指定地图以进入(客户端此时加载与详细数据相关的资源，当客户端加载完毕时，向服务器请求进入游戏)
		private static void on_tell_client_load_map(Msg msg)
		{
			Int32 map_id = msg.GetInt32();
			Int32 pos_x = msg.GetInt32();
			Int32 pos_y = msg.GetInt32();

			ProtocolLogAuto.debug_log_tell_client_load_map(map_id, pos_x, pos_y);

			m_instace.on_tell_client_load_map(map_id, pos_x, pos_y);
		}


		// 服务器：告知客户端进入游戏
		private static void on_tell_client_enter_game(Msg msg)
		{

			ProtocolLogAuto.debug_log_tell_client_enter_game();

			m_instace.on_tell_client_enter_game();
		}


		// 服务器：告知客户端充值成功，充值了X元宝
		private static void on_recharge_succeed_add_gold(Msg msg)
		{
			Int64 recharge_gold = msg.GetInt64();

			ProtocolLogAuto.debug_log_recharge_succeed_add_gold(recharge_gold);

			m_instace.on_recharge_succeed_add_gold(recharge_gold);
		}


		// 申请匹配
		private static void on_rsp_start_match(Msg msg)
		{
			Int32 RetCode = msg.GetInt32();
			string Des = msg.GetString();

			ProtocolLogAuto.debug_log_rsp_start_match(RetCode, Des);

			m_instace.on_rsp_start_match(RetCode, Des);
		}


		// 申请匹配
		private static void on_notify_add_player(Msg msg)
		{
			Int32 Option = msg.GetInt32();
			Int32 Ret = msg.GetInt32();
			RoomPlayerInfo Player = auto_gen_packet.packet_get_RoomPlayerInfo_object(msg);

			ProtocolLogAuto.debug_log_notify_add_player(Option, Ret, Player);

			m_instace.on_notify_add_player(Option, Ret, Player);
		}


		// 匹配成功
		private static void on_notify_match_success(Msg msg)
		{
			Int32 TimeOut = msg.GetInt32();

			ProtocolLogAuto.debug_log_notify_match_success(TimeOut);

			m_instace.on_notify_match_success(TimeOut);
		}


		// 玩家通知服务器准备就绪
		private static void on_rsp_tell_ready(Msg msg)
		{
			Int32 RetCode = msg.GetInt32();
			string Des = msg.GetString();

			ProtocolLogAuto.debug_log_rsp_tell_ready(RetCode, Des);

			m_instace.on_rsp_tell_ready(RetCode, Des);
		}


		// 准备战斗
		private static void on_notify_start_battle(Msg msg)
		{

			ProtocolLogAuto.debug_log_notify_start_battle();

			m_instace.on_notify_start_battle();
		}


		// 玩家通知服务器准备战斗
		private static void on_rsp_tell_start_battle_ready(Msg msg)
		{
			Int32 RetCode = msg.GetInt32();
			string Des = msg.GetString();

			ProtocolLogAuto.debug_log_rsp_tell_start_battle_ready(RetCode, Des);

			m_instace.on_rsp_tell_start_battle_ready(RetCode, Des);
		}


		// 匹配成功
		private static void on_notify_enter_battle(Msg msg)
		{
			string BattleID = msg.GetString();

			ProtocolLogAuto.debug_log_notify_enter_battle(BattleID);

			m_instace.on_notify_enter_battle(BattleID);
		}


		// 服务器：告知客户端增加角色元宝
		private static void on_tell_client_add_gold(Msg msg)
		{
			Int64 add_gold = msg.GetInt64();

			ProtocolLogAuto.debug_log_tell_client_add_gold(add_gold);

			m_instace.on_tell_client_add_gold(add_gold);
		}


		// 服务器：告知客户端减少角色元宝
		private static void on_tell_client_dec_gold(Msg msg)
		{
			Int64 dec_gold = msg.GetInt64();

			ProtocolLogAuto.debug_log_tell_client_dec_gold(dec_gold);

			m_instace.on_tell_client_dec_gold(dec_gold);
		}


		// 服务器：告知客户端增加角色金钱
		private static void on_tell_client_add_money(Msg msg)
		{
			Int64 add_money = msg.GetInt64();

			ProtocolLogAuto.debug_log_tell_client_add_money(add_money);

			m_instace.on_tell_client_add_money(add_money);
		}


		// 服务器：告知客户端减少角色金钱
		private static void on_tell_client_dec_money(Msg msg)
		{
			Int64 dec_money = msg.GetInt64();

			ProtocolLogAuto.debug_log_tell_client_dec_money(dec_money);

			m_instace.on_tell_client_dec_money(dec_money);
		}


		// 转发事件帧
		private static void on_notify_frame_update(Msg msg)
		{
			UInt32 PlayerID = msg.GetUInt32();
			UInt32 CmdID = msg.GetUInt32();
			string Cmd = msg.GetString();
			UInt32 FrameID = msg.GetUInt32();
			Int64 ClientSentTime = msg.GetInt64();
			Int64 ClientRecvTime = msg.GetInt64();
			Int64 ServerSentTime = msg.GetInt64();
			Int64 ServerRecvTime = msg.GetInt64();

			ProtocolLogAuto.debug_log_notify_frame_update(PlayerID, CmdID, Cmd, FrameID, ClientSentTime, ClientRecvTime, ServerSentTime, ServerRecvTime);

			m_instace.on_notify_frame_update(PlayerID, CmdID, Cmd, FrameID, ClientSentTime, ClientRecvTime, ServerSentTime, ServerRecvTime);
		}


		// 战斗结束返回包
		private static void on_rsp_end_battle(Msg msg)
		{
			Int32 RetCode = msg.GetInt32();
			string Des = msg.GetString();

			ProtocolLogAuto.debug_log_rsp_end_battle(RetCode, Des);

			m_instace.on_rsp_end_battle(RetCode, Des);
		}


		// 战斗结束通知
		private static void on_notify_battle_result(Msg msg)
		{
			string BattleID = msg.GetString();
			Int32 Group = msg.GetInt32();

			ProtocolLogAuto.debug_log_notify_battle_result(BattleID, Group);

			m_instace.on_notify_battle_result(BattleID, Group);
		}




	}
}