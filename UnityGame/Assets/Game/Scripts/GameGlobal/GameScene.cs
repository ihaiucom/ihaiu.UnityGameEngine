using UnityEngine;
using System.Collections;

public class GameScene 
{
	public static string Launch 	= "Launch";
	public static string Main 		= "Main";
	public static string War		= "War";

#if !UNITY_4_7
	public static Scene CurrentScene
	{
		get
		{
			return UnityEngine.SceneManagement.GetActiveScene();
		}
	}
#endif

	public static string CurrentName
	{
		get
		{
			
#if UNITY_4_7
			return Application.loadedLevelName;
#else
			return CurrentScene.name;
#endif
		}
	}

	public static bool IsLaunch
	{
		get
		{
			return CurrentName == Launch;
		}
	}

	public static bool IsMain
	{
		get
		{
			return CurrentName == Main;
		}
	}

	public static bool IsWar
	{
		get
		{
			return CurrentName == War;
		}
	}



}
