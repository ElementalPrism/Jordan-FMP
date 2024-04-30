using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Text CoinText;
    public float SpinSpeed;
    public GameObject ThisCoin;

    public Player PlayerChar;
    [SerializeField] AudioSource CoinCollectSFX;
    //public int CoinCounter;

    int CoinValue = 1;
    float ValueNull = 0;

    int MaxHealth = 8;
    int HealthHeal = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(ValueNull, SpinSpeed * Time.deltaTime, ValueNull);
    }

    private void OnTriggerEnter(Collider other)
    {
        CoinCollectSFX.Play();
        CoinCounter.CoinAmount = CoinCounter.CoinAmount + CoinValue;
        CoinCounter.CollectedAmount = CoinCounter.CollectedAmount + CoinValue;

        if((PlayerChar.Health < MaxHealth) && (PlayerChar.IsDead == false))
        {
            PlayerChar.Health = PlayerChar.Health + HealthHeal;
        }


        
        ThisCoin.SetActive(false);
    }
}
