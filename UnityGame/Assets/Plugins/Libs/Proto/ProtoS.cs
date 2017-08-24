using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public partial class ProtoS
{
	public static Dictionary<int, IProtoItem> 		opcodeDict 		= new Dictionary<int, IProtoItem>();
	public static Dictionary<Type, IProtoItem> 		typeDict 		= new Dictionary<Type, IProtoItem>();
	public static Dictionary<Type, IProtoItem> 		aliasTypeDict 	= new Dictionary<Type, IProtoItem>();

	/** 添加 */
	public static void AddItem(IProtoItem item)
	{
		opcodeDict.Add 			(item.opcode				, item);
		typeDict.Add 			(item.protoStructType		, item);
		aliasTypeDict.Add 		(item.protoStructAliasType	, item);
	}

	/** 获取 ProtoItem, 用 opcode */
	public static IProtoItem GetItemByOpcode(int opcode)
	{
		if (!opcodeDict.ContainsKey (opcode)) 
		{
			Loger.LogTagErrorFormat ("SocketNet", "ProtoS 不存在opcode={0}的ProtoItem", opcode);
		}
		return opcodeDict[opcode];
	}

	/** 获取 ProtoItem, 用 Type */
	public static IProtoItem GetItemByType(Type type)
	{
		if (typeDict.ContainsKey (type)) 
		{
			return typeDict[type];
		}


		if (aliasTypeDict.ContainsKey (type)) 
		{
			return aliasTypeDict[type];
		}

		Loger.LogTagErrorFormat ("SocketNet", "ProtoS 不存在type={0}的ProtoItem", type);
		return null;
	}

	/** 获取 ProtoItem, 用 msg */
	public static IProtoItem GetItemByMsg(object msg)
	{
		return GetItemByType(msg.GetType());
	}


}
