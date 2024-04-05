using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    public GameObject LivesInfo;
    public static int LivesAmount = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LivesInfo.GetComponent<Text>().text = "x " + LivesAmount;

        if (LivesAmount <= 0)
        {
            CoinCounter.CoinAmount = 0;
            CoinCounter.CollectedAmount = 0;
            DiamondManager.DiamondAmount = 0;
            MissionSelector.Collected1 = false;
            MissionSelector.Collected2 = false;
            MissionSelector.Collected3 = false;
            MissionSelector.Collected4 = false;
            MissionSelector.Collected5 = false;             
            MissionSelector.Collected6 = false;
            MissionSelector.Collected7 = false;
            MissionSelector.Collected8 = false;
            LivesAmount = 4;
            SceneManager.LoadScene(5);
        }
    }
}
