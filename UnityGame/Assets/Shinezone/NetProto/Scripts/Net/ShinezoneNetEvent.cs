using System;
using System.Collections.Generic;


public class ShinezoneNetEventName
{


	public static string on_connecting_to_server 				= "on_connecting_to_server";
	public static string on_connect_error_or_server_not_open 	= "on_connect_error_or_server_not_open";
	public static string on_connected_to_server 				= "on_connected_to_server";
	public static string on_authing_as_server 					= "on_authing_as_server";
	public static string on_auth_succeed 						= "on_auth_succeed";
	public static string on_auth_failed 						= "on_auth_failed";
	public static string on_version_not_match 					= "on_version_not_match";
	public static string on_system_busy 						= "on_system_busy";
	public static string on_need_restart_do_web_auth 			= "on_need_restart_do_web_auth";
	public static string on_channel_error 						= "on_channel_error";
	public static string on_account_in_other_local_login 		= "on_account_in_other_local_login";
	public static string on_rpc_request 						= "on_rpc_request";
	public static string on_rpc_response 						= "on_rpc_response";
	
}

public class ShinezoneNetEvent
{
	/// 服务器：提示一则信息 int id, string msg
	public event Action<int, string> onHintMessage;

	/// 服务器：告知客户端角色列表
	public event Action onRecvCharlist;

	/// 服务器：告知客户端增加角色信息到角色列表
	public event Action onCreateCharSucceed;
	
	/// 服务器：告知客户端移除指定的角色
	public event Action<Int64> onDeleteCharSucceed;
	
	
	/// 服务器：告知客户端当前账号存在正在游戏的角色，目前只能使用此正在角色的游戏进行游戏
	public event Action<Int64> onCccountHasGameingCharOnlyUseIt;
	
	/// 服务器：告知客户端加载必须数据，等待服务器加载角色详细数据
	public event Action onTellClientLoadData;


	/// 服务器：告知客户端角色详细数据
	public event Action onTellCcharData;
	
	
	/// 服务器：告知客户端增加角色元宝
	public event Action<Int64> onTellClientAddGold;

	/// 服务器：告知客户端减少角色元宝
	public event Action<Int64> onTellClientDecGold;
	
	
	/// 服务器：告知客户端增加角色金钱
	public event Action<Int64> onTellClientAddMoney;

	/// 服务器：告知客户端减少角色金钱
	public event Action<Int64> onTellClientDecMoney;



	
	///////////////////////////////////////////////


	/// 当正在连接服务器时
	public event Action<object> onConnectingToServer;

	/// 网络连接错误或服务器未开启
	public event Action<object> onConnectErrorOrServerNotOpen;

	/// 当连接到服务器时
	public event Action<object> onConnectedToServer;

	/// 正在认证时
	public event Action<bool> onAuthingAsServer;

	/// 认证成功时
	public event Action<bool> onAuthSucceed;

	/// 认证失败时
	public event Action<object> onAuthFailed;

	/// 版本不匹配时
	public event Action<object> onVersionNotMatch;

	/// 系统忙，请稍后再试
	public event Action<object> onSystemBusy;

	/// 请重新进行web登录流程(短链接认证无法进行)
	public event Action<object> onNeedRestartDoWebAuth;

	/// 渠道错误
	public event Action<object> onChannelError;

	/// 账号在别处登录
	public event Action<object> onAccountInOtherLocalLogin;

	/// 当发送RPC请求时
	public event Action<object> onRpcRequest;

	/// 当收到rpc回应时
	public event Action<object> onRpcResponse;

	public Dictionary<string, Action<object>> dict ;


	public ShinezoneNetEvent()
	{
		dict = new Dictionary<string, Action<object>> ();
		dict.Add (ShinezoneNetEventName.on_connecting_to_server				, on_connecting_to_server);
		dict.Add (ShinezoneNetEventName.on_connect_error_or_server_not_open	, on_connect_error_or_server_not_open);
		dict.Add (ShinezoneNetEventName.on_connected_to_server				, on_connected_to_server);
		dict.Add (ShinezoneNetEventName.on_authing_as_server				, on_authing_as_server);
		dict.Add (ShinezoneNetEventName.on_auth_succeed						, on_auth_succeed);
		dict.Add (ShinezoneNetEventName.on_auth_failed						, on_auth_failed);
		dict.Add (ShinezoneNetEventName.on_version_not_match				, on_version_not_match);
		dict.Add (ShinezoneNetEventName.on_system_busy						, on_system_busy);
		dict.Add (ShinezoneNetEventName.on_need_restart_do_web_auth			, on_need_restart_do_web_auth);
		dict.Add (ShinezoneNetEventName.on_channel_error					, on_channel_error);
		dict.Add (ShinezoneNetEventName.on_account_in_other_local_login		, on_account_in_other_local_login);
		dict.Add (ShinezoneNetEventName.on_rpc_request						, on_rpc_request);
		dict.Add (ShinezoneNetEventName.on_rpc_response						, on_rpc_response);
	}


	/// 服务器：提示一则信息 
	public void CallHintMessage(int id, string msg)
	{
		if(onHintMessage != null) 
			onHintMessage (id, msg);
	}
	
	/// 服务器：告知客户端角色列表
	public void CallRecvCharlist()
	{
		if(onRecvCharlist != null)
			onRecvCharlist ();
	}
	
