using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class StarterScenes : MonoBehaviour
{
    public enum Arrow { LEFT = -1, RIGHT = 1,}

    private Arrow _arrow = Arrow.LEFT;

    [SerializeField] private Text count;
    [SerializeField] private Button left;
    [SerializeField] private Button right;

    private void Awake()
    {
        GameData.PlayerCount = GameData.PlayerMin;
        UpdateUI();
    }

    public void ClickPlay()
    {
        //SceneManager.LoadScene(Random.Range(1, 2)); // Случайный выбор
        
        SceneManager.LoadScene(1);
    }

    public void ClickArrow(int dir)
    {
        switch (dir)
        {
            case (int)Arrow.LEFT:
                GameData.PlayerCount--;
                break;
            case (int)Arrow.RIGHT:
                GameData.PlayerCount++;
                break;
        }
        
        UpdateUI();
    }

    private void SetLabel(string value)
    {
        count.text = value;
    }

    private void UpdateUI()
    {
        SetLabel(GameData.PlayerCount.ToString());

        left.interactable = GameData.PlayerCount > GameData.PlayerMin;
        right.interactable = GameData.PlayerCount < GameData.PlayerMax;
    }
}
