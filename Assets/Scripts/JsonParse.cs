using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class Player
{
    public string Name { get; set; }
    public int age { get; set; }
    public bool isBoy { get; set; }
}
public class JsonParse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //CreateJson();   
        //LoadJson();
        ParseToJson();
    }
    public void CreateJson()
    {
        JsonData data = new JsonData();
        data["name"] = "zhangsan";
        data["age"] = 22;
        data["sex"] = true;

        data["options"] = new JsonData();
        data["options"]["country"] = "China";
        data["options"]["city"] = "重庆";

        string str = data.ToJson();

        Debug.Log(str);

        JsonData obj = JsonMapper.ToObject(str);
        Debug.Log(obj.IsArray);
        Debug.Log(obj.IsObject);

        Debug.Log(obj["options"]["country"]);
        Debug.Log(obj["options"]["city"]);
        Debug.Log(obj["name"]);
    }
    public void ParseToJson()
    {
        Player p = new Player();
        p.Name = "zhangsan";
        p.age = 22;
        string str = JsonMapper.ToJson(p);
        Debug.Log(str);
    }

    public void LoadJson()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("config");//不用加后缀
        string str2 = FileUtil.GetTextFromStreamingAssets("config.txt");//需要加后缀
        string str = textAsset.text;

        JsonData data = JsonMapper.ToObject(str);
        Debug.Log(data["Version"]);
        Debug.Log(data["Company"]);
        Debug.Log(data["Date"]);
    }
}