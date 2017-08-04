#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Collections.Generic;


namespace Games
{
	public partial class GameLayerEditor
    {


        [MenuItem("Edit/Game/SetEditorLayer")]
        public static void SetEditorTag ()
        {
			
			#if UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9
			
			SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
			SerializedProperty it = tagManager.GetIterator();
			int i = customBeginIndex;

			while (it.NextVisible(true))
			{
				if(it.name.StartsWith("User Layer"))
				{
					it.stringValue = customLayers[i - customBeginIndex];
					i ++;
				}
				
				if(i >= 32) break;
			}
			tagManager.ApplyModifiedProperties();
			
			#else
			SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
			SerializedProperty it = tagManager.GetIterator();
			while (it.NextVisible(true))
			{
				if(it.name == "layers")
                {
                    int end = Mathf.Min(customBeginIndex + customLayers.Length, it.arraySize);
                    for (int i = customBeginIndex; i < end; i++) 
                    {
                        SerializedProperty dataPoint = it.GetArrayElementAtIndex(i);
                        dataPoint.stringValue = customLayers[i - customBeginIndex];
                    }

                    tagManager.ApplyModifiedProperties();
                    if (customBeginIndex + customLayers.Length > 32)
                    {
						Loger.LogFormat("<color=red>Layer不能超过31</color>");
                    }
                    break;
                }
            }
			#endif
        }

		[MenuItem("Edit/Game/Generate GameLayer.cs")]
		public static void GenerateGameLayer ()
		{
			GenerateGameLayerEnum ();

#if UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9
			
			SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
			SerializedProperty it = tagManager.GetIterator();

			StringWriter sw = new StringWriter();
			sw.WriteLine("namespace Games");
			sw.WriteLine("{");
			sw.WriteLine("\tpublic partial class GameLayerEditor");
			sw.WriteLine("\t{");
			
			sw.WriteLine("\t\t#region Unity Default Lock");
			int i = 0;
			while (it.NextVisible(true))
			{
				if(it.name.StartsWith("Builtin Layer"))
				{
					string fieldname = string.IsNullOrEmpty(it.stringValue) ? "Layer" + i : it.stringValue.Replace(" ", "_");
					sw.WriteLine(string.Format("\t\tpublic const int {0}\t\t\t=\t1 << {1};", fieldname , i ));
					i ++;
				}

				if(i >= 8) break;
			}
			
			sw.WriteLine("\t\t#endregion");
			sw.WriteLine("\n");

			
			List<string> fieldnames = new List<string>();

			while (it.NextVisible(true))
			{
				if(it.name.StartsWith("User Layer"))
				{
					string fieldname = string.IsNullOrEmpty(it.stringValue) ? "Layer" + i : it.stringValue.Replace(" ", "_");
					sw.WriteLine(string.Format("\t\tpublic const int {0}\t\t\t=\t1 << {1};", fieldname , i ));
					fieldnames.Add(string.Format("\"{0}\"", fieldname));

					i ++;
				}
				
				if(i >= 32) break;
			}
			
			string fieldnameStr = "";
			string gap = "";
			for(int j = 0; j < fieldnames.Count; j ++)
			{
				fieldnameStr += gap;
				fieldnameStr += fieldnames[j];
				gap = ",";
			}

			
			
			sw.WriteLine("\n");
			sw.WriteLine("\t\tpublic static int           customBeginIndex = 8;");
			sw.WriteLine("\t\tpublic static string[]      customLayers = {"+fieldnameStr+"};");
			
			sw.WriteLine("\t}");
			sw.WriteLine("}");
			File.WriteAllText(Application.dataPath + "/Game/Scripts/Unity/GameLayerClass.cs", sw.ToString(), System.Text.Encoding.UTF8);
			AssetDatabase.Refresh();
#else
			
			SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
			SerializedProperty it = tagManager.GetIterator();

			while (it.NextVisible(true))
			{
				if(it.name == "layers")
				{
					StringWriter sw = new StringWriter();
					sw.WriteLine("namespace Games");
					sw.WriteLine("{");
					sw.WriteLine("\tpublic partial class GameLayerEditor");
					sw.WriteLine("\t{");

					sw.WriteLine("\t\t#region Unity Default Lock");
					for (int i = 0; i < 8; i++) 
					{
						SerializedProperty dataPoint = it.GetArrayElementAtIndex(i);
						string fieldname = string.IsNullOrEmpty(dataPoint.stringValue) ? "Layer" + i : dataPoint.stringValue.Replace(" ", "_");
						sw.WriteLine(string.Format("\t\tpublic const int {0}\t\t\t=\t1 << {1};", fieldname , i ));

					}
					sw.WriteLine("\t\t#endregion");
					sw.WriteLine("\n");

					List<string> fieldnames = new List<string>();
					for (int i = 8; i < it.arraySize; i++) 
					{
						SerializedProperty dataPoint = it.GetArrayElementAtIndex(i);
						string fieldname = string.IsNullOrEmpty(dataPoint.stringValue) ? "Layer" + i : dataPoint.stringValue.Replace(" ", "_");
						sw.WriteLine(string.Format("\t\tpublic const int {0}\t\t\t=\t1 << {1};", fieldname , i ));
						fieldnames.Add(string.Format("\"{0}\"", fieldname));
					}

					string fieldnameStr = "";
					string gap = "";
					for(int i = 0; i < fieldnames.Count; i ++)
					{
						fieldnameStr += gap;
						fieldnameStr += fieldnames[i];
						gap = ",";
					}


					sw.WriteLine("\n");
					sw.WriteLine("\t\tpublic static int           customBeginIndex = 8;");
					sw.WriteLine("\t\tpublic static string[]      customLayers = {"+fieldnameStr+"};");

					sw.WriteLine("\t}");
					sw.WriteLine("}");
					File.WriteAllText(Application.dataPath + "/Game/Scripts/Unity/GameLayerClass.cs", sw.ToString(), System.Text.Encoding.UTF8);
					AssetDatabase.Refresh();
					break;
				}
			}
			
#endif
		}


