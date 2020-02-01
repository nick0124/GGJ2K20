using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelStatistic : MonoBehaviour
{
    [SerializeField] private GameObject btnRestart;
    [SerializeField] private GameObject btnNext;
    private void Start()
    {
        for (int i = 1; i <= GameData.PlayerCount; i++)
        {
            if (PlayerPrefs.GetInt($"Player{i}") < GameData.MaxCountBal)
            {
                btnNext.SetActive(true);
                btnRestart.SetActive(false);
            }
            else
            {
                btnRestart.SetActive(true);
                btnNext.SetActive(false);
            }
        }
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
