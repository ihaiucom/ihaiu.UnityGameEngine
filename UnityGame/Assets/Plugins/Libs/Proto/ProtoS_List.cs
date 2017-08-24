
using UnityEngine;
using System;
using Games.PB;






// ====================
// authorization
// -- --------------------

// authorization
// 登录认证结果
// [mapping] C_FirstAuthorization_10000,  authorization_pb, 请求首次登录认证，收到随机因子后根据协议里的是否需要短链接,不需要
// [mapping] C_ReconnectOnLossandAuthorization_10001,  authorization_pb, 客户端断线重连认证，收到随机因子后根据协议里的是否需要短链接,需要
public class S_FirstAuthorization_10002 : SMSG_FirstAuthorization_Resp {}

// authorization
// 通知客户端重新连接到新网关
public class S_ConnectToNewGateway_10003 : SMSG_ConnectToNewGateway_Ntf {}

// authorization
// 账号重复登录
// [mapping] C_FirstAuthorization_10000,  authorization_pb, 请求首次登录认证，收到随机因子后根据协议里的是否需要短链接,不需要
// [mapping] C_ReconnectOnLossandAuthorization_10001,  authorization_pb, 客户端断线重连认证，收到随机因子后根据协议里的是否需要短链接,需要
public class S_AccountDuplicateLogin_10004 : SMSG_AccountDuplicateLogin_Ntf {}

// authorization
// 同步服务器时间
public class S_SyncServerTimestamp_15001 : SMSG_SyncServerTimestamp_Ntf {}

// authorization
// 同步随机因子，链接上socket时服务器发
public class S_SyncRandomFactor_15002 : SMSG_SyncRandomFactor_Ntf {}




// ====================
// character
// -- --------------------

// character
// 同步角色信息
public class S_SyncRoleInfo_12001 : SMSG_SyncRoleInfo_Ntf {}




// ====================
// hero
// -- --------------------

// hero
// 同步英雄列表
public class S_SyncHeroList_12002 : SMSG_SyncHeroList_Ntf {}

// hero
// 选择初始英雄结果
// [mapping] C_SelectInitializedHero_12003,  hero_pb, 请求选择初始英雄
public class S_SelectInitializedHero_12004 : SMSG_SelectInitializedHero_Resp {}

// hero
// 获得新英雄
// [mapping] C_SelectInitializedHero_12003,  hero_pb, 请求选择初始英雄
public class S_AddHero_12005 : SMSG_AddHero_Ntf {}








