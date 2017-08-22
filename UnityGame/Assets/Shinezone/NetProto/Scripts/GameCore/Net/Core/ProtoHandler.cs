using System;
using lxnet;
using ProtoBuf;
using System.IO;

public interface IProtoHandler
{
	Type ProtoType 	{ get; set;}
	int  ProtoId 	{ get; set;}
	void Handle 	(Msg msg);
	void Handle 	(Stream stream);
}

public class ProtoHandler<T> : IProtoHandler
{
	public Type 			ProtoType 		{ get; set;}
	public int 				ProtoId 		{ get; set;}
	public Action<T> 		OnReceiveOnce;
	public Action<int, T> 	OnReceiveTwo;


	public ProtoHandler (int protoId)
	{
		this.ProtoType 	= typeof(T);
		this.ProtoId 	= protoId;
	}

	public void Handle(Msg msg)
	{
		byte[] 	bytes 	= msg.GetMsgBodyBytes ();

		MemoryStream stream = new MemoryStream (bytes);
		Handle (stream);
	}

	public void Handle(Stream stream)
	{
		stream.Seek(0, SeekOrigin.Begin);
		T msg = Serializer.Deserialize<T>(stream);
		if (OnReceiveOnce != null)
		{
			OnReceiveOnce(msg);
		}

		if (OnReceiveTwo != null) 
		{
			OnReceiveTwo (ProtoId, msg);
		}
	}
}

