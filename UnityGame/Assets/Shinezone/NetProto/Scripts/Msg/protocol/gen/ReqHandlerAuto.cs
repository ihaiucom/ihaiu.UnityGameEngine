using System;
using System.Collections.Generic;
using lxnet;


// 此代码自动生成，请勿修改！
namespace MessageProtocol
{
	public class ReqHandlerAuto
	{




		////////////////////////////////////////////////////////////////////////////////
		//请求接口
		////////////////////////////////////////////////////////////////////////////////



		/**
		 * 客户端：请求创建角色
		 * @param {int8} sex 性别
		 * @param {string} name 名称
		 * */
		public static void req_create_char(SByte sex, string name)
		{
			ProtocolLogAuto.debug_log_req_create_char(sex, name);

			Msg msg = new Msg();
			msg.SetMsgType(OpcodeAuto.MSG_REQ_CREATE_CHAR);
			msg.PushSByte(sex);
			msg.PushString(name);
			NetworkMgr.SendMsgToServer(msg);
		}


		/**
		 * 客户端：请求删除角色
		 * @param {int64} dbid 角色dbid
		 * */
		public static void req_delete_char(Int64 dbid)
		{
			ProtocolLogAuto.debug_log_req_delete_char(dbid);

			Msg msg = new Msg();
			msg.SetMsgType(OpcodeAuto.MSG_REQ_DELETE_CHAR);
			msg.PushInt64(dbid);
			NetworkMgr.SendMsgToServer(msg);
		}


		/**
		 * 客户端：请求用指定的角色进入游戏
		 * @param {int64} dbid 角色dbid
		 * */
		public static void req_start_game_by_char(Int64 dbid)
		{
			ProtocolLogAuto.debug_log_req_start_game_by_char(dbid);

			Msg msg = new Msg();
			msg.SetMsgType(OpcodeAuto.MSG_REQ_START_GAME_BY_CHAR);
			msg.PushInt64(dbid);
			NetworkMgr.SendMsgToServer(msg);
		}


		/**
		 * 申请匹配
		 * @param {int32} Option 匹配类型 1：1v1 2: 2v2 3: 3v3 
		 * */
		public static void req_start_match(Int32 Option)
		{
			ProtocolLogAuto.debug_log_req_start_match(Option);

			Msg msg = new Msg();
			msg.SetMsgType(OpcodeAuto.MSG_REQ_START_MATCH);
			msg.PushInt32(Option);
			NetworkMgr.SendMsgToServer(msg);
		}


		/**
		 * 玩家通知服务器准备就绪
		 * */
		public static void req_tell_ready()
		{
			ProtocolLogAuto.debug_log_req_tell_ready();

			Msg msg = new Msg();
			msg.SetMsgType(OpcodeAuto.MSG_REQ_TELL_READY);
			NetworkMgr.SendMsgToServer(msg);
		}


		/**
		 * 玩家通知服务器战斗场景加载完毕
		 * @param {uint32} FrameTick 帧频率，单位毫秒
		 * */
		public static void req_tell_start_battle_ready(UInt32 FrameTick)
		{
			ProtocolLogAuto.debug_log_req_tell_start_battle_ready(FrameTick);

			Msg msg = new Msg();
			msg.SetMsgType(OpcodeAuto.MSG_REQ_TELL_START_BATTLE_READY);
			msg.PushUInt32(FrameTick);
			NetworkMgr.SendMsgToServer(msg);
		}


		/**
		 * 客户端：告知服务器地图加载完毕，请求进入游戏（此时是告知逻辑服，然后若玩家是第一次在此逻辑服进入游戏，则告知全局，让全局变更相关状态，并由全局发送触发客户端进入游戏的消息；否则逻辑服直接发送触发客户端进入游戏的消息）
		 * */
		public static void req_enter_to_game()
		{
			ProtocolLogAuto.debug_log_req_enter_to_game();

			Msg msg = new Msg();
			msg.SetMsgType(OpcodeAuto.MSG_REQ_ENTER_TO_GAME);
			NetworkMgr.SendMsgToServer(msg);
		}


		/**
		 * 发送事件帧
		 * @param {string} BattleID 战场ID
		 * @param {uint32} PlayerID 单位ID
		 * @param {uint32} CmdID 指令ID
		 * @param {string} Cmd 帧内容
		 * @param {int64} ClientSentTime 客户端发送时刻
		 * @param {int64} ClientRecvTime 客户端接受时刻
		 * */
		public static void req_frame_update(string BattleID, UInt32 PlayerID, UInt32 CmdID, string Cmd, Int64 ClientSentTime, Int64 ClientRecvTime)
		{
			ProtocolLogAuto.debug_log_req_frame_update(BattleID, PlayerID, CmdID, Cmd, ClientSentTime, ClientRecvTime);

			Msg msg = new Msg();
			msg.SetMsgType(OpcodeAuto.MSG_REQ_FRAME_UPDATE);
			msg.PushString(BattleID);
			msg.PushUInt32(PlayerID);
			msg.PushUInt32(CmdID);
			msg.PushString(Cmd);
			msg.PushInt64(ClientSentTime);
			msg.PushInt64(ClientRecvTime);
			NetworkMgr.SendMsgToServer(msg);
		}


		/**
		 * 结束战斗
		 * @param {string} BattleID 战场ID
		 * @param {int32} Group 胜利方
		 * */
		public static void req_end_battle(string BattleID, Int32 Group)
		{
			ProtocolLogAuto.debug_log_req_end_battle(BattleID, Group);

			Msg msg = new Msg();
			msg.SetMsgType(OpcodeAuto.MSG_REQ_END_BATTLE);
			msg.PushString(BattleID);
			msg.PushInt32(Group);
			NetworkMgr.SendMsgToServer(msg);
		}




	}
}