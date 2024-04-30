using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    public GameObject LivesInfo;
    public static int LivesAmount = 4;

    int NoLives = 0;
    int CoinReset = 0;
    int DiamondReset = 0;
    int LivesReset = 4;
    int GameOver = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LivesInfo.GetComponent<Text>().text = "x " + LivesAmount;

        if (LivesAmount <= NoLives)
        {
            CoinCounter.CoinAmount = CoinReset;
            CoinCounter.CollectedAmount = CoinReset;
            DiamondManager.DiamondAmount = DiamondReset;
            MissionSelector.Collected1 = false;
            MissionSelector.Collected2 = false;
            MissionSelector.Collected3 = false;
            MissionSelector.Collected4 = false;
            MissionSelector.Collected5 = false;             
            MissionSelector.Collected6 = false;
            MissionSelector.Collected7 = false;
            MissionSelector.Collected8 = false;
            LivesAmount = LivesReset;
            SceneManager.LoadScene(GameOver);
        }
    }
}
