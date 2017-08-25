using System.Collections;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using Games;

public class GenerateProtoRelevance 
{
	public static void Generate()
	{
		CopyXlsx ();
		Xlsx2Csv ();

		ProtoOpcodeReader configC = new ProtoOpcodeReader ();
		ProtoOpcodeReader configS = new ProtoOpcodeReader ();

		configC.delimiter = '\t';
		configS.delimiter = '\t';

		configC.Load (ProjectSettings.ProtoFile.Tools_client_opcode_c_csv);
		configS.Load (ProjectSettings.ProtoFile.Tools_client_opcode_s_csv);

		ProtoInclude 	include = new ProtoInclude ();
		ProtoList 		listC 	= new ProtoList (configC, configS);
		ProtoList 		listS 	= new ProtoList (configC, configS);

		foreach(var kvp in configC.configs)
		{
			include.AddProtoFile (kvp.Value.filename);
			listC.AddItem (kvp.Value);
		}

		foreach(var kvp in configS.configs)
		{
			include.AddProtoFile (kvp.Value.filename);
			listS.AddItem (kvp.Value);
		}



		include.GenerateLuaFile ();
		listC.GenerateLuaFileC ();
		listS.GenerateLuaFileS ();

		listC.GenerateCharpFileC ();
		listS.GenerateCharpFileS ();

		DeleteCsv ();
	}


	/** 拷贝文件 client_opcode_c.xlsx, client_opcode_s.xlsx */
	private static void CopyXlsx()
	{
		File.Copy (ProjectSettings.ProtoFile.GitProto_client_opcode_c_xlsx, ProjectSettings.ProtoFile.Tools_client_opcode_c_xlsx, true);
		File.Copy (ProjectSettings.ProtoFile.GitProto_client_opcode_s_xlsx, ProjectSettings.ProtoFile.Tools_client_opcode_s_xlsx, true);
	}

	/** 转换成csv */
	private static void Xlsx2Csv()
	{
		Shell.RunFile (ProjectSettings.ProtoFile.Tools_xlsx2csv_sh, false);
	}


	/** 删除csv */
	private static void DeleteCsv()
	{
		if (File.Exists (ProjectSettings.ProtoFile.Tools_client_opcode_c_csv))
			File.Delete (ProjectSettings.ProtoFile.Tools_client_opcode_c_csv);
		
		if (File.Exists (ProjectSettings.ProtoFile.Tools_client_opcode_s_csv))
			File.Delete (ProjectSettings.ProtoFile.Tools_client_opcode_s_csv);
	}



	/// <summary>
	/// Proto include.
	/// </summary>
	public class ProtoInclude
	{
		public Dictionary<string, string> pbs = new Dictionary<string, string> ();
		public StringWriter sw = new StringWriter();

		public void AddProtoFile(string filename)
		{
			if (!pbs.ContainsKey (filename))
			{
				pbs.Add (filename, filename);
			}
		}

