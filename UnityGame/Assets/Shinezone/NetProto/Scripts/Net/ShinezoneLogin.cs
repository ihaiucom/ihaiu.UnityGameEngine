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

	}

	public string[] stateTxts = new string[]
	{

	};
	
	
	public event Action<int, string> 	errorEvent; 
	public event Action<int, string> 	stateShowEvent; 
	public event Action 				stateHideEvent; 
	public event Action<int> 			openPanelEvent; 


	const int SUCCEED = 0;
	public ShinezoneNet net;
	public ShinezoneLogin (ShinezoneNet net)
	{
		this.net = net;

		net.account.requestEvent.OnLogin 		+= OnLogin;
		net.account.requestEvent.OnServerList 	+= OnServerList;
		net.netEvent.onNeedRestartDoWebAuth 	+= onNeedRestartDoWebAuth;
	}

	public void Error(int id, string err)
	{
		errorEvent (id, err);
	}

	public void StateShow(int id, string txt)
	{
		stateShowEvent (id, txt);
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
		StateShow ();
		net.account.Login (username, password);
	}

	/** 注册 */
	public void Register(string username, string password)
	{
		net.account.Register (username, password);
	}







	private void OnLogin(JSONNode result, int error_code, string error_msg)
	{
		if (error_code == SUCCEED) 
		{
			net.account.ServerList();
		} 
		else
		{
			Loger.LogError("error_code=" + error_code + " " + error_msg);
		}
	}

	private void OnServerList(JSONNode result, int error_code, string error_msg)
	{
		Loger.Log (result);
		
		if (error_code == SUCCEED) 
		{
		} 
		else
		{
			Loger.LogError("error_code=" + error_code + " " + error_msg);
		}
	}

	private void onNeedRestartDoWebAuth(object arg)
	{

	}
}