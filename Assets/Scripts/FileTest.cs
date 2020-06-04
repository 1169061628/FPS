using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Application.dataPath);    //项目的Assets目录
        Debug.Log(Application.streamingAssetsPath);//项目目录下的StreamingAssets目录，只读，直接打包进项目，不进行压缩
        Debug.Log(Application.persistentDataPath);//持久化目录，可读可写
        Debug.Log(Application.temporaryCachePath);//临时缓存数据的路径
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
}
