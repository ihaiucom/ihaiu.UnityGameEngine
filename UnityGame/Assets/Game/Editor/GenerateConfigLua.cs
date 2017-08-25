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
	public static int CSV_HEAD_LINE_INDEX_TYPE 		= 0;
	public static int CSV_HEAD_LINE_INDEX_CN 		= 1;
	public static int CSV_HEAD_LINE_INDEX_EN 		= 2;
	public static int CSV_HEAD_LINE_INDEX_PROP 		= 3;

	public static void Generate()
	{
		PathUtil.CheckPath (ProjectSettings.Root.Tools_xlsx2lua_Config, false);
		PathUtil.CheckPath (ProjectSettings.Root.Lua_gen_configreaders, false);

		Xlsx2Csv();

		Loger.Log(ProjectSettings.Root.Tools_xlsx2lua_Config);
		List<string> fileList = new List<string>();
		PathUtil.RecursiveFile(new string[]{ProjectSettings.Root.Tools_xlsx2lua_Config}, fileList, new List<string>(){".csv"});

		foreach(string path in fileList)
		{
			Loger.Log(path);
			// 加载csv文件
			CsvData csv = new CsvData().ReadFile(path);

			// 处理csv文件
			ProcessCsv(path, csv);
		}

		// 生存 ConfigManager_List.lua

//		DeleteCsv();

	}

	/** 转换成csv */
	private static void Xlsx2Csv()
	{
		
		Shell.RunFile (ProjectSettings.Config2LuaFile.Tools_xlsx2csv_sh, true);
	}


	/** 删除csv */
	private static void DeleteCsv()
	{
		Shell.RunFile (ProjectSettings.Config2LuaFile.Tools_rmtmp_sh, false);
	}



	/** 处理csv文件 */
	private static void ProcessCsv(string path, CsvData csv)
	{
		string filename = Path.GetFileName (path);
		filename = PathUtil.ChangeExtension (filename, "");

		// 生存XXXConfig.lua
		GenerateConfigStruct generateConfigStruct = new GenerateConfigStruct(filename, csv).Generate();


		// 生存XXXConfigReader.lua

		// 生存XXXConfigReader_Data.lua
	}


	/** 生成配置数据结构 */
	public class GenerateConfigStruct
	{
		public string 	csvName;
		public CsvData 	csv;

		public string 	className;

		public string 	requirePath;
		public string 	filePath;


		public string 	requireExtendPath;
		public string 	fileExtendPath;

		public string[] headTypes;
		public string[] headCns;
		public string[] headEns;
		public string[] samples;


		public string GetKey()
		{
			return csv.GetCell (CSV_HEAD_LINE_INDEX_EN, 0);
		}

		public GenerateConfigStruct(string csvName, CsvData csv)
		{
			this.csvName 	= csvName;
			this.csv 		= csv;


			className = string.Format("{0}Config", csvName.FirstUpper());

			requirePath = string.Format(ProjectSettings.Config2LuaFile.Lua_namespace, className);
			filePath = string.Format("{0}/{1}.lua", ProjectSettings.Root.Lua, requirePath);


			requireExtendPath = string.Format(ProjectSettings.Config2LuaFile.Lua_namespace_Extend, className);
			fileExtendPath = string.Format("{0}/{1}.lua", ProjectSettings.Root.Lua, requireExtendPath);



			headTypes 	= csv.GetLine(CSV_HEAD_LINE_INDEX_TYPE);
			headCns 	= csv.GetLine(CSV_HEAD_LINE_INDEX_CN);
			headEns 	= csv.GetLine(CSV_HEAD_LINE_INDEX_EN);

			samples		=  csv.LineCount > CSV_HEAD_LINE_INDEX_PROP + 1 ? csv.GetLine(CSV_HEAD_LINE_INDEX_PROP + 1) : csv.GetLine(CSV_HEAD_LINE_INDEX_PROP);
		}

		public GenerateConfigStruct Generate()
		{
			StringWriter defineSW 	= new StringWriter ();
			StringWriter initSW 	= new StringWriter ();
			List<string> args = new List<string> ();



			for(int i = 0; i < headEns.Length; i ++)
			{
				string type 	= headTypes	[i];
				string cn 		= headCns	[i];
				string en 		= headEns	[i];
				string sample	= samples	[i];
				if (string.IsNullOrEmpty (en))
					continue;

				args.Add (en);

				string defaultVal = "nil";
				switch(type)
				{
				case "int":
					defaultVal = "0";
					initSW.WriteLine (string.Format(" \tself.{0} = {0}", en));
					break;
				case "bool":
					defaultVal = "false";
					initSW.WriteLine (string.Format(" \tself.{0} = string.IsNullOrEmpty( {0} ) == false and {0} ~= 0 or false", en));
					break;
				default:
					initSW.WriteLine (string.Format(" \tself.{0} = {0}", en));
					break;
				}

				defineSW.WriteLine (string.Format(" \t-- {0}", cn));
				defineSW.WriteLine (string.Format(" \t-- type:{0}", type));
				defineSW.WriteLine (string.Format(" \t-- sample:{0}", sample));
				defineSW.WriteLine (string.Format(" \t{0} = {1},", en, defaultVal));
				defineSW.WriteLine ("");

			}


			StringWriter sw = new StringWriter ();

			sw.WriteLine (@"-- ======================================
-- 该文件自动生成,，不要修改，否则会替换
-- 默认Menu: Game/Tool/xlsx->lua
-- auth: 曾峰
-- http://blog.ihaiu.com
-- --------------------------------------			
");

			// 结构体
			sw.WriteLine (string.Format("{0} = class(\"{0}\", {{", className));
			sw.WriteLine (defineSW.ToString());
			sw.WriteLine ("})\n\n");

			sw.WriteLine (string.Format("local M = {0} \n", className));

			sw.WriteLine (string.Format("-- 获取键值"));
			sw.WriteLine (string.Format("function M:GetKey()"));
			sw.WriteLine (string.Format(" \treturn self.{0}", GetKey() ));
			sw.WriteLine (string.Format("end"));


			sw.WriteLine (string.Format("-- 构造方法"));
			sw.WriteLine (string.Format("function M:ctor({0})", args.ToStr<string>(", ") ));
			sw.WriteLine (initSW.ToString());

			sw.WriteLine (string.Format("\t-- 自定义解析"));
			sw.WriteLine (string.Format("\tself:Parse()"));
			sw.WriteLine (string.Format("end\n\n"));

			sw.WriteLine (string.Format("-- 加载扩展"));
			sw.WriteLine (string.Format("-- 扩展只会第一次生成，该文件存在就不再生成。你可以再里面扩展自己功能"));
			sw.WriteLine (string.Format("require \"{0}\"", requireExtendPath));



			File.WriteAllText (filePath, sw.ToString());
			Loger.Log (filePath);

			GenerateExtend ();

			return this;
		}

		public GenerateConfigStruct GenerateExtend()
		{
			if (File.Exists (fileExtendPath)) 
			{
				return this;
			}

			StringWriter sw = new StringWriter ();
			sw.WriteLine ("-- ===========================");
			sw.WriteLine (string.Format("-- {0} 的扩展", className));
			sw.WriteLine ("-- 该文件只会第一次生成，存在就不再生成。你可以在这扩展功能");
			sw.WriteLine ("-- ---------------------------\n\n");


			sw.WriteLine (string.Format("local M = {0}", className));


			sw.WriteLine ("-- =============");
			sw.WriteLine ("-- 二次解析配置");
			sw.WriteLine ("-- 创建配置时调用;如果默认的字段内容满足不了你的解析，你可以在这里自己进行第二次解析");
			sw.WriteLine ("-- 不要删除该方法");
			sw.WriteLine ("-- -------------");
			sw.WriteLine ("function M:Parse()");
			sw.WriteLine ("\t -- process");
			sw.WriteLine ("end");





			File.WriteAllText (fileExtendPath, sw.ToString());
			Loger.Log (fileExtendPath);

			return this;
		}
	}


}
