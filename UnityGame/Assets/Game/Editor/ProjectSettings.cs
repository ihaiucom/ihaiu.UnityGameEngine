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
		public static string Tool
		{
			get 
			{
				return "";
			}
		}
	}


}
