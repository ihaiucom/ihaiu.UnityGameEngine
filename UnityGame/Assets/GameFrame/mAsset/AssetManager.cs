using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ihaiu
{
	public partial class AssetManager : MonoBehaviour 
	{

		void Start () 
		{
			
		}

		void Update ()
		{
			
		}


		#region 同步加载

		/** 同步 加载Asset */
		public T LoadAsset<T>(string filename) where T : UnityEngine.Object
		{
			return null;
		}

		public UnityEngine.Object LoadAsset(string filename, Type type)
		{
			return null;
		}

		/** 同步 加载Scene */
		public void LoadScene(string sceneName, bool isAdditive)
		{
			
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




		#region 异步加载

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
