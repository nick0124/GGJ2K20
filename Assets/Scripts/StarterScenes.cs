using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class StarterScenes : MonoBehaviour
{
    public enum Arrow { LEFT = -1, RIGHT = 1,}

    private Arrow _arrow = Arrow.LEFT;

    public GameObject[] levels;


    [SerializeField] private Text count;
    [SerializeField] private Button left;
    [SerializeField] private Button right;
    private void Awake()
    {
        PlayerPrefs.DeleteAll();
        GameData.PlayerCount = GameData.PlayerMin;
        UpdateUI();
    }

    public void ClickPlay()
    {
        //SceneManager.LoadScene(Random.Range(1, 2)); // Случайный выбор
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
        }
        int l = Random.Range(0, 100);
        if (l < 51)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
        
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

    public void ClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
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
