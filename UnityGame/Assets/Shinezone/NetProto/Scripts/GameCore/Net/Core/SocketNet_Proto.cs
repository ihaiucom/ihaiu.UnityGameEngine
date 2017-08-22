using System.IO;

namespace lxnet
{
	using System;
	using System.Collections.Generic;

	public partial class SocketNet
	{
		private Dictionary<int, IProtoHandler> protoHandlerDict = new Dictionary<int, IProtoHandler>();

		/**
		 * 发送消息
		 * @param {Message} msg 消息对象
		 * */
		public void SendProtoMsg<T>(int id, T protoMsg)
		{
			MemoryStream stream = new MemoryStream ();
			ProtoBuf.Serializer.Serialize<T> (stream, protoMsg);
			stream.Position = 0;


			Msg msg = new Msg ();
			msg.SetMsgType(id);
			msg.PushBytes (stream.ToArray());
			SendMsg (msg);

			stream.Dispose ();
		}

		public void SendBytesMsg(int id, byte[] bytes)
		{

			Msg msg = new Msg ();
			msg.SetMsgType(id);
			msg.PushBytes (bytes);
			SendMsg (msg);
		}

		public void SendEmptyMsg(int id)
		{

			Msg msg = new Msg ();
			msg.SetMsgType(id);
			SendMsg (msg);
		}


		/** 注册监听 */
		public ProtoHandler<T> RegisterProto<T>(int id)
		{
			ProtoHandler<T> protoHandler;
			if (protoHandlerDict.ContainsKey (id)) 
			{
				IProtoHandler handler = protoHandlerDict [id];

				Type type = typeof(T);
				if (handler.ProtoType != type) 
				{
					Loger.LogErrorFormat ("RegisterProto<T> protoId={0} ProtoType不一致 handler.ProtoType={1}, type={2} ", id, handler.ProtoType, type);
					return null;
				}
				else
				{
					protoHandler = (ProtoHandler<T>) handler;
				}
			}
			else
			{
				protoHandler = new ProtoHandler<T> (id);
				protoHandlerDict.Add (id, protoHandler);
			}

			return protoHandler;
		}



		/** 添加监听 */
		public void AddCallback<T>(int id, Action<int, T> callback)
		{
			ProtoHandler<T> protoHandler = RegisterProto<T>(id);
			if (protoHandler != null) 
			{
				protoHandler.OnReceiveTwo += callback;
			}
		}

		public void AddCallback<T>(int id, Action<T> callback)
		{
			ProtoHandler<T> protoHandler = RegisterProto<T>(id);
			if (protoHandler != null) 
			{
				protoHandler.OnReceiveOnce += callback;
			}
		}

		/** 移除监听 */
		public void RemoveCallback<T>(int id, Action<int, T> callback)
		{
			ProtoHandler<T> protoHandler;
			if (protoHandlerDict.ContainsKey (id)) 
			{
				IProtoHandler handler = protoHandlerDict [id];
				protoHandler = (ProtoHandler<T>) handler;
				if (protoHandler != null)
				{
					protoHandler.OnReceiveTwo -= callback;
				}
			}
		}

		public void RemoveCallback<T>(int id, Action<T> callback)
		{
			ProtoHandler<T> protoHandler;
			if (protoHandlerDict.ContainsKey (id)) 
			{
				IProtoHandler handler = protoHandlerDict [id];
				protoHandler = (ProtoHandler<T>) handler;
				if (protoHandler != null)
				{
					protoHandler.OnReceiveOnce -= callback;
				}
			}
		}


		/** 接受到服务器消息 */
		private void OnMsg(Msg msg)
		{
			int id = msg.GetMsgType ();
			if (protoHandlerDict.ContainsKey (id))
			{
				IProtoHandler handler = protoHandlerDict[id];
				handler.Handle (msg);
			}
		}


		/** 处理收到的消息 */
		private void ProcessMsg(Msg msg)
		{
			OnMsg (msg);

		}



	}


}
