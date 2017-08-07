
namespace XLua
{
	using System;
	using System.Collections.Generic;
	using System.Reflection;
	
	public partial class LuaEnv
	{
		private void AddBuildinsExtend()
		{
			AddBuildin("rapidjson", StaticLuaCallbacks.LoadRapidJson);
			AddBuildin("pb", StaticLuaCallbacks.LoadProtoBuf);
			AddBuildin("mime.core", StaticLuaCallbacks.LoadMimeCore);
		}
	}
}
