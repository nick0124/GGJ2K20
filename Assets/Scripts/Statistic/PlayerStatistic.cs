using UnityEngine;
using UnityEngine.UI;

public class PlayerStatistic : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Text _score;
    [SerializeField] private Image _filled;

    private void Start()
    {
        // TODO: Если есть данные об игроке, то мы выводим его в статистику, иначе скрываем
        if (!PlayerPrefs.HasKey(_name))
        {
            gameObject.SetActive(false);
            return;
        }
        
        _score.text = PlayerPrefs.GetInt(_name).ToString();
        //_filled.fillAmount = PlayerPrefs.GetInt(_name) / (100f * GameData.MaxCountBal);
        _filled.fillAmount = (float)PlayerPrefs.GetInt(_name) / GameData.MaxCountBal;
    }
}
