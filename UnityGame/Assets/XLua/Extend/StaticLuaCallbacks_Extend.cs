
#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

namespace XLua
{
	using System;
	using System.IO;
	using System.Reflection;
	
	public partial class StaticLuaCallbacks
	{
		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int LoadRapidJson(RealStatePtr L)
		{
			return LuaAPI.luaopen_rapidjson(L);
		}
		
		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int LoadProtoBuf(RealStatePtr L)
		{
			return LuaAPI.luaopen_pb(L);
		}
		
		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int LoadMimeCore(IntPtr L)
		{
			return LuaAPI.luaopen_mime_core(L);
		}
	}
}