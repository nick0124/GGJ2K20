using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Jenya : MonoBehaviour
{
    public static int points_1, points_2, points_3, points_4;
    public Text textPoints_1, textPoints_2, textPoints_3, textPoints_4;
    public GameObject player_1, player_2, player_3, player_4;
    public Text scoreText;
    public GameObject[] windowsObj;
    public window[] windows;
    public static int lastFiksetWindow;
    bool stopGame = false;
    int a = -1;
    void Start()
    {
        points_1=points_2=points_3=points_4=0;
        if (GameData.PlayerCount== 2) { textPoints_3.gameObject.SetActive(false); textPoints_4.gameObject.SetActive(false);
            player_3.SetActive(false); player_4.SetActive(false);
        }
        if (GameData.PlayerCount == 3)
        {
            textPoints_4.gameObject.SetActive(false);player_4.SetActive(false);
        }
        InvokeRepeating("RunTimer", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(stopGame == true)
        {
            CancelInvoke("RunTimer");
            scoreText.text = "0";
            Calculation();
            SceneManager.LoadScene("Finish");
        }
        
        textPoints_1.text = points_1.ToString();
        textPoints_2.text = points_2.ToString();
        textPoints_3.text = points_3.ToString();
        textPoints_4.text = points_4.ToString();

        if (stopGame == false)
        {
            bool windowsRepair = true;
            foreach (var wind in windows)
            {
                if (wind.repair == false)
                {
                    windowsRepair = false;
                }
            }
            if (windowsRepair)
            {

                int w = Random.Range(0, windowsObj.Length - 1);
                if (a != w)
                {
                    windows[w].breakWindow();
                    a = w;
                }
                else
                {
                    w = Random.Range(0, windowsObj.Length - 1);
                    if (a != w)
                    {
                        windows[w].breakWindow();
                        a = w;
                    }
                    else
                    {
                        w = Random.Range(0, windowsObj.Length - 1);
                        if (a != w)
                        {
                            windows[w].breakWindow();
                            a = w;
                        }
                        else
                        {
                            w = Random.Range(0, windowsObj.Length - 1);
                            if (a != w)
                            {
                                windows[w].breakWindow();
                                a = w;
                            }
                        }
                    }
                }
            }
        }
    }            

    void RunTimer()
    {
        scoreText.text = (int.Parse(scoreText.text) - 1).ToString();
        if(scoreText.text == "0") 
        {
            stopGame = true;            
        }
    }

    void Calculation()
    {
        if (player_1.activeSelf)
        {
            if((points_1 > points_2)&&(points_1 > points_3)&&(points_1 > points_4))
            {
                int i = PlayerPrefs.GetInt("Player1");
                i++;
                PlayerPrefs.SetInt("Player1", i);
            }
            else
            {
                if (!PlayerPrefs.HasKey("Player1"))
                    PlayerPrefs.SetInt("Player1", 0);
            }
        }

        if (player_2.activeSelf)
        {
            if ((points_2 > points_1) && (points_2 > points_3) && (points_2 > points_4))
            {
                int i = PlayerPrefs.GetInt("Player2");
                i++;
                PlayerPrefs.SetInt("Player2", i);
            }
            else
            {
                if (!PlayerPrefs.HasKey("Player2"))
                    PlayerPrefs.SetInt("Player2", 0);
            }
        }

        if (player_3.activeSelf)
        {
            if ((points_3 > points_2) && (points_3 > points_1) && (points_3 > points_4))
            {
                int i = PlayerPrefs.GetInt("Player3");
                i++;
                PlayerPrefs.SetInt("Player3", i);
            }
            else
            {
                if (!PlayerPrefs.HasKey("Player3"))
                    PlayerPrefs.SetInt("Player3", 0);
            }
        }

        if (player_4.activeSelf)
        {
            if ((points_4 > points_2) && (points_4 > points_3) && (points_4 > points_1))
            {
                int i = PlayerPrefs.GetInt("Player4");
                i++;
                PlayerPrefs.SetInt("Player4", i);
            }
            else
            {
                if (!PlayerPrefs.HasKey("Player4"))
                    PlayerPrefs.SetInt("Player4", 0);
            }
        }
    }
}