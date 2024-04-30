using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{

    public GameObject CoinInfo;
    public static int CoinAmount;
    public static int CollectedAmount;

    int AmountForLife = 50;
    int LifeIncrease = 1;
    int CoinReset = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinInfo.GetComponent<Text>().text = "x " + CoinAmount;

        if (CollectedAmount == AmountForLife)
        {
            LivesManager.LivesAmount = LivesManager.LivesAmount + LifeIncrease;
            CollectedAmount = CoinReset;
        }
    }
}
