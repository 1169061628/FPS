using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SocialPlatforms;



public class FileUtil
{
    public static string GetTextFromStreamingAssets(string path)
    {
        string localpath = "";
        if(Application.platform == RuntimePlatform.Android)
        {
            localpath = Application.streamingAssetsPath + "/" + path;
        }
        else
        {
            localpath = "file:///" + Application.streamingAssetsPath + "/" + path;
        }
        WWW www = new WWW(localpath);
        if(www.error != null)
        {
            Debug.LogError("error while reading files:" + localpath);
            return "";
        }
        while (!www.isDone) { }//用于判断是否读取完成，未读取完成则不往下执行
        Debug.Log("File Content:" + www.text);
        return www.text;
    }
    public static void CopyFileFromSourceToDestination(string sourcePath,string desPath)
    {
        string[] files = Directory.GetFiles(sourcePath);//获取源路径下的所有文件
        foreach (string file in files)
        {
            string name = Path.GetFileName(file);//获取当前文件的文件名
            string dest = Path.Combine(desPath, name);//拼接文件路径
            File.Copy(file, dest);//复制操作
        }
    }
}