public partial class ProtoS
{
	/** 需要继承实现 */
	public static void Install()
	{			




		// ====================
		// authorization
		// -- --------------------

		// 登录认证结果
		// [mapping] C_FirstAuthorization_10000,  authorization_pb, 请求首次登录认证，收到随机因子后根据协议里的是否需要短链接,不需要
		// [mapping] C_ReconnectOnLossandAuthorization_10001,  authorization_pb, 客户端断线重连认证，收到随机因子后根据协议里的是否需要短链接,需要
 		AddItem(new ProtoItem<S_FirstAuthorization_10002>(){ opcode=10002, protoStructType=typeof(SMSG_FirstAuthorization_Resp),  protoStructAliasType=typeof(S_FirstAuthorization_10002), protoStructName="SMSG_FirstAuthorization_Resp", protoStructAliasName="S_FirstAuthorization_10002", protoFilename="authorization", opcodeMapping=new int[]{10000,10001}, note="登录认证结果"  });

		// 通知客户端重新连接到新网关
 		AddItem(new ProtoItem<S_ConnectToNewGateway_10003>(){ opcode=10003, protoStructType=typeof(SMSG_ConnectToNewGateway_Ntf),  protoStructAliasType=typeof(S_ConnectToNewGateway_10003), protoStructName="SMSG_ConnectToNewGateway_Ntf", protoStructAliasName="S_ConnectToNewGateway_10003", protoFilename="authorization", opcodeMapping=new int[]{}, note="通知客户端重新连接到新网关"  });

		// 账号重复登录
		// [mapping] C_FirstAuthorization_10000,  authorization_pb, 请求首次登录认证，收到随机因子后根据协议里的是否需要短链接,不需要
		// [mapping] C_ReconnectOnLossandAuthorization_10001,  authorization_pb, 客户端断线重连认证，收到随机因子后根据协议里的是否需要短链接,需要
 		AddItem(new ProtoItem<S_AccountDuplicateLogin_10004>(){ opcode=10004, protoStructType=typeof(SMSG_AccountDuplicateLogin_Ntf),  protoStructAliasType=typeof(S_AccountDuplicateLogin_10004), protoStructName="SMSG_AccountDuplicateLogin_Ntf", protoStructAliasName="S_AccountDuplicateLogin_10004", protoFilename="authorization", opcodeMapping=new int[]{10000,10001}, note="账号重复登录"  });

		// 同步服务器时间
 		AddItem(new ProtoItem<S_SyncServerTimestamp_15001>(){ opcode=15001, protoStructType=typeof(SMSG_SyncServerTimestamp_Ntf),  protoStructAliasType=typeof(S_SyncServerTimestamp_15001), protoStructName="SMSG_SyncServerTimestamp_Ntf", protoStructAliasName="S_SyncServerTimestamp_15001", protoFilename="authorization", opcodeMapping=new int[]{}, note="同步服务器时间"  });

		// 同步随机因子，链接上socket时服务器发
 		AddItem(new ProtoItem<S_SyncRandomFactor_15002>(){ opcode=15002, protoStructType=typeof(SMSG_SyncRandomFactor_Ntf),  protoStructAliasType=typeof(S_SyncRandomFactor_15002), protoStructName="SMSG_SyncRandomFactor_Ntf", protoStructAliasName="S_SyncRandomFactor_15002", protoFilename="authorization", opcodeMapping=new int[]{}, note="同步随机因子，链接上socket时服务器发"  });




		// ====================
		// character
		// -- --------------------

		// 同步角色信息
 		AddItem(new ProtoItem<S_SyncRoleInfo_12001>(){ opcode=12001, protoStructType=typeof(SMSG_SyncRoleInfo_Ntf),  protoStructAliasType=typeof(S_SyncRoleInfo_12001), protoStructName="SMSG_SyncRoleInfo_Ntf", protoStructAliasName="S_SyncRoleInfo_12001", protoFilename="character", opcodeMapping=new int[]{}, note="同步角色信息"  });




		// ====================
		// hero
		// -- --------------------

		// 同步英雄列表
 		AddItem(new ProtoItem<S_SyncHeroList_12002>(){ opcode=12002, protoStructType=typeof(SMSG_SyncHeroList_Ntf),  protoStructAliasType=typeof(S_SyncHeroList_12002), protoStructName="SMSG_SyncHeroList_Ntf", protoStructAliasName="S_SyncHeroList_12002", protoFilename="hero", opcodeMapping=new int[]{}, note="同步英雄列表"  });

		// 选择初始英雄结果
		// [mapping] C_SelectInitializedHero_12003,  hero_pb, 请求选择初始英雄
 		AddItem(new ProtoItem<S_SelectInitializedHero_12004>(){ opcode=12004, protoStructType=typeof(SMSG_SelectInitializedHero_Resp),  protoStructAliasType=typeof(S_SelectInitializedHero_12004), protoStructName="SMSG_SelectInitializedHero_Resp", protoStructAliasName="S_SelectInitializedHero_12004", protoFilename="hero", opcodeMapping=new int[]{12003}, note="选择初始英雄结果"  });

		// 获得新英雄
		// [mapping] C_SelectInitializedHero_12003,  hero_pb, 请求选择初始英雄
 		AddItem(new ProtoItem<S_AddHero_12005>(){ opcode=12005, protoStructType=typeof(SMSG_AddHero_Ntf),  protoStructAliasType=typeof(S_AddHero_12005), protoStructName="SMSG_AddHero_Ntf", protoStructAliasName="S_AddHero_12005", protoFilename="hero", opcodeMapping=new int[]{12003}, note="获得新英雄"  });



	}
}
			


