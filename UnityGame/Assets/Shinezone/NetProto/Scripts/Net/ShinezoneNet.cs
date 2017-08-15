using UnityEngine;
using System.Collections;
using lxnet;
using MessageProtocol;

public class ShinezoneNet 
{
	/** Mono */
	public ShinezoneNetMono 		mono;

	/** 账号 */
	public ShinezoneAccount 		account;

	/** 角色数据管理器 */
	public ShinezoneRole 			role;

	/** 网络事件 */
	public ShinezoneNetEvent 		netEvent;

	/** 协议处理器 */
	public ShinezoneProtocolProcess	protocolProcess;




	/** 初始化 */
	public void Init(string url, bool isTcp = false, string gameId = "_self_game", string channel = "default_self")
	{
		// mono
		GameObject go = new GameObject ("ShinezoneNet");
		GameObject.DontDestroyOnLoad (go);
		mono = go.AddComponent<ShinezoneNetMono>();
		mono.net = this;
		
		// 网络事件
		netEvent = new ShinezoneNetEvent ();
		
		// 初始化消息处理
		protocolProcess = new ShinezoneProtocolProcess (this);
		ProtocolProcess.Init(protocolProcess);


		// 初始化服务器时间模块
		ServerTime.Init ();
		
		// 初始化网络管理器模块
		NetworkMgr.Init (netEvent.dict, isTcp);

		
		// 角色管理器
		role = new ShinezoneRole ();

		// 账号
		account = new ShinezoneAccount (url, gameId, channel);

		
		//测试服务器延时，间隔1s测试一次
		NetworkMgr.SetPingInterval(1000);
	}

	/** 每帧调用 */
	public void Run()
	{
		long currenttime = lxnet_manager.GetMilliSecond ();
		ServerTime.Run (currenttime);
		NetworkMgr.Run (currenttime);
//		GameStateUI.UpdateState(currenttime);
	}

	/** 当挂起时 */
	public void OnPause()
	{
		NetworkMgr.OnPause ();
	}


	/** 当恢复时 */
	public void OnResume()
	{
		NetworkMgr.OnResume ();
	}

	/** 退出 */
	public void OnExit()
	{
		NetworkMgr.OnExit();
	}

}
