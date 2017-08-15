using System;
using System.Collections.Generic;



// 此结构体定义是自动生成的，请勿修改！
namespace MessageProtocol
{
	// 角色全局数据
	public class GlobalData
	{
	}

	// 角色信息(简要)
	public class CharInfo
	{
		// 角色dbid
		public Int64 _dbid;

		// 性别
		public SByte _sex;

		// 名称
		public string _name;

		// 全局数据对象
		public GlobalData _globaldata;

		// 共享数据对象
		public ShareData _sharedata;
	}

	// 房间玩家信息
	public class RoomPlayerInfo
	{
		// 单位ID
		public UInt32 PlayerID;

		// 角色姓名
		public string Name;

		// 阵营
		public Int32 Group;

		// 进场顺序
		public Int32 Index;
	}

	// 角色共享数据
	public class ShareData
	{
	}

	// 背包物品详细数据
	public class ItemDataObj
	{
		// 背包格子index
		public Int32 _index;
	}

	// 角色详细数据
	public class CharDataObj
	{
	}



}