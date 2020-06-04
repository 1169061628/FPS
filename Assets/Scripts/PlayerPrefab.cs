using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefab : MonoBehaviour
{
    public Text text;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("score");
        text.text = PlayerPrefs.GetInt("score").ToString();
        /*PlayerPrefs.SetInt("ID", 10);
        PlayerPrefs.SetFloat("weight", 20.5f);
        PlayerPrefs.SetString("PlayerName", "王大锤");

        Debug.Log(PlayerPrefs.GetInt("ID"));
        Debug.Log(PlayerPrefs.GetFloat("weight"));
        Debug.Log(PlayerPrefs.GetString("PlayerName"));

        PlayerPrefs.DeleteKey("weight");
        Debug.Log(PlayerPrefs.GetFloat("weight"));
        PlayerPrefs.DeleteAll();
        Debug.Log(PlayerPrefs.GetString("PlayerName"));*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            score += 10;
            PlayerPrefs.SetInt("score",score);
            //PlayerPrefs.Save();
            text.text = PlayerPrefs.GetInt("score").ToString();
        }
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
