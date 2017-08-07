using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

namespace com.ihaiu
{
	public partial class AssetManager : MonoBehaviour 
	{
		private static Type TYPE_OBJECT = typeof(UnityEngine.Object);


		#region 加载Config
		public void LoadConfig(string filename, Action<string, string> callback)
		{
			if (callback != null)
			{
				callback (filename, LoadConfig(filename));
			}
		}

		public string LoadConfig(string filename)
		{
			
			#if UNITY_EDITOR
			filename = AssetManagerSetting.EditorGetConfigPath(filename);
			return File.ReadAllText(filename);
			#else
			TextAsset obj = Resources.Load<TextAsset> (filename);
			if (obj != null)
				return obj.text;
			else
				return string.Empty;
			#endif
		}
		#endregion


		#region 加载Lua
		public byte[] LoadLua(ref string filename)
		{
			string script = null;

			#if UNITY_EDITOR
			filename += ".lua";
			filename = AssetManagerSetting.EditorRoot.Lua + "/" + filename;
			script =  File.ReadAllText(filename);
			#else
			TextAsset obj = Resources.Load<TextAsset> (filename);
			if (obj != null)
				string script =  obj.text;
			#endif

			if(script != null)
			{
				return System.Text.Encoding.UTF8.GetBytes(script);
			}
			else
			{
				Loger.LogErrorFormat("AssetManager.LoadLua 没加载到 filename={0}", filename);
			}

			return null;
		}

		#endregion
		
		#region 加载回调
		/** 同步 加载Asset */
		public void Load<T>(string filename, Action<string, T> callback) where T : UnityEngine.Object
		{
			if (callback != null) 
			{
				callback(filename, Resources.Load<T> (filename));
			}
		}

		
		
		public void Load(string filename, Action<string, UnityEngine.Object> callback)
		{
			if (callback != null) 
			{
				callback(filename, Resources.Load (filename, TYPE_OBJECT));
			}
		}
		
		public void Load(string filename, Type type, Action<string, UnityEngine.Object> callback)
		{
			if (callback != null) 
			{
				callback(filename, Resources.Load (filename, type));
			}
		}
	
		#endregion



		#region 同步加载
		/** 同步 加载Asset */
		public T LoadAsset<T>(string filename) where T : UnityEngine.Object
		{
			return Resources.Load<T> (filename);

		}

		public UnityEngine.Object LoadAsset(string filename, Type type)
		{
			return Resources.Load (filename, type);
		}

		/** 同步 加载Scene */
		public void LoadScene(string sceneName, bool isAdditive)
		{
			if(isAdditive)
				Application.LoadLevelAdditive (sceneName);
			else
				Application.LoadLevel (sceneName);
		}
		#endregion




		#region 提供AssetBundeName 同步加载

		/** 同步 加载AssetBundle */
		public AssetBundle LoadAssetBundle(string assetBundleName)
		{
			return null;
		}

		/** 同步 加载Asset */
		public T LoadAsset<T>(string assetBundleName, string filename) where T : UnityEngine.Object
		{
			return null;
		}


		public UnityEngine.Object LoadAsset(string assetBundleName, string filename)
		{
			return null;
		}


		/** 同步 加载Scene */
		public void LoadScene(string assetBundleName, string sceneName, bool isAdditive)
		{

		}
		#endregion



		#region 资源卸载
		public void Unload(string filename)
		{
			
		}

		public void Unload(string assetBundleName, string filename)
		{

		}
		#endregion



	}
}
