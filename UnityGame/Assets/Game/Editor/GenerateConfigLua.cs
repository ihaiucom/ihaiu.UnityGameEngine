using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Diagnostics;
using com.ihaiu;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class GenerateConfigLua
{

	public static void Generate()
	{
		Xlsx2Csv();

		Loger.Log(ProjectSettings.Root.Tools_xlsx2lua_Config);
		List<string> fileList = new List<string>();
		PathUtil.RecursiveFile(new string[]{ProjectSettings.Root.Tools_xlsx2lua_Config}, fileList, new List<string>(){".csv"});

		foreach(string path in fileList)
		{
			Loger.Log(path);
			
		}

//		DeleteCsv();

	}

	/** 转换成csv */
	private static void Xlsx2Csv()
	{
		Shell.RunFile (ProjectSettings.Config2LuaFile.Tools_xlsx2csv_sh, false);
	}


	/** 删除csv */
	private static void DeleteCsv()
	{
		Shell.RunFile (ProjectSettings.Config2LuaFile.Tools_rmtmp_sh, false);
	}


	/// <summary>
	/// 遍历目录及其子目录
	/// </summary>
	static void Recursive(string path, List<string> paths, List<string> files)
	{
		if (!Directory.Exists(path))
		{
			return;
		}
		string[] names = Directory.GetFiles(path);
		string[] dirs = Directory.GetDirectories(path);
		foreach (string filename in names)
		{
			string ext = Path.GetExtension(filename);
			files.Add(filename.Replace('\\', '/'));
		}
		foreach (string dir in dirs)
		{
			paths.Add(dir.Replace('\\', '/'));
			Recursive(dir, paths, files);
		}
	}

}
