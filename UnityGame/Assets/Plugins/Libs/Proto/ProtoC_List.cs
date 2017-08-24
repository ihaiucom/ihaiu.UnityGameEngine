

using UnityEngine;
using System;
using Games.PB;






// ====================
// authorization
// -- --------------------

// authorization
// 请求首次登录认证，收到随机因子后根据协议里的是否需要短链接,不需要
// [mapping] S_FirstAuthorization_10002,  authorization_pb, 登录认证结果
// [mapping] S_AccountDuplicateLogin_10004,  authorization_pb, 账号重复登录
public class C_FirstAuthorization_10000 : CMSG_FirstAuthorization_Req {}

// authorization
// 客户端断线重连认证，收到随机因子后根据协议里的是否需要短链接,需要
public class C_ReconnectOnLossandAuthorization_10001 : CMSG_ReconnectOnLossandAuthorization_Req {}




// ====================
// hero
// -- --------------------

// hero
// 请求选择初始英雄
public class C_SelectInitializedHero_12003 : CMSG_SelectInitializedHero_Req {}








public partial class ProtoC
{
	/** 需要继承实现 */
	public static void Install()
	{			




		// ====================
		// authorization
		// -- --------------------

		// 请求首次登录认证，收到随机因子后根据协议里的是否需要短链接,不需要
		// [mapping] S_FirstAuthorization_10002,  authorization_pb, 登录认证结果
		// [mapping] S_AccountDuplicateLogin_10004,  authorization_pb, 账号重复登录
 		AddItem(new ProtoItem<C_FirstAuthorization_10000>(){ opcode=10000, protoStructType=typeof(CMSG_FirstAuthorization_Req),  protoStructAliasType=typeof(C_FirstAuthorization_10000), protoStructName="CMSG_FirstAuthorization_Req", protoStructAliasName="C_FirstAuthorization_10000", protoFilename="authorization", opcodeMapping=new int[]{10002,10004}, note="请求首次登录认证，收到随机因子后根据协议里的是否需要短链接,不需要"  });

		// 客户端断线重连认证，收到随机因子后根据协议里的是否需要短链接,需要
 		AddItem(new ProtoItem<C_ReconnectOnLossandAuthorization_10001>(){ opcode=10001, protoStructType=typeof(CMSG_ReconnectOnLossandAuthorization_Req),  protoStructAliasType=typeof(C_ReconnectOnLossandAuthorization_10001), protoStructName="CMSG_ReconnectOnLossandAuthorization_Req", protoStructAliasName="C_ReconnectOnLossandAuthorization_10001", protoFilename="authorization", opcodeMapping=new int[]{}, note="客户端断线重连认证，收到随机因子后根据协议里的是否需要短链接,需要"  });




		// ====================
		// hero
		// -- --------------------

		// 请求选择初始英雄
 		AddItem(new ProtoItem<C_SelectInitializedHero_12003>(){ opcode=12003, protoStructType=typeof(CMSG_SelectInitializedHero_Req),  protoStructAliasType=typeof(C_SelectInitializedHero_12003), protoStructName="CMSG_SelectInitializedHero_Req", protoStructAliasName="C_SelectInitializedHero_12003", protoFilename="hero", opcodeMapping=new int[]{}, note="请求选择初始英雄"  });



	}
}
			


