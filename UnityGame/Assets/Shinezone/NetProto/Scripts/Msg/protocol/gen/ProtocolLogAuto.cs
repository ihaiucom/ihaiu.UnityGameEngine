using System;
using System.Collections.Generic;


// 此代码自动生成，请勿修改！
namespace MessageProtocol
{
	public class ProtocolLogAuto
	{

		private static bool m_enable = false;



		/**
		 * 启用/禁用协议调试日志
		 * */
		public static void EnableDebugLog(bool flag)
		{
			m_enable = flag;
		}

		private static void debug_log(string str)
		{

		}


		private static void empty_tbn_ref(string tbn)
		{
		}




		////////////////////////////////////////////////////////////////////////////////
		//对外接口
		////////////////////////////////////////////////////////////////////////////////



		public static void debug_log_hint_message(Int16 id)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_HINT_MESSAGE(1052):\n";
			str += "\tid:" + id.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_char_list_to_client(List<CharInfo> char_list)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_CHAR_LIST_TO_CLIENT(1053):\n";
			str += "\tchar_list:" + debug_log_CharInfo_array(char_list, tbn + "\t");
			debug_log(str);
		}


		public static void debug_log_req_create_char(SByte sex, string name)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "req MSG_REQ_CREATE_CHAR(1054):\n";
			str += "\tsex:" + sex.ToString() + "\n";
			str += "\tname:" + name.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_add_char_to_charlist_client(CharInfo one_info)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_ADD_CHAR_TO_CHARLIST_CLIENT(1055):\n";
			str += "\tone_info:" + debug_log_CharInfo_object(one_info, tbn + "\t");
			debug_log(str);
		}


		public static void debug_log_req_delete_char(Int64 dbid)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "req MSG_REQ_DELETE_CHAR(1056):\n";
			str += "\tdbid:" + dbid.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_tell_delete_char(Int64 dbid)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_TELL_DELETE_CHAR(1057):\n";
			str += "\tdbid:" + dbid.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_req_start_game_by_char(Int64 dbid)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "req MSG_REQ_START_GAME_BY_CHAR(1058):\n";
			str += "\tdbid:" + dbid.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_account_has_gameing_char_only_use_it(Int64 dbid)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_ACCOUNT_HAS_GAMEING_CHAR_ONLY_USE_IT(1059):\n";
			str += "\tdbid:" + dbid.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_tell_client_load_data()
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_TELL_CLIENT_LOAD_DATA(1060):\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_tell_char_data(Int64 dbid, Int64 gold, Int64 money, CharDataObj dataobj)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_TELL_CHAR_DATA(1061):\n";
			str += "\tdbid:" + dbid.ToString() + "\n";
			str += "\tgold:" + gold.ToString() + "\n";
			str += "\tmoney:" + money.ToString() + "\n";
			str += "\tdataobj:" + debug_log_CharDataObj_object(dataobj, tbn + "\t");
			debug_log(str);
		}


		public static void debug_log_tell_client_load_map(Int32 map_id, Int32 pos_x, Int32 pos_y)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_TELL_CLIENT_LOAD_MAP(1062):\n";
			str += "\tmap_id:" + map_id.ToString() + "\n";
			str += "\tpos_x:" + pos_x.ToString() + "\n";
			str += "\tpos_y:" + pos_y.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_tell_client_enter_game()
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_TELL_CLIENT_ENTER_GAME(1063):\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_recharge_succeed_add_gold(Int64 recharge_gold)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_RECHARGE_SUCCEED_ADD_GOLD(1064):\n";
			str += "\trecharge_gold:" + recharge_gold.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_req_start_match(Int32 Option)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "req MSG_REQ_START_MATCH(2034):\n";
			str += "\tOption:" + Option.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_rsp_start_match(Int32 RetCode, string Des)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_RSP_START_MATCH(2035):\n";
			str += "\tRetCode:" + RetCode.ToString() + "\n";
			str += "\tDes:" + Des.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_notify_add_player(Int32 Option, Int32 Ret, RoomPlayerInfo Player)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_NOTIFY_ADD_PLAYER(2037):\n";
			str += "\tOption:" + Option.ToString() + "\n";
			str += "\tRet:" + Ret.ToString() + "\n";
			str += "\tPlayer:" + debug_log_RoomPlayerInfo_object(Player, tbn + "\t");
			debug_log(str);
		}


		public static void debug_log_notify_match_success(Int32 TimeOut)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_NOTIFY_MATCH_SUCCESS(2039):\n";
			str += "\tTimeOut:" + TimeOut.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_req_tell_ready()
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "req MSG_REQ_TELL_READY(2040):\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_rsp_tell_ready(Int32 RetCode, string Des)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_RSP_TELL_READY(2041):\n";
			str += "\tRetCode:" + RetCode.ToString() + "\n";
			str += "\tDes:" + Des.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_notify_start_battle()
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_NOTIFY_START_BATTLE(2042):\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_req_tell_start_battle_ready(UInt32 FrameTick)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "req MSG_REQ_TELL_START_BATTLE_READY(2044):\n";
			str += "\tFrameTick:" + FrameTick.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_rsp_tell_start_battle_ready(Int32 RetCode, string Des)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_RSP_TELL_START_BATTLE_READY(2045):\n";
			str += "\tRetCode:" + RetCode.ToString() + "\n";
			str += "\tDes:" + Des.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_notify_enter_battle(string BattleID)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_NOTIFY_ENTER_BATTLE(2047):\n";
			str += "\tBattleID:" + BattleID.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_req_enter_to_game()
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "req MSG_REQ_ENTER_TO_GAME(3001):\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_tell_client_add_gold(Int64 add_gold)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_TELL_CLIENT_ADD_GOLD(3002):\n";
			str += "\tadd_gold:" + add_gold.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_tell_client_dec_gold(Int64 dec_gold)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_TELL_CLIENT_DEC_GOLD(3003):\n";
			str += "\tdec_gold:" + dec_gold.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_tell_client_add_money(Int64 add_money)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_TELL_CLIENT_ADD_MONEY(3004):\n";
			str += "\tadd_money:" + add_money.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_tell_client_dec_money(Int64 dec_money)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_TELL_CLIENT_DEC_MONEY(3005):\n";
			str += "\tdec_money:" + dec_money.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_req_frame_update(string BattleID, UInt32 PlayerID, UInt32 CmdID, string Cmd, Int64 ClientSentTime, Int64 ClientRecvTime)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "req MSG_REQ_FRAME_UPDATE(3050):\n";
			str += "\tBattleID:" + BattleID.ToString() + "\n";
			str += "\tPlayerID:" + PlayerID.ToString() + "\n";
			str += "\tCmdID:" + CmdID.ToString() + "\n";
			str += "\tCmd:" + Cmd.ToString() + "\n";
			str += "\tClientSentTime:" + ClientSentTime.ToString() + "\n";
			str += "\tClientRecvTime:" + ClientRecvTime.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_notify_frame_update(UInt32 PlayerID, UInt32 CmdID, string Cmd, UInt32 FrameID, Int64 ClientSentTime, Int64 ClientRecvTime, Int64 ServerSentTime, Int64 ServerRecvTime)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_NOTIFY_FRAME_UPDATE(3051):\n";
			str += "\tPlayerID:" + PlayerID.ToString() + "\n";
			str += "\tCmdID:" + CmdID.ToString() + "\n";
			str += "\tCmd:" + Cmd.ToString() + "\n";
			str += "\tFrameID:" + FrameID.ToString() + "\n";
			str += "\tClientSentTime:" + ClientSentTime.ToString() + "\n";
			str += "\tClientRecvTime:" + ClientRecvTime.ToString() + "\n";
			str += "\tServerSentTime:" + ServerSentTime.ToString() + "\n";
			str += "\tServerRecvTime:" + ServerRecvTime.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_req_end_battle(string BattleID, Int32 Group)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "req MSG_REQ_END_BATTLE(3052):\n";
			str += "\tBattleID:" + BattleID.ToString() + "\n";
			str += "\tGroup:" + Group.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_rsp_end_battle(Int32 RetCode, string Des)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_RSP_END_BATTLE(3053):\n";
			str += "\tRetCode:" + RetCode.ToString() + "\n";
			str += "\tDes:" + Des.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}


		public static void debug_log_notify_battle_result(string BattleID, Int32 Group)
		{
			if (!m_enable)
				return;

			string tbn = "";
			string str = "on MSG_NOTIFY_BATTLE_RESULT(3055):\n";
			str += "\tBattleID:" + BattleID.ToString() + "\n";
			str += "\tGroup:" + Group.ToString() + "\n";
			debug_log(str);

			empty_tbn_ref(tbn);
		}





		////////////////////////////////////////////////////////////////////////////////
		//公共接口
		////////////////////////////////////////////////////////////////////////////////



		private static string debug_log_ItemDataObj_array(List<ItemDataObj> data, string tbn)
		{
			string str = "{List<ItemDataObj>}:\n";
			Int16 num = (Int16)data.Count;
			for (int i = 0; i < num; ++i) {
				str += tbn + "\t" + debug_log_ItemDataObj_object(data[i], tbn + "\t");
			}
			return str;
		}


		private static string debug_log_CharInfo_array(List<CharInfo> data, string tbn)
		{
			string str = "{List<CharInfo>}:\n";
			Int16 num = (Int16)data.Count;
			for (int i = 0; i < num; ++i) {
				str += tbn + "\t" + debug_log_CharInfo_object(data[i], tbn + "\t");
			}
			return str;
		}





		////////////////////////////////////////////////////////////////////////////////
		//结构体接口
		////////////////////////////////////////////////////////////////////////////////



		private static string debug_log_GlobalData_object(GlobalData data, string tbn)
		{
			string str = "\n";
			return str;
		}



		private static string debug_log_CharInfo_object(CharInfo data, string tbn)
		{
			string str = "\n";
			str += tbn + "\t_dbid:" + data._dbid.ToString()+ "\n";
			str += tbn + "\t_sex:" + data._sex.ToString()+ "\n";
			str += tbn + "\t_name:" + data._name.ToString()+ "\n";
			str += tbn + "\t_globaldata:" + debug_log_GlobalData_object(data._globaldata, tbn + "\t");
			str += tbn + "\t_sharedata:" + debug_log_ShareData_object(data._sharedata, tbn + "\t");
			return str;
		}



		private static string debug_log_RoomPlayerInfo_object(RoomPlayerInfo data, string tbn)
		{
			string str = "\n";
			str += tbn + "\tPlayerID:" + data.PlayerID.ToString()+ "\n";
			str += tbn + "\tName:" + data.Name.ToString()+ "\n";
			str += tbn + "\tGroup:" + data.Group.ToString()+ "\n";
			str += tbn + "\tIndex:" + data.Index.ToString()+ "\n";
			return str;
		}



		private static string debug_log_ShareData_object(ShareData data, string tbn)
		{
			string str = "\n";
			return str;
		}



		private static string debug_log_ItemDataObj_object(ItemDataObj data, string tbn)
		{
			string str = "\n";
			str += tbn + "\t_index:" + data._index.ToString()+ "\n";
			return str;
		}



		private static string debug_log_CharDataObj_object(CharDataObj data, string tbn)
		{
			string str = "\n";
			return str;
		}





	}
}