using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ForLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //TextAsset asset = Resources.Load<TextAsset>("config");
        //string news = asset.text;
        //string[] details = news.Split(',');
        //foreach (var item in details)
        //{
        //    Debug.Log(item);
        //}
        /*string path = Application.dataPath + "/config.txt";
        string content = File.ReadAllText(path);
        Debug.Log(content);*/
        StartCoroutine(LoadXML());
    }
    //如何正确地加载StreamingAssets目录下的文件
    //1.直接使用file操作加载，此方式除了安卓平台都可以
    //2.使用WWW进行加载：各个平台都可以，此方式除了安卓不需要添加file前缀，其他都需要
    IEnumerator LoadXML()
    {
        string path = Application.streamingAssetsPath + "/config.txt";
        WWW www = new WWW("file://" + path);
        yield return www;
        Debug.Log(www.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
