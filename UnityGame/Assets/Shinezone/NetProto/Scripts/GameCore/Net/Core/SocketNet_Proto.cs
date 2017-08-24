using System.IO;

namespace lxnet
{
	using System;
	using System.Collections.Generic;

	public partial class SocketNet
	{


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






		/** 接受到服务器消息 */
		private void OnMsg(int id, Msg msg)
		{
			if (id == 1)
				return;
			
			IProtoItem item = ProtoC.GetItemByOpcode (id);
			if (item != null)
			{
				byte[] 	bytes 	= msg.GetMsgBodyBytes ();
				MemoryStream stream = new MemoryStream (bytes);

				item.Handle (stream);
			}
		}


		/** 处理收到的消息 */
		private void ProcessMsg(Msg msg)
		{
			int id = msg.GetMsgType ();
			if (id != 1) 
			{
				IProtoItem item = ProtoC.GetItemByOpcode (id);
				string note = item != null ?  item.ToString() : "";

				Loger.LogTag ("SocketNet", "<= " + msg.GetMsgType () + " " + note);
			}
			
			OnMsg (id, msg);
			ShinezoneNetProtoLua.ProcessMsg (msg);
		}



	}


}
