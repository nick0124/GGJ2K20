using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectLevels : MonoBehaviour
{
    public GameObject[] levels;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
        }
        int l = Random.Range(0, levels.Length - 1);
        levels[l].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
