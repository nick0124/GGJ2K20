using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelStatistic : MonoBehaviour
{
    [SerializeField] private GameObject btnRestart;
    [SerializeField] private GameObject btnNext;
    
    [SerializeField] private Text Label;
    private void Start()
    {
        bool win = false;
        int playerId = 0;
        
        for (int i = 1; i <= GameData.PlayerCount; i++)
        {
            if (PlayerPrefs.GetInt($"Player{i}") != GameData.MaxCountBal) continue;
            
            win = true;
            playerId = i;
            break;
        }
        
        UpdateUI(win, playerId);
    }

    private void UpdateUI(bool win, int playerId)
    {
        btnNext.SetActive(!win);
        btnRestart.SetActive(win);

        Label.text = win ? $"ПОБЕДИТЕЛЬ\nИГРОК {playerId}" : "НИЧЬЯ\nПОПРОБУЙТЕ ЕЩЕ РАЗ";
    }

    public void ClickRestart()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Main");
    }
    
    public void ClickNext()
    {
        SceneManager.LoadScene(1);
    }
}
