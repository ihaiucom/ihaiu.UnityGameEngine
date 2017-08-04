using UnityEngine;
using System.Collections;
using Games;
using System;


namespace com.ihaiu
{
    public class ConfigSetting 
    {


		public static void Load(string path, Action<string, string> call)
        {
			Game.asset.LoadConfig(path, call);
        }
    }
}
