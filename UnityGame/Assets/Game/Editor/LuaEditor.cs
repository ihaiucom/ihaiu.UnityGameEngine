using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;


public class LuaEditor
{

	static void RecursiveLua(string path, List<string> fileList) {
		string[] names = Directory.GetFiles(path);
		string[] dirs = Directory.GetDirectories(path);
		foreach (string filename in names) 
		{
			string ext = Path.GetExtension(filename);
			if(ext.Equals(".meta")) continue;

			string fn = Path.GetFileName(filename);
			if(fn.Equals(".DS_Store")) continue;

			string file = filename.Replace('\\', '/');
			fileList.Add(file);
		}

		foreach (string dir in dirs) 
		{
			RecursiveLua(dir, fileList);
		}
	}



	public static void DeleteDirectory(string path)
	{
		if (!Directory.Exists (path))
		{
			return;
		}

		string[] names = Directory.GetFiles(path);
		string[] dirs = Directory.GetDirectories(path);


		foreach (string dir in dirs) {
			DeleteDirectory(dir);
		}


		foreach (string filename in names) {
			File.Delete(filename);
		}


		Directory.Delete(path);
	}


	public static string ChangeExtension(string path, string ext)
	{
		string e = Path.GetExtension(path);
		if(string.IsNullOrEmpty(e))
		{
			return path + ext;
		}

		bool backDSC = path.IndexOf('\\') != -1;
		path = path.Replace('\\', '/');
		if(path.IndexOf('/') == -1)
		{
			return path.Substring(0, path.LastIndexOf('.')) + ext;
		}

		string dir = path.Substring(0, path.LastIndexOf('/'));
		string name = path.Substring(path.LastIndexOf('/'), path.Length - path.LastIndexOf('/'));
		name = name.Substring(0, name.LastIndexOf('.')) + ext;
		path = dir + name;

		if (backDSC)
		{
			path = path.Replace('/', '\\');
		}
		return path;
	}

	public static void CheckPath(string path, bool isFile = true)
	{
		if(isFile) path = path.Substring(0, path.LastIndexOf('/'));
		string[] dirs = path.Split('/');
		string target = "";

		bool first = true;
		foreach(string dir in dirs)
		{
			if(first)
			{
				first = false;
				target += dir;
				continue;
			}

			if(string.IsNullOrEmpty(dir)) continue;
			target +="/"+ dir;
			if(!Directory.Exists(target))
			{
				Directory.CreateDirectory(target);
			}
		}
	}

	public static void CopyLuaToResources()
	{
		string luaRoot = "Assets/Game/Lua";
		string bytesRoot = "Assets/Game/Resources/Lua";

		if (!Directory.Exists(luaRoot))
		{
			Debug.Log("目录不存在" + luaRoot);
			return;
		}


		List<string> luaList = new List<string>();
		RecursiveLua(luaRoot, luaList);

	



		if (Directory.Exists(bytesRoot)) DeleteDirectory(bytesRoot);
		Directory.CreateDirectory(bytesRoot);

		for(int i = 0; i < luaList.Count; i ++)
		{
			string ext = Path.GetExtension(luaList[i]);
			if(ext.Equals(".lua"))
			{
				string sourcePath = luaList[i];
				string destPath = ChangeExtension(sourcePath.Replace(luaRoot, bytesRoot), ".lua.txt");

				Debug.Log (destPath);

				CheckPath(destPath, true);
				File.Copy(sourcePath, destPath, true);
			}
		}


		AssetDatabase.Refresh();


	}

	public static void CopyConfigToResources()
	{
		string configRoot = "Assets/Game/Config";
		string bytesRoot = "Assets/Game/Resources/Config";

		if (!Directory.Exists(configRoot))
		{
			Debug.Log("目录不存在" + configRoot);
			return;
		}


		List<string> luaList = new List<string>();
		RecursiveLua(configRoot, luaList);





		if (Directory.Exists(bytesRoot)) DeleteDirectory(bytesRoot);
		Directory.CreateDirectory(bytesRoot);

		for(int i = 0; i < luaList.Count; i ++)
		{
			Debug.Log (luaList[i]);
			string ext = Path.GetExtension(luaList[i]);
			if(ext.Equals(".csv") || ext.Equals(".json") || ext.Equals(".xml"))
			{
				string sourcePath = luaList[i];
				string destPath = sourcePath.Replace (configRoot, bytesRoot);

				Debug.Log (destPath);

				CheckPath(destPath, true);
				File.Copy(sourcePath, destPath, true);
			}
		}


		AssetDatabase.Refresh();


	}


	public static void ClearResourcesLuaAndConfig()
	{
		string root = "Assets/Game/Resources/Lua";
		if (Directory.Exists(root)) DeleteDirectory(root);

		root = "Assets/Game/Resources/Config";
		if (Directory.Exists(root)) DeleteDirectory(root);
	}

	
}

