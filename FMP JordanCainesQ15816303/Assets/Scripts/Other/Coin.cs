using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Text CoinText;
    public float SpinSpeed;
    public GameObject ThisCoin;
    //public int CoinCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, SpinSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        CoinCounter.CoinAmount = CoinCounter.CoinAmount + 1;
        ThisCoin.SetActive(false);
    }
}
