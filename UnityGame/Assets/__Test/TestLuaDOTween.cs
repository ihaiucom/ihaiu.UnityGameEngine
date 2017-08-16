using UnityEngine;
using System.Collections;
using XLua;
using System;
using DG.Tweening;

public class TestLuaDOTween : MonoBehaviour {
	
	LuaEnv luaenv;
	void Start () {

		string code  =@"
function go(transform)
	transform:DOMove (CS.UnityEngine.Vector3(0, 5, 0), 3, false)
end
";

		luaenv = new LuaEnv();
		luaenv.DoString(code);
		Action<Transform> go = luaenv.Global.Get<Action<Transform>> ("go");
		go (transform);
		go = null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDestory()
	{
		luaenv.Dispose ();
		luaenv = null;
	}
}
