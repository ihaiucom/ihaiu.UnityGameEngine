using UnityEngine;
using System.Collections;
using XLua;
using System;

[LuaCallCSharp]
public class LuaView : MonoBehaviour 
{

	[CSharpCallLua]
	public interface BaseView
	{
		void CsStart 		(GameObject go, LuaView view);
		void CsUpdate 		();
		void CsGUI			();
		void CsEnable 		();
		void CsDisable 		();
		void CsDestroy 		();
	}

	public static void AddView(LuaTable luaTabel, GameObject go)
	{
		if (go == null)
		{
			Loger.LogErrorFormat("LuaView.AddView go = null");
			return;
		}

		
		if (go.GetComponent<LuaView>() != null)
		{
			Loger.LogErrorFormat("GameObject go = {0} 已经存在 LuaView 组件", go);
			return;
		}

		
		if (luaTabel == null)
		{
			Loger.LogErrorFormat("LuaView.AddView luaTabel = null");
			return;
		}

		LuaView luaView = go.AddComponent<LuaView>();
		luaView.SetTabel (luaTabel);
	}

	public BaseView luaView;

	public void SetTabel(LuaTable luaTabel)
	{
		luaView = luaTabel.Get<BaseView> ("instance");
		if (luaView == null) 
		{
			Action setInstall = luaTabel.Get<Action>("SetInstall");
			if(setInstall != null)
				setInstall();
		}

		if (luaView != null && isStart) 
		{
			luaView.CsStart(gameObject, this);
		}
	}


	void OnEnable()
	{
		if(isStart && luaView != null) luaView.CsEnable();
	}

	public bool isStart = false;
	void Start ()
	{
		bool isStart = true;

		if(luaView != null) luaView.CsStart(gameObject, this);
	}



	void Update () 
	{
		if(luaView != null) luaView.CsUpdate();
	}
	
	void OnGUI()
	{
		if(luaView != null) luaView.CsGUI();
	}
	
	
	void OnDisable()
	{
		if(luaView != null) luaView.CsDisable();
	}

	
	void OnDestroy()
	{
		if(luaView != null) luaView.CsDestroy();

		luaView = null;
	}


}
