using System;
using System.Collections.Generic;
using SimpleJSON;
using lxnet;

public class ShinezoneAccount
{
	public ShinezoneAccountEvent requestEvent = new ShinezoneAccountEvent ();
	
	/** 游戏ID */
	public string GameID { get; set;}

	/** 渠道名称 */
	public string Channel { get; set;}

	
	/// 用户习惯，喜好数据(例如上次登录的服务器id)。
	private JSONClass _habit = new JSONClass();
	
	/// 用户名
	private string _username = "";
	
	/// 密码
	private string _password = "";
	
	/// 服务器id
	private string _server_id = "";
	
	/// 所选的服务器ip
	private string _server_ip = "";
	
	/// 所选的服务器端口
	private int _server_port = 0;
	
	/// web的cookie
	private string _cookie = "";
	
	
	/// 当前请求
	private JSONClass _now_req = null;
	
	/// 请求根url
	private string _root_url = "";


	public ShinezoneAccount(string root_url, string gameId, string channel)
	{
		_root_url 	= root_url;
		GameID 		= gameId;
		Channel 	= channel;
	}
	
	
	/**
	 * 获取网关HTTP URL
	 * @return {string}
	 * */
	public string GetRootUrl()
	{
		return _root_url;
	}
	
	/**
	 * 设置网关HTTP URL
	 * @param {string} url
	 * */
	public void SetRootUrl(string url)
	{
		_root_url = url;
	}

	
	/**
	 * 获取用户名
	 * @return {string}
	 * */
	public string GetUserName()
	{
		return _username;
	}
	
	/**
	 * 设置用户名
	 * @param {string} username
	 * */
	public void SetUserName(string username)
	{
		_username = username;
	}
	
	/**
	 * 获取密码
	 * @return {string}
	 * */
	public string get_password()
	{
		return _password;
	}
	
	/**
	 * 设置密码
	 * @param {string} password
	 * */
	public void SetPassword(string password)
	{
		_password = password;
	}
	
	/**
	 * 获取上次服务器id
	 * @return {string}
	 * */
	public string GetLastServerID()
	{
		return GetHabitData ("_last_server_id_");
	}
	
	/**
	 * 设置上次服务器id
	 * @param {string} server_id
	 * */
	public void SetLastServerID(string server_id)
	{
		SetHabitData ("_last_server_id_", server_id);
	}
	
	/**
	 * 获取服务器id
	 * @return {string}
	 * */
	public string GetServerID()
	{
		return _server_id;
	}
	
	/**
	 * 获取服务器ip
	 * @return {string}
	 * */
	public string GetServerIP()
	{
		return _server_ip;
	}
	
	/**
	 * 获取服务器端口
	 * @return {int}
	 * */
	public int GetServerPort()
	{
		return _server_port;
	}
	
	/**
	 * 获取玩家数据
	 * @param {string} name 数据名
	 * @return {*}
	 * */
	public string GetHabitData(string name)
	{
		return _habit [name];
	}
	
	/**
	 * 设置玩家数据
	 * @param {string} name 数据名
	 * @param {*} data 数据
	 * */
	public void SetHabitData(string name, string data)
	{
		_habit [name] = data;
	}
	
	/**
	 * 注册
	 * @param {string} username 用户名
	 * @param {string} password 密码
	 * */
	public void Register(string username, string password)
	{
		_username = username;
		_password = password;
		
		JSONClass req = new JSONClass ();
		req["opcode"] = "register";
		
		JSONClass arg = new JSONClass ();
		arg ["username"] = username;
		arg ["password"] = lxnet_manager.Md5Sum (password);
		arg ["channel"] = Channel;
		arg ["game_id"] = GameID;
		
		req ["arg"] = arg;
		do_request (req);
	}
	
	/**
	 * 游客试玩
	 * @param {string} password 密码
	 * */
	public void Tourists(string password)
	{
		_password = password;
		
		JSONClass req = new JSONClass ();
		req ["opcode"] = "tourists";
		
		JSONClass arg = new JSONClass ();
		arg ["password"] = lxnet_manager.Md5Sum (password);
		arg ["channel"] = Channel;
		arg ["game_id"] = GameID;
		
		req ["arg"] = arg;
		do_request (req);
	}
	
	/**
	 * 登录
	 * @param {string} username 用户名
	 * @param {string} password 密码
	 * @param {boolean} reset_cookie 重置cookie，默认为false
	 * */
	public void Login(string username, string password, bool reset_cookie = false)
	{
		if (reset_cookie)
			_cookie = "";
		
		_username = username;
		_password = password;
		
		JSONClass req = new JSONClass ();
		req ["opcode"] = "login";
		
		JSONClass arg = new JSONClass ();
		arg ["username"] = username;
		arg ["password"] = lxnet_manager.Md5Sum (password);
		arg ["channel"] = Channel;
		arg ["game_id"] = GameID;
		
		req ["arg"] = arg;
		do_request (req);
	}
	
