using SimpleJSON;
using System;

public class ShinezoneLogin
{
	public static int PANEL_LOGIN 		= 1;
	public static int PANEL_REGISTER 	= 2;
	public static int PANEL_SERVER 		= 3;

	public enum StateID
	{
		Logining,
		Registering,
		LoadServerList
	}

	public string[] stateTxts = new string[]
	{
		"Logining ...",
		"Registering ...",
		"Load Server List ...",
	};
	
	/** 错误提示 */
	public event Action<int, string> 		errorEvent; 
	/** 显示状态提示 */
	public event Action<int, string> 		stateShowEvent; 
	/** 关闭状态提示 */
	public event Action 					stateHideEvent; 
	/** 打开面板 */
	public event Action<int> 				openPanelEvent; 
	/** 需要重新登录 */
	public event Action 					reloginEvent; 
	/** 登录成功 */
	public event Action<string> 			loginSuccessEvent; 
	/** 登录失败 */
	public event Action<string> 			loginFailEvent; 



	const int SUCCEED = 0;
	public ShinezoneNet net;
	public ShinezoneLogin (ShinezoneNet net)
	{
		this.net = net;

		net.account.requestEvent.OnLogin 		+= OnLogin;
		net.account.requestEvent.OnRegister 	+= OnRegister;
		net.account.requestEvent.OnServerList 	+= OnServerList;
		net.account.requestEvent.OnEnterGame 	+= OnEnterGame;
		net.netCtl.onNeedRestartDoWebAuth 	+= onNeedRestartDoWebAuth;
	}

	public void Error(int id, string err)
	{
		errorEvent (id, err);
	}

	public void StateShow(StateID id, string txt)
	{
		stateShowEvent ((int)id, txt);
	}

	
	public void StateHide()
	{
		stateHideEvent ();
	}

	public void OpenPanel(int panelId)
	{
		openPanelEvent (panelId);
	}



	/** 登录 */
	public void Login(string username, string password)
	{
		StateShow (StateID.Logining,  stateTxts[ (int) StateID.Logining]);
		net.account.Login (username, password);
	}

	/** 注册 */
	public void Register(string username, string password)
	{
		StateShow (StateID.Registering,  stateTxts[ (int) StateID.Registering]);
		net.account.Register (username, password);
	}

	/** 进入游戏 */
	public void EnterGame(int id, string ip, int port)
	{
		net.account.EnterGame (id.ToString(), ip, port.ToString() );
	}







	private void OnLogin(JSONNode result, int error_code, string error_msg)
	{
		if (error_code == SUCCEED) 
		{
			StateShow(StateID.LoadServerList, stateTxts[ (int) StateID.LoadServerList]);
			net.account.ServerList();
		} 
		else
		{
			StateHide ();
			Error(error_code, error_msg);
			loginFailEvent(error_msg);
			Loger.LogError("error_code=" + error_code + " " + error_msg);
		}
	}

	
	private void OnRegister(JSONNode result, int error_code, string error_msg)
	{
		if (error_code == SUCCEED) 
		{
			StateShow(StateID.LoadServerList, stateTxts[ (int) StateID.LoadServerList]);
			net.account.ServerList();
		} 
		else
		{
			StateHide ();
			Error(error_code, error_msg);
			loginFailEvent(error_msg);
			Loger.LogError("error_code=" + error_code + " " + error_msg);
		}
	}

	private void OnServerList(JSONNode result, int error_code, string error_msg)
	{
		Loger.Log (result);

		StateHide ();
		if (error_code == SUCCEED) 
		{
			loginSuccessEvent(result.ToString());
			openPanelEvent(PANEL_SERVER);
		} 
		else
		{
			Error(error_code, error_msg);
			loginFailEvent(error_msg);
			Loger.LogError("error_code=" + error_code + " " + error_msg);
		}
	}

	
	
	private void OnEnterGame(JSONNode result, int error_code, string error_msg)
	{
		Loger.Log (result);

		if (error_code == SUCCEED) 
		{
			net.account.SetLastServerID(net.account.GetServerID()); 

			Int64 accountId = Int64.Parse(result["account_id"]);
			string session 	= result["M"];

			net.netCtl.Connect(accountId, session);
		} 
		else
		{
			Error(error_code, error_msg);
			Loger.LogError("error_code=" + error_code + " " + error_msg);
		}
	}

	private void onNeedRestartDoWebAuth(object arg)
	{
		reloginEvent ();
		openPanelEvent (PANEL_LOGIN);
	}
}