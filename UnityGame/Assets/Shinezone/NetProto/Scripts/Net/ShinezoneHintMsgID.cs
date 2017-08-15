using System;
using System.Collections.Generic;

public class ShinezoneHintMsgID
{
	
	private static Dictionary<int, string> msgs;
	public static Dictionary<int, string> Msgs
	{
		get
		{
			if(msgs == null)
			{
				msgs = new Dictionary<int, string>();
				msgs[1] = "角色名已存在！";
				msgs[2] = "服务器繁忙，请稍后再试";
				msgs[3] = "名字服未开启，请联系gm";
				msgs[4] = "名字非法";
				msgs[5] = "服务器爆满";
				msgs[6] = "系统错误，请联系客服";
			}

			return msgs;
		}
	}

	public static string GetMsg(int id)
	{
		if (Msgs.ContainsKey (id)) 
		{
			return Msgs[id];
		}
		return "未知错误 msgId=" + id;
	}
}

