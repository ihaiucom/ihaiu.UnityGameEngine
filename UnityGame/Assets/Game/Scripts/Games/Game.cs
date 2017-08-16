using UnityEngine;
using System.Collections;
using com.ihaiu;
using Games;

/** Game Facade */
using XLua;


public class Game
{
	#region lua
	public static LuaEnv luaEnvVersion;
	public static LuaEnv luaEnv;
	#endregion


	#region gameframe
	public static bool					IsDestroy { get; private set;}
	public static GameObject 			go;
	public static MainThreadManager 	mainThread;
    public static AssetManager 			asset;
	public static ConfigManager 		config;
	public static MenuManager 			menu;
	public static ModuleManager			module;
	public static LoadManager			loader;
//    public static int pool;
//    public static int proto;
//    public static int audio;

	public static ShinezoneNet			shinezoneNet = new ShinezoneNet();
    #endregion

	#region global other
	public static GameCamera 	camera 		= new GameCamera();
	public static GameCanvas 	canvas		= new GameCanvas();
	public static UILayer 		uiLayer 	= new UILayer();
    public static GameCircle    cricle      = new GameCircle();
	#endregion


    #region user
	public static UserData user = new UserData();
    #endregion

	#region LuaEnv
	public static void InitLuaEnvVersion()
	{
		luaEnvVersion = new LuaEnv ();
		luaEnvVersion.AddLoader (Game.asset.LoadLua);
		luaEnvVersion.DoString ("require 'gameversion.GameVersionManager' ");
	}

	public static void DestoryLuaEnvVersion()
	{
		mainThread.StartCoroutine (DelayDestoryLuaEnvVersion());

	}

	private static IEnumerator DelayDestoryLuaEnvVersion()
	{
		yield return new WaitForSeconds(1);
		if (luaEnvVersion != null) 
		{
			luaEnvVersion.Dispose ();
			luaEnvVersion = null;
		}
		
		Loger.Log ("Game.DelayDestoryLuaEnvVersion");
	}

	
	public static void InitLuaEnv()
	{
		luaEnv = new LuaEnv ();
		luaEnv.AddLoader (Game.asset.LoadLua);
		luaEnv.DoString ("require 'gamemain.GameLaunch' ");
	}
	#endregion


	public static IEnumerator Install(GameObject go)
    {
		Game.go 			= go;
		Game.mainThread		= go.AddComponent<MainThreadManager>();
		Game.asset 			= go.AddComponent<AssetManager> ();
		Game.config 		= new ConfigManager();
		Game.menu			= new MenuManager();
		Game.module			= new ModuleManager();

		yield return 0;
    }

	public static void Update()
	{
		if(luaEnvVersion != null)
			luaEnvVersion.Tick();
		
		if(luaEnv != null)
			luaEnv.Tick();
	}

	public static void OnDestroy()
	{
		IsDestroy = true;
		
		if(luaEnvVersion != null)
			luaEnvVersion.Dispose();
		
		if (luaEnv != null) 
		{
			try
			{
				luaEnv.Dispose ();
			}
			catch(System.Exception e)
			{
				Debug.Log(e.ToString());
			}
		}
	}
}
