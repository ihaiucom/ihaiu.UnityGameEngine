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
	
//		RectTransform rectTransform = null;
//		rectTransform.DOAnchorPosY (30, 0.5, false).SetDelay(5).OnComplete(OnComplete);
	
//		transform.DOMove (Vector3.up, 1, false);

//		CanvasGroup group = null;
//		group.DOFade (1, 0.5);

		luaenv = new LuaEnv();
		luaenv.DoString(code);
		Action<Transform> go = luaenv.Global.Get<Action<Transform>> ("go");
		go (transform);
		go = null;
	}

	void OnComplete()
	{
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