		public static void GenerateGameLayerEnum ()
		{
			
			#if UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9
			
			SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
			SerializedProperty it = tagManager.GetIterator();
			
			StringWriter sw = new StringWriter();
			sw.WriteLine("namespace Games");
			sw.WriteLine("{");

			sw.WriteLine("\t[System.Flags]");
			sw.WriteLine("\tpublic enum GameLayer");
			sw.WriteLine("\t{");
			
			sw.WriteLine("\t\t#region Unity Default Lock");
			int i = 0;
			while (it.NextVisible(true))
			{
				if(it.name.StartsWith("Builtin Layer"))
				{
					string fieldname = string.IsNullOrEmpty(it.stringValue) ? "Layer" + i : it.stringValue.Replace(" ", "_");
					sw.WriteLine(string.Format("\t\t{0}\t\t\t=\t1 << {1},", fieldname , i ));
					i ++;
				}
				
				if(i >= 8) break;
			}
			
			sw.WriteLine("\t\t#endregion");
			sw.WriteLine("\n");
			
			
			List<string> fieldnames = new List<string>();
			
			while (it.NextVisible(true))
			{
				if(it.name.StartsWith("User Layer"))
				{
					string fieldname = string.IsNullOrEmpty(it.stringValue) ? "Layer" + i : it.stringValue.Replace(" ", "_");
					sw.WriteLine(string.Format("\t\t{0}\t\t\t=\t1 << {1},", fieldname , i ));
					fieldnames.Add(string.Format("\"{0}\"", fieldname));
					
					i ++;
				}
				
				if(i >= 32) break;
			}
			
			
			sw.WriteLine("\n");
			
			sw.WriteLine("\t}");
			sw.WriteLine("}");
			File.WriteAllText(Application.dataPath + "/Game/Scripts/Unity/GameLayer.cs", sw.ToString(), System.Text.Encoding.UTF8);
			AssetDatabase.Refresh();
			#else
			
			SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
			SerializedProperty it = tagManager.GetIterator();
			
			while (it.NextVisible(true))
			{
				if(it.name == "layers")
				{
					StringWriter sw = new StringWriter();
					sw.WriteLine("namespace Games");
					sw.WriteLine("{");
					sw.WriteLine("\t[System.Flags]");
					sw.WriteLine("\tpublic enum GameLayer");
					sw.WriteLine("\t{");
					
					sw.WriteLine("\t\t#region Unity Default Lock");
					for (int i = 0; i < 8; i++) 
					{
						SerializedProperty dataPoint = it.GetArrayElementAtIndex(i);
						string fieldname = string.IsNullOrEmpty(dataPoint.stringValue) ? "Layer" + i : dataPoint.stringValue.Replace(" ", "_");
						sw.WriteLine(string.Format("\t\t{0}\t\t\t=\t1 << {1},", fieldname , i ));
						
					}
					sw.WriteLine("\t\t#endregion");
					sw.WriteLine("\n");
					
					List<string> fieldnames = new List<string>();
					for (int i = 8; i < it.arraySize; i++) 
					{
						SerializedProperty dataPoint = it.GetArrayElementAtIndex(i);
						string fieldname = string.IsNullOrEmpty(dataPoint.stringValue) ? "Layer" + i : dataPoint.stringValue.Replace(" ", "_");
						sw.WriteLine(string.Format("\t\t{0}\t\t\t=\t1 << {1},", fieldname , i ));
						fieldnames.Add(string.Format("\"{0}\"", fieldname));
					}
					
				
					
					sw.WriteLine("\n");
					
					sw.WriteLine("\t}");
					sw.WriteLine("}");
					File.WriteAllText(Application.dataPath + "/Game/Scripts/Unity/GameLayer.cs", sw.ToString(), System.Text.Encoding.UTF8);
					AssetDatabase.Refresh();
					break;
				}
			}
			
			#endif
		}
    }
}

#endif