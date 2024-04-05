using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{

    public GameObject CoinInfo;
    public static int CoinAmount;
    public static int CollectedAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinInfo.GetComponent<Text>().text = "x " + CoinAmount;

        if (CollectedAmount == 50)
        {
            LivesManager.LivesAmount = LivesManager.LivesAmount + 1;
            CollectedAmount = 0;
        }
    }
}
