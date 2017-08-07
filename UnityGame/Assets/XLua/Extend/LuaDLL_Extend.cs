namespace XLua.LuaDLL
{

    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using XLua;



    public partial class Lua
	{

		
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int luaopen_mime_core(IntPtr L);//[,,m]

		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int luaopen_rapidjson(System.IntPtr L);

		
		[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int luaopen_pb(System.IntPtr L);
    }
}
