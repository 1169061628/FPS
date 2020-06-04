using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public int Id { get; set; }
    public int Level { get; set; }
    public string Name { get; set; }
}

public class CardMgr : MonoBehaviour
{
    public ArrayList cardList = new ArrayList();

    void GetAllCard()
    {
        string content = FileUtil.GetTextFromStreamingAssets("AllCards.txt");
        Debug.Log(content);
        JsonData data = JsonMapper.ToObject(content);
        JsonData list = data["cardList"];
        for(int i = 0; i < list.Count; i++)
        {
            int id = (int)list[i]["id"];
            int level = (int)list[i]["level"];
            string name = (string)list[i]["name"];

            Card card = new Card();
            card.Id = id;
            card.Level = level;
            card.Name = name;
            cardList.Add(card);
        }
        Debug.Log(cardList.Count);
    }
    // Start is called before the first frame update
    void Start()
    {
        GetAllCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