	/// 服务器：告知客户端增加角色信息到角色列表
	public void CallCreateCharSucceed()
	{
		if(onCreateCharSucceed != null) 
			onCreateCharSucceed();
	}
	
	/// 服务器：告知客户端移除指定的角色
	public void CallDeleteCharSucceed(Int64 id)
	{
		if(onDeleteCharSucceed != null)
			onDeleteCharSucceed(id);
	}
	
	
	/// 服务器：告知客户端当前账号存在正在游戏的角色，目前只能使用此正在角色的游戏进行游戏
	public void CallCccountHasGameingCharOnlyUseIt(Int64 id)
	{
		if(onCccountHasGameingCharOnlyUseIt != null)
			onCccountHasGameingCharOnlyUseIt(id);
	}
	
	/// 服务器：告知客户端加载必须数据，等待服务器加载角色详细数据
	public void CallTellClientLoadData()
	{
		if(onTellClientLoadData != null)
			onTellClientLoadData ();
	}
	
	
	/// 服务器：告知客户端角色详细数据
	public void CallTellCcharData()
	{
		if(onTellCcharData != null)
			onTellCcharData();
	}
	
	
	/// 服务器：告知客户端增加角色元宝
	public void CallTellClientAddGold(Int64 addGold)
	{
		if(onTellClientAddGold != null)
			onTellClientAddGold (addGold);
	}
	
	/// 服务器：告知客户端减少角色元宝
	public void CallTellClientDecGold(Int64 decGold)
	{
		if(onTellClientDecGold != null)
			onTellClientDecGold (decGold);
	}
	
	
	/// 服务器：告知客户端增加角色金钱
	public void CallTellClientAddMoney(Int64 addMoney)
	{
		if(onTellClientAddMoney != null)
			onTellClientAddMoney(addMoney);
	}
	
	/// 服务器：告知客户端减少角色金钱
	public void CallTellClientDecMoney(Int64 decMoney)
	{
		if(onTellClientDecMoney != null)
			onTellClientDecMoney(decMoney);
	}

	///////////////////////////////////////////////

	/// 当正在连接服务器时
	protected virtual void  on_connecting_to_server(object arg)
	{
		Loger.Log("on_connecting_to_server");
		
		if(onConnectingToServer != null)
			onConnectingToServer (arg);
	}

	/// 网络连接错误或服务器未开启
	protected virtual void on_connect_error_or_server_not_open(object arg)
	{
		Loger.Log ("on_connect_error_or_server_not_open");
		if(onConnectErrorOrServerNotOpen != null)
			onConnectErrorOrServerNotOpen (arg);
	}

	/// 当连接到服务器时
	protected virtual void on_connected_to_server(object arg)
	{
		Loger.Log ("on_connected_to_server");
		if(onConnectedToServer != null)
			onConnectedToServer (arg);
	}

	/// 正在认证时
	protected virtual void on_authing_as_server(object arg)
	{
		bool short_link = (bool)arg;
		Loger.Log ("on_authing_as_server, is short link:" + short_link);
		if(onAuthingAsServer != null)
			onAuthingAsServer (short_link);
	}

	/// 认证成功时
	protected virtual void on_auth_succeed(object arg)
	{
		bool short_link = (bool)arg;
		Loger.Log ("on_auth_succeed, is short link:" + short_link);

		if (short_link)
		{
			/// 显示认证成功，此时准备进入游戏
		}
		
		if(onAuthSucceed != null)
			onAuthSucceed (short_link);
	}

	/// 认证失败时
	protected virtual void on_auth_failed(object arg)
	{
		Loger.Log ("on_auth_failed");
		if(onAuthFailed != null)
			onAuthFailed (arg);
	}

	/// 版本不匹配时
	protected virtual void on_version_not_match(object arg)
	{
		Loger.Log ("on_version_not_match");
		if(onVersionNotMatch != null)
			onVersionNotMatch (arg);
	}

	/// 系统忙，请稍后再试
	protected virtual void on_system_busy(object arg)
	{
		Loger.Log ("on_system_busy");
		
		if(onSystemBusy != null)
			onSystemBusy (arg);
	}

	/// 请重新进行web登录流程(短链接认证无法进行)
	protected virtual void on_need_restart_do_web_auth(object arg)
	{
		Loger.Log ("on_need_restart_do_web_auth");
		
		if(onNeedRestartDoWebAuth != null)
			onNeedRestartDoWebAuth (arg);

	}

	/// 渠道错误
	protected virtual void on_channel_error(object arg)
	{
		Loger.Log("on_channel_error");
		
		if(onChannelError != null)
			onChannelError (arg);
	}

	/// 账号在别处登录
	protected virtual void on_account_in_other_local_login(object arg)
	{
		Loger.Log ("on_account_in_other_local_login");
		
		if(onAccountInOtherLocalLogin != null)
			onAccountInOtherLocalLogin (arg);
	}

	/// 当发送RPC请求时
	protected virtual void on_rpc_request(object arg)
	{
		Loger.Log ("on_rpc_request");
		onRpcRequest (arg);
	}

	/// 当收到rpc回应时
	protected virtual void on_rpc_response(object arg)
	{
		Loger.Log("on_rpc_response");
		onRpcResponse (arg);
	}
}

