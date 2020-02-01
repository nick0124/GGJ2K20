using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Jenya : MonoBehaviour
{
    public static int points_1, points_2, points_3, points_4;
    public Text textPoints_1, textPoints_2, textPoints_3, textPoints_4;
    public GameObject player_1, player_2, player_3, player_4;
    public int z = 2;
    //public int windowsInt;
    public GameObject[] windowsObj;
    public window[] windows;
    public static int lastFiksetWindow;
    int a = -1;
    // Start is called before the first frame update
    void Start()
    {
        if (z== 2) { textPoints_3.gameObject.SetActive(false); textPoints_4.gameObject.SetActive(false);
            player_3.SetActive(false); player_4.SetActive(false);
        }
        if (z == 3)
        {
            textPoints_4.gameObject.SetActive(false);player_4.SetActive(false);
        }
                
        
    }

    // Update is called once per frame
    void Update()
    {
        textPoints_1.text = points_1.ToString();
        textPoints_2.text = points_2.ToString();
        textPoints_3.text = points_3.ToString();
        textPoints_4.text = points_4.ToString();

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
            if (a != w) {
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
