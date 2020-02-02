using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelStatistic : MonoBehaviour
{
    [SerializeField] private GameObject btnRestart;
    [SerializeField] private GameObject btnNext;
    [SerializeField] private Text btnNextText;
    
    
    [SerializeField] private Text label;
    private void Start()
    {
        bool win = false;
        bool round = false;
        int playerId = 0;
        
        for (int i = 1; i <= GameData.PlayerCount; i++)
        {
            if (PlayerPrefs.GetInt($"Player{i}") != GameData.MaxCountBal)
            {
                if (PlayerPrefs.GetInt($"Player{i}") == GameData.MaxCountBal - 1)
                {
                    round = true;
                    GameData.RoundCount += 1;
                    break;
                }
                
                continue;
            }
            
            win = true;
            playerId = i;
            break;
            
        }
        
        UpdateUI(round, win, playerId);
    }

    private void UpdateUI(bool round, bool win, int playerId)
    {
        btnNext.SetActive(!win || round);
        btnRestart.SetActive(win);

        label.text = win ? $"ПОБЕДИТЕЛЬ\nИГРОК {playerId}" : "НИЧЬЯ\nПОПРОБУЙТЕ ЕЩЕ РАЗ";

        if (round)
        {
            label.text = "НУ КТО КОГО";
            btnNextText.text = $"РАУНД {GameData.RoundCount}";
        }
    }

    public void ClickRestart()
    {
        PlayerPrefs.DeleteAll();
        GameData.RoundCount = 1;
        SceneManager.LoadScene("Main");
    }
    
    public void ClickNext()
    {
        SceneManager.LoadScene(1);
    }
}
