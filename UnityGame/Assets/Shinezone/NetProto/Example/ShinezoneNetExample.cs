using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;

public class ShinezoneNetExample : MonoBehaviour 
{
	ShinezoneNet net;
	public string url = "http://106.14.8.84/game_operating_platform/index.php";

	public Transform loginWindow; 
	public GameObject loginPanel;
	public GameObject registerPanel;
	public GameObject serverPanel;

	public InputField loginInputUsername;
	public InputField loginInputPassword;

	
	public InputField registerInputUsername;
	public InputField registerInputPassword;

	private GameObject[] panels;

	void Start () 
	{
		panels = new GameObject[]{loginPanel, registerPanel, serverPanel};

		net = new ShinezoneNet ();
		net.Init (url);

		net.account.requestEvent.OnLogin 		+= OnLogin;
		net.account.requestEvent.OnServerList 	+= OnServerList;
		net.netCtl.onNeedRestartDoWebAuth 	+= onNeedRestartDoWebAuth;
	}

	const int SUCCEED = 0;


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

	private void onNeedRestartDoWebAuth(object arg)
	{
		OpenLoginPanel ();
	}

	private void OnServerList(JSONNode result, int error_code, string error_msg)
	{
		Loger.Log (result);

		if (error_code == SUCCEED) 
		{

			OpenServerPanel();
		} 
		else
		{
			Loger.LogError("error_code=" + error_code + " " + error_msg);
		}
	}

	void Update () 
	{
	
	}



	public void OpenPanel(int tabId)
	{
		foreach(GameObject go in panels)
		{
			go.SetActive(false);
		}

		panels [tabId].SetActive (true);
		       
	}
	
	public void OpenLoginPanel()
	{
		OpenPanel (0);
	}
	
	public void OpenRegisterPanel()
	{
		OpenPanel (1);
	}

	
	public void OpenServerPanel()
	{
		OpenPanel (2);
	}

	public void SignUp()
	{
		net.account.Register (registerInputUsername.text, registerInputPassword.text);
	}

	
	public void SignIn()
	{
		net.account.Login (loginInputUsername.text, loginInputPassword.text);
	}
}
