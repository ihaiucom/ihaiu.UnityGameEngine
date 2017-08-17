using System;
using lxnet;

public class ShinezoneNetConnect : ShinezoneNetEvent
{
	public enum StateID
	{
		Connecting,
		Authing,
	}
	
	public string[] stateTxts = new string[]
	{
		"Connecting ...",
		"Authing ...",
	};
	
	
	
	/** 错误提示 */
	public event Action<int, string> 		errorEvent; 
	/** 显示状态提示 */
	public event Action<int, string> 		stateShowEvent; 
	/** 关闭状态提示 */
	public event Action 					stateHideEvent; 
	
	
	public void Error(int id, string err)
	{
		errorEvent (id, err);
	}
	
	public void StateShow(StateID id)
	{
		stateShowEvent ( (int)id,  stateTxts[(int)id]);
	}
	
	
	public void StateHide()
	{
		stateHideEvent ();
	}

	////////////////////////////////////////////////////////////////////////////

	public ShinezoneNet net;
	public ShinezoneNetConnect (ShinezoneNet net):base()
	{
		this.net = net;
	}

	private bool isInitSocket = false;
	/** 链接服务器 */
	public void Connect(Int64 accountId, string session)
	{
		isInitSocket = true;
		NetworkMgr.SetAuthInfo (accountId, session);
		NetworkMgr.InitSocketNet (net.account.GetServerIP (), net.account.GetServerPort ());
	}



	private int _preState = -1;
	public void Run()
	{
		if(isInitSocket && NetworkMgr.Socketer != null)
		{
			if(_preState != NetworkMgr.Socketer.State)
			{
				_preState = NetworkMgr.Socketer.State;
				switch(_preState)
				{
				case SocketNet.enum_state_nil:
				case SocketNet.enum_state_authsucceed:
					StateHide();
					break;
					
				case SocketNet.enum_state_create:
				case SocketNet.enum_state_connecting:
					StateShow ( StateID.Connecting );
					break;
					
					
				case SocketNet.enum_state_authing:
					StateShow ( StateID.Authing );
					break;
				}

			}
		}
	}





}
