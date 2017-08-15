namespace lxnet
{
	using System;
	using System.Text;

	class TmpBuf
	{
		public static byte[] _buf = new byte[1024 * 136];
	}

	public class lxnet_manager
	{

		/**
		 * 获取当前毫秒时间戳
		 * @return {int64}
		 * */
		public static Int64 GetMilliSecond()
		{
			return LXNetDLL.cs_get_millisecond();
		}

		/**
		 * 获取当前微秒时间戳
		 * @return {int64}
		 * */
		public static Int64 GetMicroSecond()
		{
			return LXNetDLL.cs_get_microsecond ();
		}

		/**
		 * 计算md5
		 * */
		public static string Md5Sum(string value)
		{
			byte[] data = Encoding.UTF8.GetBytes (value);
			byte[] buf = new byte[64];
			LXNetDLL.cs_md5_sum (data, data.Length, buf, buf.Length);
			return Encoding.UTF8.GetString (buf).TrimEnd ('\0');
		}

		/**
		 * base64编码
		 * */
		public static string Base64Encode(byte[] data)
		{
			int out_len = 0;
			if (!LXNetDLL.cs_base64_encode(data, data.Length, TmpBuf._buf, TmpBuf._buf.Length, out out_len))
				return string.Empty;

			//切记要复制出来！
			byte[] ret = new byte[out_len];
			Buffer.BlockCopy (TmpBuf._buf, 0, ret, 0, out_len);
			return Encoding.UTF8.GetString (ret).TrimEnd ('\0');
		}

		/**
		 * base64解码
		 * */
		public static byte[] Base64Decode(string value)
		{
			int out_len = 0;
			byte[] data = Encoding.UTF8.GetBytes (value);
			if (!LXNetDLL.cs_base64_decode (data, data.Length, TmpBuf._buf, TmpBuf._buf.Length, out out_len))
				return null;

			byte[] ret = new byte[out_len];
			Buffer.BlockCopy (TmpBuf._buf, 0, ret, 0, out_len);
			return ret;
		}

		/**
		 * zlib压缩
		 * */
		public static byte[] ZlibCompress(byte[] data)
		{
			int out_len = 0;
			if (!LXNetDLL.cs_zlib_compress (data, data.Length, TmpBuf._buf, TmpBuf._buf.Length, out out_len))
				return null;

			byte[] ret = new byte[out_len];
			Buffer.BlockCopy (TmpBuf._buf, 0, ret, 0, out_len);
			return ret;
		}

		/**
		 * zlib解压缩
		 * */
		public static byte[] ZlibUnCompress(byte[] data)
		{
			int out_len = 0;
			if (!LXNetDLL.cs_zlib_uncompress (data, data.Length, TmpBuf._buf, TmpBuf._buf.Length, out out_len))
				return null;

			byte[] ret = new byte[out_len];
			Buffer.BlockCopy (TmpBuf._buf, 0, ret, 0, out_len);
			return ret;
		}

		/**
		 * quicklz压缩
		 * */
		public static byte[] QuicklzCompress(byte[] data)
		{
			int out_len = 0;
			if (!LXNetDLL.cs_quicklz_compress (data, data.Length, TmpBuf._buf, TmpBuf._buf.Length, out out_len))
				return null;

			byte[] ret = new byte[out_len];
			Buffer.BlockCopy (TmpBuf._buf, 0, ret, 0, out_len);
			return ret;
		}

		/**
		 * quicklz解压缩
		 * */
		public static byte[] QuicklzUnCompress(byte[] data)
		{
			int out_len = 0;
			if (!LXNetDLL.cs_quicklz_uncompress (data, data.Length, TmpBuf._buf, TmpBuf._buf.Length, out out_len))
				return null;

			byte[] ret = new byte[out_len];
			Buffer.BlockCopy (TmpBuf._buf, 0, ret, 0, out_len);
			return ret;
		}




		/**
		 * 初始化网络
		 * bigbufsize 指定大块的大小，bigbufnum指定大块的数目，
		 * smallbufsize 指定小块的大小，smallbufnum指定小块的数目
		 * listen num 指定用于监听的套接字的数目，socket num用于连接的总数目
		 */
		public static bool Init(int bigbufsize, int bigbufnum, int smallbufsize, int smallbufnum, 
								int listenernum, int socketnum)
		{
			bool res = LXNetDLL.cs_lxnet_init (bigbufsize, bigbufnum, smallbufsize, smallbufnum, listenernum, socketnum);
			LXNetDLL.cs_enet_manager_init ();
			return res;
		}

		/** 释放网络相关 */
		public static void Release()
		{
			LXNetDLL.cs_lxnet_release ();
			LXNetDLL.cs_enet_manager_release ();
		}

		/** 执行相关操作，需要在主逻辑中调用此函数 */
		public static void Run()
		{
			LXNetDLL.cs_lxnet_run ();
		}

		/** 获取socket对象池，listen对象池，大块池，小块池的使用情况 */
		public static string GetMemoryInfo()
		{
			LXNetDLL.cs_lxnet_get_memory_info (TmpBuf._buf, TmpBuf._buf.Length);
			return Encoding.UTF8.GetString (TmpBuf._buf).TrimEnd ('\0');
		}

		/** 获取网络数据统计信息 */
		public static string GetNetDataAllInfo()
		{
			LXNetDLL.cs_lxnet_get_netdata_allinfo (TmpBuf._buf, TmpBuf._buf.Length);
			return Encoding.UTF8.GetString (TmpBuf._buf).TrimEnd ('\0');
		}


		/** 启用/禁用接受的连接导致的错误日志，并返回之前的值 */
		public static bool SetEnableErrorLog(bool flag)
		{
			return LXNetDLL.cs_lxnet_set_enable_errorlog (flag);
		}

		/** 获取当前启用或禁用接受的连接导致的错误日志 */
		public static bool GetEnableErrorLog()
		{
			return LXNetDLL.cs_lxnet_get_enable_errorlog ();
		}

		/** 根据域名获取ip地址 */
		public static string GetHostIPByName(string hostname, bool ipv6 = false)
		{
			LXNetDLL.cs_lxnet_get_host_ip_by_name (TmpBuf._buf, TmpBuf._buf.Length, hostname, ipv6);
			return Encoding.UTF8.GetString (TmpBuf._buf).TrimEnd ('\0');
		}




		/** 设置日志根目录 */
		public static bool LogSetDirectory (string directory)
		{
			return LXNetDLL.cs_log_set_directory (directory);
		}

		/** 获取日志根目录 */
		public static string LogGetDirectory ()
		{
			int out_len = 0;
			if (!LXNetDLL.cs_log_get_directory(TmpBuf._buf, TmpBuf._buf.Length, out out_len))
				return String.Empty;

			//切记要复制出来！
			byte[] ret = new byte[out_len];
			Buffer.BlockCopy (TmpBuf._buf, 0, ret, 0, out_len);
			return Encoding.UTF8.GetString (ret).TrimEnd ('\0');
		}

		/** 启用/禁用 附加时间 */
		public static bool LogAppendTime (bool flag)
		{
			return LXNetDLL.cs_log_append_time (flag);
		}

		/** 启用/禁用 立即刷新 */
		public static bool LogEveryFlush (bool flag)
		{
			return LXNetDLL.cs_log_every_flush (flag);
		}

		/** 写日志 */
		public static void LogWriteLog (string str)
		{
			LXNetDLL.cs_log_writelog (str);
		}

		/** 写错误日志 */
		public static void LogError (string str)
		{
			LXNetDLL.cs_log_error (str, "", "", 0);
		}

		/** 递归创建目录 */
		public static bool MkDir (string dirname)
		{
			return LXNetDLL.cs_mkdir (dirname);
		}

		/** 递归删除目录 */
		public static void RmDir (string dirname)
		{
			LXNetDLL.cs_rmdir (dirname);
		}

		/** 递归复制目录到指定位置 */
		public static bool CopyDir (string from, string to)
		{
			return LXNetDLL.cs_copy (from, to);
		}

		/** 解压缩指定压缩包中的指定文件到指定位置 */
		public static bool ZipFileUnZipTheFileTo (string zip_path, string inzipfile, string outpath)
		{
			return LXNetDLL.cs_zipfile_unzip_the_file_to (zip_path, inzipfile, outpath);
		}



		/** 输出控制台日志 */
		public static bool PrintConsoleLog (string str)
		{
#if UNITY_STANDALONE_WIN
			return LXNetDLL.cs_console_log (str + "\n", false);
#else
			return true;
#endif
		}

		/** 输出控制台错误 */
		public static bool PrintConsoleError (string str)
		{
#if UNITY_STANDALONE_WIN
			return LXNetDLL.cs_console_log (str + "\n", true);
#else
			return true;
#endif
		}

		/** 是否是windows */
		public static bool IsWindows()
		{
#if UNITY_STANDALONE_WIN
			return true;
#else
			return false;
#endif
		}
	}


	public class Socketer
	{

		IntPtr _l;
		bool _is_tcp;

		bool _use_seq;
		int _seq_id;

		bool _udp_already_do_connect;
		bool _udp_connected;
		bool _udp_is_close;
		bool _has_new_msg;

		public Socketer ()
		{
			_l = IntPtr.Zero;
			_is_tcp = true;

			_use_seq = false;
			_seq_id = 0;

			_udp_already_do_connect = false;
			_udp_connected = false;
			_udp_is_close = false;
			_has_new_msg = false;
		}

		~Socketer()
		{
			ResetAll();
		}

		private void ResetAll()
		{
			if (_l == IntPtr.Zero)
				return;

			if (_is_tcp)
				LXNetDLL.cs_socketer_release (_l);
			else
				LXNetDLL.cs_enet_release (_l);

			_l = IntPtr.Zero;
		}

		private void CheckTcp()
		{
			if (_l == IntPtr.Zero)
			{
				_l = LXNetDLL.cs_socketer_create (false);
			}
		}

		private void CheckUdp()
		{
			if (_l == IntPtr.Zero)
			{
				_l = LXNetDLL.cs_enet_create (0, 0);
			}
		}

		/** 获取下一个消息序号 */
		private Int16 GetNextSeqID()
		{
			_seq_id = _seq_id + 1;
			if (_seq_id > 32767)
				_seq_id = 1;

			return (Int16)_seq_id;
		}

		//检测事件，等待新消息
		//		(只等一个消息 - 等到消息后，必须调用GetMsg取出，否则消息会被新消息覆盖)
		private bool check_event_for_new_message()
		{
			while (true) {
				int ret = LXNetDLL.cs_enet_check_event (_l);
				if (ret == 1)
				{
					//连接成功
					_udp_connected = true;
				}
				else if (ret == 2)
				{
					//断开连接
					_udp_is_close = true;
				}
				else if (ret == 3)
				{
					//收到消息，跳出(GetMsg可得到此事件的消息)
					_has_new_msg = true;
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		/** 释放 */
		public void Release()
		{
			ResetAll();
		}

		/** 检测初始化 */
		public void CheckInit(bool is_tcp)
		{
			if (_is_tcp != is_tcp)
				ResetAll();

			_is_tcp = is_tcp;

			if (_is_tcp)
				CheckTcp();
			else
				CheckUdp();
		}

		/** 启用/禁用消息序号 */
		public void UseMsgSeq(bool flag)
		{
			_use_seq = flag;
		}

		/** (对发送数据起作用)设置启用压缩，若要启用压缩，则此函数在创建socket对象后即刻调用 */
		public void UseCompress()
		{
			if (_is_tcp)
				LXNetDLL.cs_socketer_use_compress (_l);
		}

		/** (慎用)(对接收的数据起作用)启用解压缩，网络库会负责解压缩操作，仅供客户端使用 */
		public void UseUncompress()
		{
			if (_is_tcp)
				LXNetDLL.cs_socketer_use_uncompress (_l);
		}

		/** 设置加密key */
		public void SetEncryptKey(byte[] key)
		{
			if (_is_tcp)
				LXNetDLL.cs_socketer_set_encrypt_key (_l, key, key.Length);
		}

		/** 设置解密key */
		public void SetDecryptKey(byte[] key)
		{
			if (_is_tcp)
				LXNetDLL.cs_socketer_set_decrypt_key (_l, key, key.Length);
		}

		/** (启用加密) */
		public void UseEncrypt()
		{
			if (_is_tcp)
				LXNetDLL.cs_socketer_use_encrypt (_l);
		}

		/** (启用解密) */
		public void UseDecrypt()
		{
			if (_is_tcp)
				LXNetDLL.cs_socketer_use_decrypt (_l);
		}

		/**
		 * 设置udp超时时间
		 * @param {int} timeout_limit 超时临界，单位：秒，默认：32
		 * @param {int} timeout_minimum 超时最小值，单位：毫秒，默认：5000
		 * @param {int} timeout_maximum 超时最大值，单位：毫秒，默认：30000
		 */
		public void SetUdpTimeout(int timeout_limit, int timeout_minimum, int timeout_maximum)
		{
			if (_is_tcp)
				return;

			LXNetDLL.cs_enet_set_timeout (_l, timeout_limit, timeout_minimum, timeout_maximum);
		}

		/** 连接指定的服务器 */
		public bool Connect(string ip, int port)
		{
			if (_is_tcp)
			{
				return LXNetDLL.cs_socketer_connect (_l, ip, port);
			}
			else
			{
				if (_udp_already_do_connect)
					return _udp_connected;

				if (LXNetDLL.cs_enet_connect (_l, ip, port))
				{
					_udp_already_do_connect = true;
				}
				return false;
			}
		}

		/** 关闭用于连接的socket对象 */
		public void Close()
		{
			if (_is_tcp)
			{
				LXNetDLL.cs_socketer_close (_l);
			}
			else
			{
				LXNetDLL.cs_enet_close (_l);
				_udp_is_close = true;
			}
		}

		/** 测试socket套接字是否已关闭 */
		public bool IsClose()
		{
			if (_is_tcp)
				return LXNetDLL.cs_socketer_is_close (_l);
			else
				return _udp_is_close;
		}

		/** 发送TGW信息头 */
		public bool SendTGWInfo(string domain, int port)
		{
			if (!_is_tcp)
				return false;

			return LXNetDLL.cs_socketer_send_tgw_info (_l, domain, port);
		}

		/**
	 	* 发送数据，仅仅是把数据压入包队列中，
	 	* adddata为附加到pMsg后面的数据，当然会自动修改pMsg的长度，addsize指定adddata的长度
	 	*/
		public bool SendMsg(Msg pMsg)
		{
			int len = pMsg.GetLength ();
			if (_use_seq)
			{
				pMsg.PushInt16 (GetNextSeqID ());
			}

			pMsg._CallForSend ();

			bool res = false;
			if (_is_tcp)
				res = LXNetDLL.cs_socketer_send_msg (_l, pMsg.GetRawByteArray (), pMsg.GetLength ());
			else
				res = LXNetDLL.cs_enet_send_msg (_l, pMsg.GetRawByteArray (), pMsg.GetLength ());

			pMsg.SetLength (len);
			return res;
		}

		/** 接收数据 */
		public Msg GetMsg()
		{
			int out_len = 0;
			int ret = 0;
			if (_is_tcp)
			{
				ret = LXNetDLL.cs_socketer_get_msg (_l, TmpBuf._buf, TmpBuf._buf.Length, out out_len);
			}
			else
			{
				if (!_has_new_msg)
				{
					check_event_for_new_message();
				}

				ret = LXNetDLL.cs_enet_get_msg (_l, TmpBuf._buf, TmpBuf._buf.Length, out out_len);
				_has_new_msg = false;
			}

			if (ret > 0)
			{
				Msg newmsg = new Msg();
				newmsg._CallOnRecv(TmpBuf._buf, out_len);
				newmsg.Begin();
				return newmsg;
			}

			if (ret < 0)
			{
				UnityEngine.Debug.Log("NetWork GetMsg Error!");
			}

			return null;
		}

		/** 发送数据 */
		public bool SendData(byte[] data)
		{
			if (!_is_tcp)
				return false;

			return LXNetDLL.cs_socketer_send_data (_l, data, data.Length);
		}

		/** 接收数据 */
		public byte[] GetData()
		{
			if (!_is_tcp)
				return null;

			int out_len = 0;
			int ret = LXNetDLL.cs_socketer_get_data (_l, 
							1024 * 16, TmpBuf._buf, TmpBuf._buf.Length, out out_len);
			if (ret > 0)
			{
				byte[] newdata = new byte[out_len];
				Buffer.BlockCopy(TmpBuf._buf, 0, newdata, 0, out_len);
				return newdata;
			}

			if (ret < 0)
			{
				UnityEngine.Debug.Log ("NetWork GetData Error!");
			}

			return null;
		}

		/** 每帧run */
		public void RunOnce()
		{
			if (_is_tcp)
				return;

			LXNetDLL.cs_enet_event_loop (_l, 0);

			check_event_for_new_message();
		}

		/** 每帧run完毕时 */
		public void RunOnceEnd()
		{
			if (_is_tcp)
				return;

			LXNetDLL.cs_enet_flush (_l);
		}

		/** 触发真正的发送数据 */
		public void CheckSend()
		{
			if (_is_tcp)
				LXNetDLL.cs_socketer_check_send (_l);
		}

		/** 尝试投递接收操作 */
		public void CheckRecv()
		{
			if (_is_tcp)
				LXNetDLL.cs_socketer_check_recv (_l);
		}
	}
}

