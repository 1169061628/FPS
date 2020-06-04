using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CreateJson : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        WriteJson();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void WriteJson()
    {
        StringBuilder builder = new StringBuilder();
        JsonWriter writer = new JsonWriter(builder);

        /*writer.WriteArrayStart();
        writer.Write(1);
        writer.Write(2);
        writer.Write(3);

        writer.WriteObjectStart();
        writer.WritePropertyName("color");
        writer.Write("Blue");
        writer.WriteObjectEnd();
        writer.WriteArrayEnd();*/
        writer.WriteObjectStart();
        writer.WritePropertyName("name");
        writer.Write("zhangsan"); 
        writer.WritePropertyName("age");
        writer.Write(20);
        writer.WriteObjectEnd();
        Debug.Log(builder.ToString());
    }
}
