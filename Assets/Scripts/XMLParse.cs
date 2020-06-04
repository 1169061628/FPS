using System.Collections;
using System.IO;
using System.Xml;
using UnityEngine;

public class Cards
{
    public int ID { get; set; }
    public string NAME { get; set; }
    public string File { get; set; }
}

public class XMLParse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //CreateXML();
        //LoadXml();
        //ModifyXml(1,false);
        AddXml(4, "Jack", "d.png", false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void CreateXML()
    {
        Debug.Log(Application.persistentDataPath);
        string path = Application.persistentDataPath + "/data2.xml";
        if (!File.Exists(path))
        {
            XmlDocument xml = new XmlDocument();//根
            XmlElement root = xml.CreateElement("objects");//第一个节点
            root.SetAttribute("ID", "1");

            XmlElement element = xml.CreateElement("element");
            element.SetAttribute("ID", "2");

            XmlElement Child1 = xml.CreateElement("child1");
            Child1.SetAttribute("id", "3");
            Child1.InnerText = "第一个孩子";

            XmlElement Child2 = xml.CreateElement("child2");
            Child2.SetAttribute("id", "4");
            Child2.InnerText = "第二个孩子";

            element.AppendChild(Child1);
            element.AppendChild(Child2);
            root.AppendChild(element);
            xml.AppendChild(root);

            xml.Save(path);
        }

    }
    void LoadXml()
    {
        ArrayList cardList = new ArrayList();
        Cards card = new Cards();
        XmlDocument xml = new XmlDocument();
        xml.Load(Application.persistentDataPath + "/data2.xml");
        XmlNodeList xmlNodeList = xml.SelectSingleNode("CardList").ChildNodes;
        foreach (XmlElement item1 in xmlNodeList)
        {
            foreach (XmlElement item2 in item1)
            {
                if (item2.Name == "ID")
                {
                    card.ID = int.Parse(item2.InnerText);
                }
                if (item2.Name == "Name")
                {
                    card.NAME = item2.InnerText;
                }
                if (item2.Name == "File")
                {
                    card.File = item2.InnerText;
                }
            }
            cardList.Add(card);

        }
        print(cardList.Count);
    }
    void ModifyXml(int theId,bool isUnlock)
    {
        print(Application.persistentDataPath);//输出保存路径

        XmlDocument xml = new XmlDocument();//new一个XMLDocument对象

        string path = Application.persistentDataPath + "/data2.xml";//文件路径

        xml.Load(path);//加载文件

        XmlNodeList xmlNodeList = xml.SelectSingleNode("CardList").ChildNodes;//获取CardList下面的所有子节点

        foreach (XmlElement item1 in xmlNodeList)//遍历所有的子节点

        {
            if(item1.GetAttribute("id") == theId.ToString())//查找id为传入值的结点
            {
                item1["Unlock"].InnerText = isUnlock.ToString();//使用索引器修改对应的值 大大滴方便！
            }
        }
        //记得每次修改之后映射到磁盘
        //这一句↓
        xml.Save(path);
        
    }
    void AddXml(int id,string name,string file,bool isUnlock)
    {
        string path = Application.persistentDataPath + "/data2.xml";
        XmlDocument xml = new XmlDocument();
        xml.Load(path);
        XmlNode cardList = xml.SelectSingleNode("CardList");

        XmlElement theCard = xml.CreateElement("Card");
        theCard.SetAttribute("id", "4");
        //创建下属的四个元素
        XmlElement theId = xml.CreateElement("ID");
        theId.InnerText = id.ToString();
        XmlElement theName = xml.CreateElement("Name");
        theName.InnerText = name;
        XmlElement theFile = xml.CreateElement("File");
        theFile.InnerText = file;
        XmlElement theLock = xml.CreateElement("Unlock");
        theLock.InnerText = isUnlock.ToString();


        theCard.AppendChild(theId);
        theCard.AppendChild(theName);
        theCard.AppendChild(theFile);
        theCard.AppendChild(theLock);


        cardList.AppendChild(theCard);
        //xml.AppendChild(cardList);

        xml.Save(path);

        print("Yes");
    }
}