		public void GenerateLuaFile()
		{
			sw.WriteLine (@"
-- ======================================
-- 该文件自动生成，不要修改，否则会替换
-- 默认Menu: Game/Tool/proto -> opcode
-- auth: 曾峰
-- email:zengfeng75@qq.com
-- qq:593705098
-- http://blog.ihaiu.com
-- --------------------------------------
");
			
			string format = "{0}_pb = require \"gen/pblua/{0}_pb\"" ;
			foreach(var kvp in pbs)
			{
				sw.WriteLine (string.Format(format, kvp.Value));
			}
			
			sw.WriteLine (@"

require ""gameframe/net/ProtoItem""
require ""gameframe/net/ProtoC""
require ""gameframe/net/ProtoS""


require ""gen/proto/ProtoC_List""
require ""gen/proto/ProtoS_List""");


			File.WriteAllText (ProjectSettings.ProtoFile.Lua_ProtoInclude, sw.ToString());

			Loger.Log (ProjectSettings.ProtoFile.Lua_ProtoInclude);
		}
	}


	/// <summary>
	/// Proto list.
	/// </summary>
	public class ProtoList
	{
		public ProtoOpcodeReader 		configC;
		public ProtoOpcodeReader 		configS;

		public List<ProtoOpcodeConfig> 	configs = new List<ProtoOpcodeConfig> ();

		public StringWriter 			swDefine = new StringWriter();
		public StringWriter 			swCreate = new StringWriter();

		public ProtoList(ProtoOpcodeReader configC, ProtoOpcodeReader configS)
		{
			this.configC = configC;
			this.configS = configS;
		}


		public void AddItem(ProtoOpcodeConfig config)
		{
			configs.Add (config);
		}


		public void GenerateLuaFileC()
		{
			swCreate = new StringWriter ();
			swDefine = new StringWriter ();

			string filename = null;
			swCreate.WriteLine ("function ProtoC:AddItems( )");
			foreach(ProtoOpcodeConfig config in configs)
			{
				if (filename != config.filename) 
				{
					swDefine.WriteLine ("\n\n");
					swDefine.WriteLine ("-- ====================" );
					swDefine.WriteLine ("-- " + config.filename);
					swDefine.WriteLine ("-- --------------------" );
					swDefine.WriteLine ("");


					swCreate.WriteLine ("\n\n");
					swCreate.WriteLine (" \t-- ====================" );
					swCreate.WriteLine (" \t-- " + config.filename);
					swCreate.WriteLine (" \t-- --------------------" );
					swCreate.WriteLine ("");


					filename = config.filename;
				}

				swDefine.WriteLine ("-- " + config.note);
				foreach(int mappingId in config.opcodeMappingList)
				{
					ProtoOpcodeConfig mappingConfig = configS.GetConfig (mappingId);
					if (mappingConfig != null) 
					{
						swDefine.WriteLine (string.Format("-- [mapping] {0},  {1}_pb, {2}", mappingConfig.protoStructAliasNameS, mappingConfig.filename, mappingConfig.note));
					} 
					else 
					{
						mappingConfig = configC.GetConfig (mappingId);
						if (mappingConfig != null) 
						{
							swDefine.WriteLine (string.Format("-- [mapping] {0},  {1}_pb, {2}", mappingConfig.protoStructAliasNameC, mappingConfig.filename, mappingConfig.note));
						} 
						else 
						{
							swDefine.WriteLine (string.Format("-- [mapping] {0}", mappingId));
						}
					}
				}


				swDefine.WriteLine (string.Format("{0} = {1}_pb.{2}", config.protoStructAliasNameC, config.filename, config.protoStructName));
				swDefine.WriteLine ("");


				swCreate.WriteLine (" \t-- " + config.note);
				swCreate.WriteLine (string.Format(" \tProtoC:AddItem(ProtoItem.New({0}, \"{1}\", \"{2}\", {2},  \"{3}_pb\", {4}, \"{5}\", false))",
					config.opcode, config.protoStructName, config.protoStructAliasNameC, config.filename, config.opcodeMappingList.ToStr(","), config.note
				));
				swCreate.WriteLine ("");


			}

			swCreate.WriteLine ("end");

			using (StreamWriter sw = new StreamWriter (ProjectSettings.ProtoFile.Lua_ProtoCList, false)) 
			{
				sw.WriteLine (@"
-- ======================================
-- 该文件自动生成，不要修改，否则会替换
-- 默认Menu: Game/Tool/proto -> opcode
-- auth: 曾峰
-- email:zengfeng75@qq.com
-- qq:593705098
-- http://blog.ihaiu.com
-- --------------------------------------
");
				
				sw.WriteLine (swDefine.ToString());
				sw.WriteLine ("\n\n");
				sw.WriteLine (swCreate.ToString());
			}

			Loger.Log (ProjectSettings.ProtoFile.Lua_ProtoCList);
		}


		public void GenerateLuaFileS()
		{
			swCreate = new StringWriter ();
			swDefine = new StringWriter ();

			string filename = null;
			swCreate.WriteLine ("function ProtoS:AddItems( )");
			foreach(ProtoOpcodeConfig config in configs)
			{
				if (filename != config.filename) 
				{
					swDefine.WriteLine ("\n\n");
					swDefine.WriteLine ("-- ====================" );
					swDefine.WriteLine ("-- " + config.filename);
					swDefine.WriteLine ("-- --------------------" );
					swDefine.WriteLine ("");


					swCreate.WriteLine ("\n\n");
					swCreate.WriteLine (" \t-- ====================" );
					swCreate.WriteLine (" \t-- " + config.filename);
					swCreate.WriteLine (" \t-- --------------------" );
					swCreate.WriteLine ("");


					filename = config.filename;
				}

				swDefine.WriteLine ("-- " + config.note);
				foreach(int mappingId in config.opcodeMappingList)
				{
					ProtoOpcodeConfig mappingConfig = configC.GetConfig (mappingId);
					if (mappingConfig != null) 
					{
						swDefine.WriteLine (string.Format("-- [mapping] {0}, {1}_pb, {2}", mappingConfig.protoStructAliasNameC, mappingConfig.filename, mappingConfig.note));
					} 
					else 
					{
						mappingConfig = configS.GetConfig (mappingId);
						if (mappingConfig != null) 
						{
							swDefine.WriteLine (string.Format("-- [mapping] {0}, {1}_pb, {2}", mappingConfig.protoStructAliasNameS, mappingConfig.filename, mappingConfig.note));
						} 
						else 
						{
							swDefine.WriteLine (string.Format("-- [mapping] {0}", mappingId));
						}
					}
				}


				swDefine.WriteLine (string.Format("{0} = {1}_pb.{2}", config.protoStructAliasNameS, config.filename, config.protoStructName));
				swDefine.WriteLine ("");


				swCreate.WriteLine (" \t-- " + config.note);
				swCreate.WriteLine (string.Format(" \tProtoS:AddItem(ProtoItem.New({0}, \"{1}\", \"{2}\", {2}, \"{3}_pb\", {4}, \"{5}\", true))",
					config.opcode, config.protoStructName, config.protoStructAliasNameS, config.filename,  config.opcodeMappingList.ToStr(","), config.note
				));
				swCreate.WriteLine ("");


			}

			swCreate.WriteLine ("end");

			using (StreamWriter sw = new StreamWriter (ProjectSettings.ProtoFile.Lua_ProtoSList, false)) 
			{
				sw.WriteLine (@"
-- ======================================
-- 该文件自动生成，不要修改，否则会替换
-- 默认Menu: Game/Tool/proto -> opcode
-- auth: 曾峰
-- email:zengfeng75@qq.com
-- qq:593705098
-- http://blog.ihaiu.com
-- --------------------------------------
");
				sw.WriteLine (swDefine.ToString());
				sw.WriteLine ("\n\n");
				sw.WriteLine (swCreate.ToString());
			}

			Loger.Log (ProjectSettings.ProtoFile.Lua_ProtoSList);
		}







		public void GenerateCharpFileC()
		{
			swCreate = new StringWriter ();
			swDefine = new StringWriter ();

			string filename = null;

			swDefine.WriteLine (@"

using UnityEngine;
using System;
using Games.PB;


");

			swCreate.WriteLine (@"


public partial class ProtoC
{
	/** 需要继承实现 */
	public static void Install()
	{			
");
			foreach(ProtoOpcodeConfig config in configs)
			{
				if (filename != config.filename) 
				{

					swDefine.WriteLine ("\n\n");
					swDefine.WriteLine ("// ====================" );
					swDefine.WriteLine ("// " + config.filename);
					swDefine.WriteLine ("// -- --------------------" );
					swDefine.WriteLine ("");


					swCreate.WriteLine ("\n\n");
					swCreate.WriteLine ("\t\t// ====================" );
					swCreate.WriteLine ("\t\t// " + config.filename);
					swCreate.WriteLine ("\t\t// -- --------------------" );
					swCreate.WriteLine ("");




					filename = config.filename;
				}

				swDefine.WriteLine ("// " + config.filename);
				swDefine.WriteLine ("// " + config.note);
				swCreate.WriteLine ("\t\t// " + config.note);
				foreach(int mappingId in config.opcodeMappingList)
				{
					ProtoOpcodeConfig mappingConfig = configS.GetConfig (mappingId);
					if (mappingConfig != null) 
					{
						swCreate.WriteLine (string.Format("\t\t// [mapping] {0},  {1}_pb, {2}", mappingConfig.protoStructAliasNameS, mappingConfig.filename, mappingConfig.note));
						swDefine.WriteLine (string.Format("// [mapping] {0},  {1}_pb, {2}", mappingConfig.protoStructAliasNameS, mappingConfig.filename, mappingConfig.note));

					} 
					else 
					{
						mappingConfig = configC.GetConfig (mappingId);
						if (mappingConfig != null) 
						{
							swCreate.WriteLine (string.Format("\t\t// [mapping] {0},  {1}_pb, {2}", mappingConfig.protoStructAliasNameC, mappingConfig.filename, mappingConfig.note));
							swDefine.WriteLine (string.Format("// [mapping] {0},  {1}_pb, {2}", mappingConfig.protoStructAliasNameC, mappingConfig.filename, mappingConfig.note));

						} 
						else 
						{
							swCreate.WriteLine (string.Format("\t\t// [mapping] {0}", mappingId));
							swDefine.WriteLine (string.Format("// [mapping] {0}", mappingId));

						}
					}
				}


				swDefine.WriteLine (string.Format("public class {0} : {1} {{}}", config.protoStructAliasNameC,  config.protoStructName));
				swDefine.WriteLine ("");


				swCreate.WriteLine (string.Format(" \t\tAddItem(new ProtoItem<{2}>(){{ opcode={0}, protoStructType=typeof({1}),  protoStructAliasType=typeof({2}), protoStructName=\"{1}\", protoStructAliasName=\"{2}\", protoFilename=\"{3}\", opcodeMapping=new int[]{4}, note=\"{5}\"  }});",
					config.opcode, config.protoStructName, config.protoStructAliasNameC, config.filename, config.opcodeMappingList.ToStr(","), config.note
				));
				swCreate.WriteLine ("");


			}

			swCreate.WriteLine (@"

	}
}
			
");

			using (StreamWriter sw = new StreamWriter (ProjectSettings.ProtoFile.Chsarp_ProtoCList, false)) 
			{
				sw.WriteLine (@"
// ======================================
// 该文件自动生成，不要修改，否则会替换
// 默认Menu: Game/Tool/proto -> opcode
// auth: 曾峰
// email:zengfeng75@qq.com
// qq:593705098
// http://blog.ihaiu.com
// --------------------------------------
");
				sw.WriteLine (swDefine.ToString());
				sw.WriteLine ("\n\n");
				sw.WriteLine (swCreate.ToString());
			}

			Loger.Log (ProjectSettings.ProtoFile.Chsarp_ProtoCList);
		}













		public void GenerateCharpFileS()
		{
			swCreate = new StringWriter ();
			swDefine = new StringWriter ();

			string filename = null;

			swDefine.WriteLine (@"
using UnityEngine;
using System;
using Games.PB;


");

			swCreate.WriteLine (@"


public partial class ProtoS
{
	/** 需要继承实现 */
	public static void Install()
	{			
");
			foreach(ProtoOpcodeConfig config in configs)
			{
				if (filename != config.filename) 
				{

					swDefine.WriteLine ("\n\n");
					swDefine.WriteLine ("// ====================" );
					swDefine.WriteLine ("// " + config.filename);
					swDefine.WriteLine ("// -- --------------------" );
					swDefine.WriteLine ("");


					swCreate.WriteLine ("\n\n");
					swCreate.WriteLine ("\t\t// ====================" );
					swCreate.WriteLine ("\t\t// " + config.filename);
					swCreate.WriteLine ("\t\t// -- --------------------" );
					swCreate.WriteLine ("");




					filename = config.filename;
				}

				swDefine.WriteLine ("// " + config.filename);
				swDefine.WriteLine ("// " + config.note);
				swCreate.WriteLine ("\t\t// " + config.note);
				foreach(int mappingId in config.opcodeMappingList)
				{
					ProtoOpcodeConfig mappingConfig = configS.GetConfig (mappingId);
					if (mappingConfig != null) 
					{
						swCreate.WriteLine (string.Format("\t\t// [mapping] {0},  {1}_pb, {2}", mappingConfig.protoStructAliasNameS, mappingConfig.filename, mappingConfig.note));
						swDefine.WriteLine (string.Format("// [mapping] {0},  {1}_pb, {2}", mappingConfig.protoStructAliasNameS, mappingConfig.filename, mappingConfig.note));

					} 
					else 
					{
						mappingConfig = configC.GetConfig (mappingId);
						if (mappingConfig != null) 
						{
							swCreate.WriteLine (string.Format("\t\t// [mapping] {0},  {1}_pb, {2}", mappingConfig.protoStructAliasNameC, mappingConfig.filename, mappingConfig.note));
							swDefine.WriteLine (string.Format("// [mapping] {0},  {1}_pb, {2}", mappingConfig.protoStructAliasNameC, mappingConfig.filename, mappingConfig.note));

						} 
						else 
						{
							swCreate.WriteLine (string.Format("\t\t// [mapping] {0}", mappingId));
							swDefine.WriteLine (string.Format("// [mapping] {0}", mappingId));

						}
					}
				}


				swDefine.WriteLine (string.Format("public class {0} : {1} {{}}", config.protoStructAliasNameS,  config.protoStructName));
				swDefine.WriteLine ("");


				swCreate.WriteLine (string.Format(" \t\tAddItem(new ProtoItem<{2}>(){{ opcode={0}, protoStructType=typeof({1}),  protoStructAliasType=typeof({2}), protoStructName=\"{1}\", protoStructAliasName=\"{2}\", protoFilename=\"{3}\", opcodeMapping=new int[]{4}, note=\"{5}\"  }});",
					config.opcode, config.protoStructName, config.protoStructAliasNameS, config.filename, config.opcodeMappingList.ToStr(","), config.note
				));
				swCreate.WriteLine ("");


			}

			swCreate.WriteLine (@"

	}
}
			
");

			using (StreamWriter sw = new StreamWriter (ProjectSettings.ProtoFile.Chsarp_ProtoSList, false)) 
			{
				sw.WriteLine (@"
// ======================================
// 该文件自动生成，不要修改，否则会替换
// 默认Menu: Game/Tool/proto -> opcode
// auth: 曾峰
// email:zengfeng75@qq.com
// qq:593705098
// http://blog.ihaiu.com
// --------------------------------------
");
				sw.WriteLine (swDefine.ToString());
				sw.WriteLine ("\n\n");
				sw.WriteLine (swCreate.ToString());
			}

			Loger.Log (ProjectSettings.ProtoFile.Chsarp_ProtoSList);
		}












	}


}
