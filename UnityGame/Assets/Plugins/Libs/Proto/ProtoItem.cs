using UnityEngine;
using System.Collections;
using System;

using ProtoBuf;
using System.IO;


public interface IProtoItem
{
	Type protoStructType 		{ get; set;}
	Type protoStructAliasType 	{ get; set;}
	int  opcode 	{ get; set;}
	void Handle 	(Stream stream);
}

public class ProtoItem<T> : IProtoItem
{

	/** 协议号 */
	public int 				opcode 		{ get; set;}

	/** 结构体Type */
	public Type protoStructType 		{ get; set;}

	/** 结构体别名 */
	public Type protoStructAliasType 	{ get; set;}

	/** 结构体名称 */
	public string 			protoStructName;
	/** 结构体别名 */
	public string 			protoStructAliasName;


	/** 协议文件 */
	public string 			protoFilename;

	/** 协议文件 */
	public int[] 			opcodeMapping ;

	/** 描述 */
	public string 			note;



	public Action<T> 		OnReceiveOnce;
	public Action<int, T> 	OnReceiveTwo;


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
			OnReceiveTwo (opcode, msg);
		}
	}

	public override string ToString ()
	{
		return string.Format ("{0}, {1}, {2}]", protoStructAliasName, protoFilename, note);
	}

}
