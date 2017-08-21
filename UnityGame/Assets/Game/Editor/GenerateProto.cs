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

    public static void GenerateLua()
	{

		string projectName = Path.GetDirectoryName(Application.dataPath + "/../");

		string dir = Application.dataPath + "/../../svn/proto";
		switch(projectName)
		{
		case "Game":
			dir = Application.dataPath + "/../../../Gidea-MT-Proto";
			break;
		}


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
