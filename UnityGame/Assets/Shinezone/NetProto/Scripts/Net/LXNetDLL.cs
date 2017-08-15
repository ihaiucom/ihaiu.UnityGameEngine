namespace lxnet
{
	using System;
	using System.Runtime.InteropServices;
	using System.Reflection;
	using System.Collections;
	using System.Security;

	class LXNetDLL
	{
#if UNITY_IPHONE && !UNITY_EDITOR
		const string LXNET_DLL = "__Internal";
#else
		const string LXNET_DLL = "xlua";
#endif


		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void init_plugins_wrap_api(IntPtr luaState);



		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern Int64 cs_get_millisecond();

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern Int64 cs_get_microsecond();

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_md5_sum(byte[] data, int datalen, byte[] buf, int buflen);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_base64_encode(byte[] data, int datalen, byte[] buf, int buflen, out int out_len);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_base64_decode(byte[] data, int datalen, byte[] buf, int buflen, out int out_len);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_zlib_compress(byte[] data, int datalen, byte[] buf, int buflen, out int out_len);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_zlib_uncompress(byte[] data, int datalen, byte[] buf, int buflen, out int out_len);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_quicklz_compress(byte[] data, int datalen, byte[] buf, int buflen, out int out_len);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_quicklz_uncompress(byte[] data, int datalen, byte[] buf, int buflen, out int out_len);



		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_lxnet_init(int bigbufsize, int bigbufnum, 
												int smallbufsize, int smallbufnum, int listenernum, int socketnum);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void cs_lxnet_release();

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void cs_lxnet_run();

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_lxnet_get_memory_info(byte[] buf, int buflen);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_lxnet_get_netdata_allinfo(byte[] buf, int buflen);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_lxnet_set_enable_errorlog(bool flag);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_lxnet_get_enable_errorlog();

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_lxnet_get_host_ip_by_name(byte[] buf, int buflen, string yuming, bool ipv6);



		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr cs_socketer_create(bool bigbuf);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void cs_socketer_release(IntPtr obj);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void cs_socketer_use_compress(IntPtr obj);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void cs_socketer_use_uncompress(IntPtr obj);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void cs_socketer_use_encrypt(IntPtr obj);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void cs_socketer_use_decrypt(IntPtr obj);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void cs_socketer_set_encrypt_key(IntPtr obj, byte[] key, int keylen);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void cs_socketer_set_decrypt_key(IntPtr obj, byte[] key, int keylen);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_socketer_connect(IntPtr obj, string ip, int port);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void cs_socketer_close(IntPtr obj);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_socketer_is_close(IntPtr obj);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_socketer_get_ip(IntPtr obj, byte[] buf, int buflen);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_socketer_send_tgw_info(IntPtr obj, string domain, int port);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_socketer_send_msg(IntPtr obj, byte[] data, int len);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int cs_socketer_get_msg(IntPtr obj, byte[] buf, int buflen, out int out_len);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_socketer_send_data(IntPtr obj, byte[] data, int len);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int cs_socketer_get_data(IntPtr obj, int limitsize, byte[] buf, int buflen, out int out_len);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void cs_socketer_check_send(IntPtr obj);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void cs_socketer_check_recv(IntPtr obj);



		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_enet_manager_init();

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void cs_enet_manager_release();


		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr cs_enet_create(int incomingBandwidth, int outgoingBandwidth);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void cs_enet_release(IntPtr obj);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void cs_enet_set_timeout(IntPtr obj, int timeout_limit, int timeout_minimum, int timeout_maximum);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_enet_connect(IntPtr obj, string ip, int port);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void cs_enet_close(IntPtr obj);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void cs_enet_event_loop(IntPtr obj, int wait_event_timeout);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int cs_enet_check_event(IntPtr obj);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void cs_enet_flush(IntPtr obj);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_enet_send_msg(IntPtr obj, byte[] data, int len);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int cs_enet_get_msg(IntPtr obj, byte[] buf, int buflen, out int out_len);



		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_log_set_directory (string directory);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_log_get_directory (byte[] buf, int buflen, out int out_len);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_log_append_time (bool flag);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_log_every_flush (bool flag);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void cs_log_writelog (string str);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void cs_log_error (string str, string filename, string func, int line);



		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_mkdir (string dirname);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void cs_rmdir (string dirname);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_copy (string from, string to);

		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_zipfile_unzip_the_file_to (string zip_path, string inzipfile, string outpath);



		[DllImport(LXNET_DLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool cs_console_log (string str, bool error);
	}
}
