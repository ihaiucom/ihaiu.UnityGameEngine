using UnityEngine;
using System.Collections;
using lxnet;
using MessageProtocol;
using System.Collections.Generic;
using System;

public class ShinezoneNetProtoLua 
{
	/** lua 那边监听的协议 */
	public static Dictionary<int, bool> 		idDict = new Dictionary<int, bool>();

	/** 接收消息事件 */
	public static event Action<int, byte[]> 	receiveEvent;


	/** 添加监听的协议ID */
	public static void AddProtoId(int id)
	{
		if (!idDict.ContainsKey (id))
		{
			idDict.Add (id, true);
		}
	}


	/** 移除监听 */
	public static void RemoveProtoId(int id)
	{
		if (idDict.ContainsKey (id))
		{
			idDict.Remove (id);
		}
	}



	/** 移除所有监听 */
	public static void RemoveAllProtoId()
	{
		idDict.Clear ();
	}




	/** 发送消息 */
	public static void SendMsg(int protoId, byte[] data)
	{
		NetworkMgr.Socketer.SendBytesMsg (protoId, data);
	}


	/** 处理消息socket调用 */
	public static void ProcessMsg(Msg msg)
	{
		int protoId = msg.GetMsgType ();
		if (receiveEvent != null && idDict.ContainsKey(protoId)) 
		{
			receiveEvent (protoId, msg.GetMsgBodyBytes());
		}
	}

}
