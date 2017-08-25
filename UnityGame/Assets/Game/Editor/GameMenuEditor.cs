using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Diagnostics;
using com.ihaiu;

namespace Games
{
	public class GameMenuEditor
	{
		[MenuItem("Game/Generate SettingConfig.json")]
		public static void GenerateSettingConfig()
		{
			SettingConfig config = SettingConfig.Load();
			config.Save();
		}


		[MenuItem("Game/Tool/xlsx -> csv")]
		public static void GenerateConfigXlsx2Csv()
		{
			GenerateConfigCsv.Generate();
		}


		[MenuItem("Game/Tool/xlsx -> lua")]
		public static void GenerateConfigXlsx2Lua()
		{
			GenerateConfigLua.Generate();
		}



		[MenuItem("Game/Tool/proto -> lua")]
		public static void GenerateLuaProto()
		{
			GenerateProto.GenerateLua ();
		}



		[MenuItem("Game/Tool/proto -> csharp")]
		public static void GenerateCsharpProto()
		{
			GenerateProto.GenerateCsharp ();
		}


		[MenuItem("Game/Tool/proto -> opcode")]
		public static void GenerateProtoOpcode()
		{
			GenerateProtoRelevance.Generate ();
		}


		[MenuItem("Game/Tool/Generate ConfigManager_List.cs")]
		public static void GenerateConfigManager()
		{
			ConfigManagerEditor.Generate();
			AssetDatabase.Refresh();
		}

		[MenuItem("Game/Tool/Generate ModuleManager_List.cs")]
		public static void GenerateModuleManager()
		{
			ModuleManagerEditor.Generate();
			AssetDatabase.Refresh();
		}



		[MenuItem("Game/Build/Copy Lua To Resources")]
		public static void CopyLuaToResources()
		{
			LuaEditor.CopyLuaToResources ();
		}



		[MenuItem("Game/Build/Copy Config To Resources")]
		public static void CopyConfigToResources()
		{
			LuaEditor.CopyConfigToResources ();
		}



		[MenuItem("Game/Build/Clear Resources Lua And Config")]
		public static void ClearResourcesLuaAndConfig()
		{
			LuaEditor.ClearResourcesLuaAndConfig ();
		}
	}

}