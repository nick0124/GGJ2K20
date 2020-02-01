using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelStatistic : MonoBehaviour
{
    [SerializeField] private GameObject btnRestart;
    [SerializeField] private GameObject btnBackToMenu;
    private void Start()
    {
        // Подсчет очков
        
        
        
        // Если равное количество очков у игроков, то рестарт
        
        // Иначе выход в меню
        
    }

    public void ClickRestart()
    {
        PlayerPrefs.DeleteAll();
        //SceneManager.LoadScene(Random.Range(1, 2)); // Случайный выбор
        
        SceneManager.LoadScene(1);
    }
    
    public void ClickBackToMenu()
    {
        SceneManager.LoadScene("Main");
    }
}
