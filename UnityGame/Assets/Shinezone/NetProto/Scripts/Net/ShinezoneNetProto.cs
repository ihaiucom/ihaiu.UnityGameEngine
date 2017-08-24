using UnityEngine;
using System.Collections;
using lxnet;
using MessageProtocol;
using System;
using System.IO;

public class ShinezoneNetProto
{
	/** 发送消息 */
	public void SendProtoMsg<T>(T protoMsg)
	{
		Type type = typeof(T);
		IProtoItem item = ProtoC.GetItemByType (type);

		MemoryStream stream = new MemoryStream ();
		ProtoBuf.Serializer.Serialize<T> (stream, protoMsg);
		stream.Position = 0;

		NetworkMgr.Socketer.SendBytesMsg (item.opcode, stream.ToArray());

		stream.Dispose ();
	}

	public void SendEmptyMsg(int id)
	{
		NetworkMgr.Socketer.SendEmptyMsg (id);
	}

	/** 添加监听 */
	public void AddCallback<T>(Action<int, T> callback)
	{
		Type type = typeof(T);
		ProtoItem<T> item = (ProtoItem<T>) ProtoS.GetItemByType (type);
		item.OnReceiveTwo += callback;
	}

	public void AddCallback<T>(Action<T> callback)
	{
		Type type = typeof(T);
		ProtoItem<T> item = (ProtoItem<T>) ProtoS.GetItemByType (type);
		item.OnReceiveOnce += callback;
	}

	/** 移除监听 */
	public void RemoveCallback<T>(Action<int, T> callback)
	{
		Type type = typeof(T);
		ProtoItem<T> item = (ProtoItem<T>) ProtoS.GetItemByType (type);
		item.OnReceiveTwo -= callback;
	}

	public void RemoveCallback<T>(Action<T> callback)
	{
		Type type = typeof(T);
		ProtoItem<T> item = (ProtoItem<T>) ProtoS.GetItemByType (type);
		item.OnReceiveOnce -= callback;
	}

}
