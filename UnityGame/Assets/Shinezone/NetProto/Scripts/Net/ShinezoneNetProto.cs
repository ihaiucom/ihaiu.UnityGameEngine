using UnityEngine;
using System.Collections;
using lxnet;
using MessageProtocol;
using System;

public class ShinezoneNetProto
{

	/** 发送消息 */
	public void SendProtoMsg<T>(int id, T protoMsg)
	{
		NetworkMgr.Socketer.SendProtoMsg<T> (id, protoMsg);
	}

	public void SendEmptyMsg(int id)
	{
		NetworkMgr.Socketer.SendEmptyMsg (id);
	}

	/** 添加监听 */
	public void AddCallback<T>(int id, Action<int, T> callback)
	{
		NetworkMgr.Socketer.AddCallback<T> (id, callback);
	}

	public void AddCallback<T>(int id, Action<T> callback)
	{
		NetworkMgr.Socketer.AddCallback<T> (id, callback);
	}

	/** 移除监听 */
	public void RemoveCallback<T>(int id, Action<int, T> callback)
	{
		NetworkMgr.Socketer.RemoveCallback<T> (id, callback);
	}

	public void RemoveCallback<T>(int id, Action<T> callback)
	{
		NetworkMgr.Socketer.RemoveCallback<T> (id, callback);
	}

}
