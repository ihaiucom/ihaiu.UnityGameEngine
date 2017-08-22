using System.Collections;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class GenerateProto 
{

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
            if (ext.Equals(".meta")) continue;
            files.Add(filename.Replace('\\', '/'));
        }
        foreach (string dir in dirs)
        {
            paths.Add(dir.Replace('\\', '/'));
            Recursive(dir, paths, files);
        }
    }

	public static string dir
	{
		get
		{
			string projectName = PathUtil.GetDirectoryName(Application.dataPath);

			string dir = Application.dataPath + "/../../svn/proto";
			switch(projectName)
			{
			case "Game":
				dir = Application.dataPath + "/../../../Gidea-MT-Proto";
				break;
			}


			if(!Directory.Exists(dir))
			{
				Loger.LogErrorFormat("proto dir 目录不存在，请到GenerateProto.cs 下修改. dir={0}", dir);
			}
			return dir;
		}
	}

	public static string sh
	{
		get
		{
			string projectName = PathUtil.GetDirectoryName(Application.dataPath);

			#if UNITY_EDITOR_WIN
			string file = Application.dataPath + "/../../Tools/protoc-gen-csharp/protogen_UnityGame.bat";
			switch(projectName)
			{
			case "Game":
				file = Application.dataPath + "/../../Tools/protoc-gen-csharp/protogen_UnityGame.bat";
				break;
			}


			if(!File.Exists(file))
			{
				Loger.LogErrorFormat("GenerateProto protogenxxx.bat 目录不存在，请到GenerateProto.cs 下修改. dir={0}", file);
			}

			#else
			string file = Application.dataPath + "/../../Tools/protoc-gen-csharp/protogen_UnityGame.sh";
			switch(projectName)
			{
			case "Game":
				file = Application.dataPath + "/../../Tools/protoc-gen-csharp/protogen_UnityGame.sh";
				break;
			}



			if(!File.Exists(file))
			{
				Loger.LogErrorFormat("GenerateProto protogenxxx.sh 目录不存在，请到GenerateProto.cs 下修改. dir={0}", file);
			}
			#endif



			return file;
		}
	}




	public static void GenerateCsharp()
	{

		#if UNITY_EDITOR_WIN
		ProcessStartInfo info = new ProcessStartInfo();
		info.FileName = "C:\\Windows\\System32\\cmd";
		info.Arguments = "/c " + sh ;
		info.WindowStyle = ProcessWindowStyle.Normal;
		info.UseShellExecute = true;
		info.WorkingDirectory = dir;
		info.ErrorDialog = true;
		Loger.Log(info.FileName + " " + info.Arguments);

		Process pro = Process.Start(info);
		//pro.WaitForExit();

		#else
		Loger.Log(sh);
		Shell.RunFile (sh, false);
		#endif

		AssetDatabase.Refresh();
	}

    public static void GenerateLua()
	{
		List<string> paths = new List<string>();
		List<string> files = new List<string>();

		Loger.Log (dir);
		Recursive(dir, paths, files);

		string protoExeDir =  Application.dataPath + "/../../Tools/protoc-gen-lua/";
		string protoc = protoExeDir+ "/protoc.exe";
		string protoc_gen_dir = "\"" + protoExeDir + "plugin/build.bat\"";
		string out_dir = Application.dataPath + "/Game/Lua/gen/pblua";

		Loger.Log (files.Count);

        foreach (string f in files)
        {
            string name = Path.GetFileName(f);
            string ext = Path.GetExtension(f);
            if (!ext.Equals(".proto")) continue;

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = protoc;
			info.Arguments = " --plugin=protoc-gen-lua=" + protoc_gen_dir + "  --lua_out=" + out_dir + " " + name ;
			info.WindowStyle = ProcessWindowStyle.Hidden;
            info.UseShellExecute = true;
            info.WorkingDirectory = dir;
            info.ErrorDialog = true;
			Loger.Log(info.FileName + " " + info.Arguments);

            Process pro = Process.Start(info);
            pro.WaitForExit();
        }
        AssetDatabase.Refresh();
    }
}
