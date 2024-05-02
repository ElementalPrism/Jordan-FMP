using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{

    public GameObject CoinInfo;
    public static int CoinAmount;
    public static int CollectedAmount;
    [SerializeField] AudioSource OneUpSFX;

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
        CoinInfo.GetComponent<Text>().text = "x " + CoinAmount; //Updates Coin Text

        if (CollectedAmount == AmountForLife) //Gives the player an extra life upon collecting 50 coins
        {
            LivesManager.LivesAmount = LivesManager.LivesAmount + LifeIncrease;
            CollectedAmount = CoinReset;
            OneUpSFX.Play();
        }
    }
}
