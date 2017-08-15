using System;
using lxnet;

public class ServerTime
{
	/** 初始化标记 */
	private static bool _isinit = false;

	/** 服务器当前utc时间，单位：秒 */
	private static Int64 _server_utc_sec_time = 0;

	/** 服务器当前utc时间，单位：毫秒 */
	private static Int64 _server_utc_mill_time = 0;

	/** 上次同步的时间，单位：毫秒 */
	private static Int64 _last_update_time = 0;

	public ServerTime ()
	{
	}

	public static void Init()
	{
		if (_isinit)
			return;

		_server_utc_sec_time = DateTime.Now.Second;
		_server_utc_mill_time = _server_utc_sec_time * 1000;
		_last_update_time = lxnet_manager.GetMilliSecond ();
		_isinit = true;
	}

	/**
	 * 获取当前服务器时间，单位：毫秒
	 * @return {Int64}
	 * */
	public static Int64 GetTime()
	{
		return _server_utc_mill_time;
	}

	/**
	 * 获取当前服务器时间，单位：秒
	 * @return {Int64}
	 * */
	public static Int64 GetUtcTime()
	{
		return _server_utc_sec_time;
	}

	/**
	 * 同步服务器时间
	 * @param {Int64} utctime 当前服务器utc时间，单位：秒
	 * */
	public static void UpdateServerTime(Int64 utctime)
	{
		if (utctime < 0)
		{
			Loger.LogError ("on update server time, but time value error!");
			return;
		}

		_server_utc_sec_time = utctime;
		_server_utc_mill_time = utctime * 1000;
		_last_update_time = lxnet_manager.GetMilliSecond ();
	}

	public static void Run(Int64 currenttime)
	{
		Int64 delay = currenttime - _last_update_time;
		if (delay > 0)
		{
			_server_utc_mill_time = _server_utc_mill_time + delay;
			_server_utc_sec_time = _server_utc_mill_time / 1000;
			_last_update_time = currenttime;
		}

	}
}
