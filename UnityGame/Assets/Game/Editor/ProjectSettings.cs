using UnityEngine;
using System.Collections;

public class ProjectSettings
{
	/** 项目名称 */
	private static string projectName;
	/** 获取项目名称 */
	public static string ProjectName
	{
		get 
		{
			if ( string.IsNullOrEmpty(projectName) ) 
				projectName = PathUtil.GetDirectoryName(Application.dataPath);
			
			return projectName;
		}
	}

	/** 目录 */
	public class Root
	{
		/** svn配置目录 xlsx格式的 */
		public static string SvnConfig
		{
			get 
			{
				return "";
			}
		}

		/** git协议目录 */
		public static string GitProto
		{
			get 
			{
				string dir = Application.dataPath + "/../../svn/proto";
				switch (ProjectName)
				{
				case "Game":
					dir = Application.dataPath + "/../../../Gidea-MT-Proto";
					break;
				}
				return dir;
			}
		}

		/** 工具目录 */
		public static string Tools
		{
			get 
			{
				return Application.dataPath + "/../../Tools";
			}
		}

		/** 工具--协议编号目录 */
		public static string Tools_proto_gen_opcode
		{
			get 
			{
				return Tools + "/proto-gen-opcode";
			}
		}



		/** Lua代码目录 */
		public static string Lua
		{
			get 
			{
				return Application.dataPath + "/Game/Lua";
			}
		}


	}

	/** 协议的相关文件 */
	public class ProtoFile
	{
		/** git proto下的 client_opcode_c.xlsx */
		public static string GitProto_client_opcode_c_xlsx
		{
			get 
			{
				return Root.GitProto + "/client_opcode_c.xlsx";
			}
		}

		/** git proto下的 client_opcode_s.xlsx */
		public static string GitProto_client_opcode_s_xlsx
		{
			get 
			{
				return Root.GitProto + "/client_opcode_s.xlsx";
			}
		}

		/** Tools/proto-gen-opcode下的 client_opcode_c.xlsx */
		public static string Tools_client_opcode_c_xlsx
		{
			get 
			{
				return Root.Tools_proto_gen_opcode + "/client_opcode_c.xlsx";
			}
		}



		/** Tools/proto-gen-opcode下的 client_opcode_s.xlsx */
		public static string Tools_client_opcode_s_xlsx
		{
			get 
			{
				return Root.Tools_proto_gen_opcode + "/client_opcode_s.xlsx";
			}
		}

		/** Tools/proto-gen-opcode下的 client_opcode_c.csv */
		public static string Tools_client_opcode_c_csv
		{
			get 
			{
				return Root.Tools_proto_gen_opcode + "/client_opcode_c.csv";
			}
		}



		/** Tools/proto-gen-opcode下的 client_opcode_s.csv */
		public static string Tools_client_opcode_s_csv
		{
			get 
			{
				return Root.Tools_proto_gen_opcode + "/client_opcode_s.csv";
			}
		}


		/** Tools/proto-gen-opcode/xlsx2csv.sh */
		public static string Tools_xlsx2csv_sh
		{
			get 
			{
				return Root.Tools_proto_gen_opcode + "/xlsx2csv.sh";
			}
		}




		/** Lua/gen/proto/ProtoInclude.lua */
		public static string Lua_ProtoInclude
		{
			get 
			{
				return  Root.Lua + "/gen/proto/ProtoInclude.lua";
			}
		}



		/** Lua/gen/proto/ProtoC_List.lua */
		public static string Lua_ProtoCList
		{
			get 
			{
				return  Root.Lua + "/gen/proto/ProtoC_List.lua";
			}
		}


		/** Lua/gen/proto/ProtoS_List.lua */
		public static string Lua_ProtoSList
		{
			get 
			{
				return  Root.Lua + "/gen/proto/ProtoS_List.lua";
			}
		}




		/** Plugins/Libs/Proto/ProtoC_List.cs */
		public static string Chsarp_ProtoCList
		{
			get 
			{
				return  Application.dataPath + "/Plugins/Libs/Proto/ProtoC_List.cs";
			}
		}


		/** Plugins/Libs/Proto/ProtoS_List.cs */
		public static string Chsarp_ProtoSList
		{
			get 
			{
				return  Application.dataPath + "/Plugins/Libs/Proto/ProtoS_List.cs";
			}
		}





	}


}
