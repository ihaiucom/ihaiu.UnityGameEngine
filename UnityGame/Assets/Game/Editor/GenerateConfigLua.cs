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

		// 生存 ConfigManager_List.lua

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

	/** 处理csv文件 */
	private static void ParseCsv()
	{
		// 生存XXXConfig.lua

		// 生存XXXConfigReader.lua

		// 生存XXXConfigReader_Data.lua


		
	}

}
