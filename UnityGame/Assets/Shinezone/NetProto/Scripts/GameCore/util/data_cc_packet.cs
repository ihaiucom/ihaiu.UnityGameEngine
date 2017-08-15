using lxnet;
using System.Text;


/// 数据压缩编码打包(data compress coding pack)
public class data_cc_packet
{


	/**
	 * 数据打包处理
	 * @param {string} str 数据
	 * @return {string}
	 * */
	public static string pack_string(string str)
	{
		byte[] tmp = Encoding.UTF8.GetBytes (str);
		byte[] ret = lxnet_manager.QuicklzCompress (tmp);
		return lxnet_manager.Base64Encode (ret);
	}

	/**
	 * 数据解包处理
	 * @param {string} str 源数据
	 * @return {string}
	 * */
	public static string unpack_string(string str)
	{
		byte[] tmp = lxnet_manager.Base64Decode (str);
		byte[] ret = lxnet_manager.QuicklzUnCompress(tmp);
		return Encoding.UTF8.GetString(ret);
	}

}
