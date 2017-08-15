using System;
using System.Collections.Generic;
using lxnet;


// 此代码自动生成，请勿修改！
namespace MessageProtocol
{
	public class auto_gen_packet
	{




		////////////////////////////////////////////////////////////////////////////////
		//公共接口
		////////////////////////////////////////////////////////////////////////////////



		// 装入背包物品详细数据数组
		public static void packet_push_ItemDataObj_array(Msg msg, List<ItemDataObj> data)
		{
			Int16 num = (Int16)data.Count;
			msg.PushInt16(num);
			for (int i = 0; i < num; ++i) {
				packet_push_ItemDataObj_object(msg, data[i]);
			}
		}


		// 获取背包物品详细数据数组
		public static List<ItemDataObj> packet_get_ItemDataObj_array(Msg msg)
		{
			List<ItemDataObj> data = new List<ItemDataObj>();
			int num = msg.GetInt16();
			for (int i = 0; i < num; ++i) {
				data.Add(packet_get_ItemDataObj_object(msg));
			}
			return data;
		}


		// 获取角色信息(简要)数组
		public static List<CharInfo> packet_get_CharInfo_array(Msg msg)
		{
			List<CharInfo> data = new List<CharInfo>();
			int num = msg.GetInt16();
			for (int i = 0; i < num; ++i) {
				data.Add(packet_get_CharInfo_object(msg));
			}
			return data;
		}


		// 装入角色信息(简要)数组
		public static void packet_push_CharInfo_array(Msg msg, List<CharInfo> data)
		{
			Int16 num = (Int16)data.Count;
			msg.PushInt16(num);
			for (int i = 0; i < num; ++i) {
				packet_push_CharInfo_object(msg, data[i]);
			}
		}





		////////////////////////////////////////////////////////////////////////////////
		//结构体接口
		////////////////////////////////////////////////////////////////////////////////



		// 装入角色全局数据
		public static void packet_push_GlobalData_object(Msg msg, GlobalData data)
		{
		}


		// 获取角色全局数据
		public static GlobalData packet_get_GlobalData_object(Msg msg)
		{
			GlobalData data = new GlobalData();
			return data;
		}



		// 装入角色信息(简要)
		public static void packet_push_CharInfo_object(Msg msg, CharInfo data)
		{
			msg.PushInt64(data._dbid);
			msg.PushSByte(data._sex);
			msg.PushString(data._name);
			packet_push_GlobalData_object(msg, data._globaldata);
			packet_push_ShareData_object(msg, data._sharedata);
		}


		// 获取角色信息(简要)
		public static CharInfo packet_get_CharInfo_object(Msg msg)
		{
			CharInfo data = new CharInfo();
			data._dbid = msg.GetInt64();
			data._sex = msg.GetSByte();
			data._name = msg.GetString();
			data._globaldata = packet_get_GlobalData_object(msg);
			data._sharedata = packet_get_ShareData_object(msg);
			return data;
		}



		// 装入房间玩家信息
		public static void packet_push_RoomPlayerInfo_object(Msg msg, RoomPlayerInfo data)
		{
			msg.PushUInt32(data.PlayerID);
			msg.PushString(data.Name);
			msg.PushInt32(data.Group);
			msg.PushInt32(data.Index);
		}


		// 获取房间玩家信息
		public static RoomPlayerInfo packet_get_RoomPlayerInfo_object(Msg msg)
		{
			RoomPlayerInfo data = new RoomPlayerInfo();
			data.PlayerID = msg.GetUInt32();
			data.Name = msg.GetString();
			data.Group = msg.GetInt32();
			data.Index = msg.GetInt32();
			return data;
		}



		// 装入角色共享数据
		public static void packet_push_ShareData_object(Msg msg, ShareData data)
		{
		}


		// 获取角色共享数据
		public static ShareData packet_get_ShareData_object(Msg msg)
		{
			ShareData data = new ShareData();
			return data;
		}



		// 装入背包物品详细数据
		public static void packet_push_ItemDataObj_object(Msg msg, ItemDataObj data)
		{
			msg.PushInt32(data._index);
		}


		// 获取背包物品详细数据
		public static ItemDataObj packet_get_ItemDataObj_object(Msg msg)
		{
			ItemDataObj data = new ItemDataObj();
			data._index = msg.GetInt32();
			return data;
		}



		// 装入角色详细数据
		public static void packet_push_CharDataObj_object(Msg msg, CharDataObj data)
		{
		}


		// 获取角色详细数据
		public static CharDataObj packet_get_CharDataObj_object(Msg msg)
		{
			CharDataObj data = new CharDataObj();
			return data;
		}





	}
}