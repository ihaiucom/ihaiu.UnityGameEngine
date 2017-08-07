using UnityEngine;
using System.Collections;
using com.ihaiu;
using Games;

/** Game Facade */
using XLua;


public class Game
{
	#region lua
	public static LuaEnv luaEnvLaunch;
	public static LuaEnv luaEnv;
	#endregion


    #region gameframe
	public static GameObject 			go;
	public static MainThreadManager 	mainThread;
    public static AssetManager 			asset;
	public static ConfigManager 		config;
	public static MenuManager 			menu;
	public static ModuleManager			module;
	public static LoadManager			loader;
    public static int pool;
    public static int proto;
    public static int audio;
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
	public static void InitLuaEnvLaunch()
	{
		luaEnvLaunch = new LuaEnv ();
		luaEnvLaunch.AddLoader (Game.asset.LoadLua);
		luaEnvLaunch.DoString ("print 'gamelaunch.GameVersionManager' ");
//		luaEnvLaunch.DoString ("require 'gamelaunch.GameVersionManager' ");
	}

	public static void DestoryLuaEnvLaunch()
	{
		if (luaEnvLaunch != null) 
		{
			luaEnvLaunch.Dispose ();
			luaEnvLaunch = null;
		}
	}

	
	public static void InitLuaEnv()
	{
		luaEnv = new LuaEnv ();
		luaEnv.AddLoader (Game.asset.LoadLua);
		luaEnvLaunch.DoString ("require 'gamemain.GameLaunch' ");
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
		if(luaEnvLaunch != null)
			luaEnvLaunch.Tick();
		
		if(luaEnv != null)
			luaEnv.Tick();
	}

	public static void OnDestroy()
	{
		
		if(luaEnvLaunch != null)
			luaEnvLaunch.Dispose();
		
		if(luaEnv != null)
			luaEnv.Dispose();
	}
}