	/**
	 * 修改密码
	 * @param {string} new_password
	 * */
	public void ChangePassword(string new_password)
	{
		JSONClass req = new JSONClass ();
		req ["opcode"] = "change_pwd";
		
		JSONClass arg = new JSONClass ();
		arg ["new_password"] = lxnet_manager.Md5Sum (new_password);
		
		req ["arg"] = arg;
		do_request (req);
	}
	
	/**
	 * 修改用户名
	 * @param {string} new_username
	 * */
	public void ChangeUser(string new_username)
	{
		JSONClass req = new JSONClass ();
		req ["opcode"] = "change_user";
		
		JSONClass arg = new JSONClass ();
		arg ["new_username"] = new_username;
		
		req ["arg"] = arg;
		do_request (req);
	}
	
	/**
	 * 修改用户名和密码
	 * @param {string} new_username
	 * @param {string} new_password
	 * */
	public void ChangeUserPassword(string new_username, string new_password)
	{
		JSONClass req = new JSONClass ();
		req ["opcode"] = "change_user_pwd";
		
		JSONClass arg = new JSONClass ();
		arg ["new_username"] = new_username;
		arg ["new_password"] = lxnet_manager.Md5Sum (new_password);
		
		req ["arg"] = arg;
		do_request (req);
	}
	
	/**
	 * 获取服务器列表
	 * */
	public void ServerList()
	{
		JSONClass req = new JSONClass ();
		req ["opcode"] = "server_list";
		
		JSONClass arg = new JSONClass ();
		
		req ["arg"] = arg;
		do_request (req);
	}
	
	/**
	 * 进入指定服进行游戏
	 * @param {string} server_id 服务器id
	 * @param {string} ip 服务器ip
	 * @param {string} port 端口
	 * */
	public void EnterGame(string server_id, string ip, string port)
	{
		_server_id = server_id;
		_server_ip = ip;
		_server_port = int.Parse (port);
		
		JSONClass req = new JSONClass ();
		req ["opcode"] = "enter_game";
		
		JSONClass arg = new JSONClass ();
		arg ["server_id"] = server_id;
		arg ["random_a"] = RandomString.Generate (16);
		
		req ["arg"] = arg;
		do_request (req);
	}
	
	/**
	 * 领取礼包
	 * @param {int64} dbid 角色dbid
	 * @param {string} gift_code 礼包码
	 * */
	public void GetGift(Int64 dbid, string gift_code)
	{
		JSONClass req = new JSONClass ();
		req ["opcode"] = "use_gift";
		
		JSONClass arg = new JSONClass ();
		arg ["channel"] = Channel;
		arg ["game_id"] = GameID;
		arg ["server_id"] = _server_id;
		arg ["gift_code"] = gift_code;
		arg ["char_dbid"] = dbid.ToString();
		
		req ["arg"] = arg;
		do_request (req);
	}
	
	/**
	 * 充值
	 * @param {int64} dbid 角色dbid
	 * @param {int} rmb 充值指定金额
	 * */
	public void DoRecharge(Int64 dbid, int rmb)
	{
		JSONClass req = new JSONClass ();
		req ["opcode"] = "do_recharge";
		
		JSONClass arg = new JSONClass ();
		arg ["rmb"] = rmb.ToString();
		arg ["server_id"] = _server_id;
		arg ["char_dbid"] = dbid.ToString();
		
		req ["arg"] = arg;
		do_request (req);
	}
	
	
	
	
	
	
	
	////////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////////
	private void do_request(JSONClass reqobj)
	{
		_now_req = reqobj;
		HttpReqMgr.DoPost (_root_url, "req_data=" + reqobj.ToString (), _on_request_finish, _on_request_error, _cookie);
	}
	
	private void _on_request_finish(string url, byte[] userdata, string cookie)
	{
		if (_now_req == null)
		{
			Loger.LogError("why now req is null?");
			return;
		}
		
		string now_opcode = _now_req ["opcode"];
		
		/// 服务器列表压缩过。
		if (now_opcode == "server_list")
		{
			userdata = lxnet_manager.ZlibUnCompress(userdata);
		}
		
		JSONNode tmp = null;
		try
		{
			tmp = JSONNode.Parse(System.Text.Encoding.UTF8.GetString(userdata).TrimEnd ('\0'));
		}
		catch
		{
			tmp = null;
		}
		
		if (tmp == null)
		{
			Loger.LogError("json decode data error?");
			return;
		}
		
		if (tmp["opcode"] != null && !now_opcode.Equals(tmp ["opcode"]))
		{
			Loger.LogError("why request opcode as response opcode not equal");
			return;
		}
		
		_now_req = null;
		
		if (int.Parse(tmp["error_code"]) == 0)
		{
			_cookie = cookie;
		}
		
		requestEvent.OnRequestResult (tmp);
	}
	
	private void _on_request_error(string url, int httpcode)
	{
		requestEvent.OnRequestError (url, httpcode);
	}
	
}
