using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class window : MonoBehaviour
{
    public bool repair = true;
    private int players;
    public Sprite[] sprite;
    // Start is called before the first frame update
    void Start()
    {
        players = GameData.PlayerCount;
        //repair = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void breakWindow()
    {
        repair = false;
        int r = Random.Range(1, 3);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite[r];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.name == "Player1")
        {
            if (!repair)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite[0];
                UI_Jenya.points_1++;
                repair = true;
            }
            
        }
        if (collision.name == "Player2")
        {
            if (!repair)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite[0];
                UI_Jenya.points_2++;
                repair = true;
            }

        }
        if (collision.name == "Player3")
        {
            if (!repair)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite[0];
                UI_Jenya.points_3++;
                repair = true;
            }

        }
        if (collision.name == "Player4")
        {
            if (!repair)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprite[0];
                UI_Jenya.points_4++;
                repair = true;
            }

        }
    }
}