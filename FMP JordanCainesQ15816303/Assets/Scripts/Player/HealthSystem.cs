using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Player PlayerChar;
    public Image HealthUI;
    public Sprite Health0;
    public Sprite Health1;
    public Sprite Health2;
    public Sprite Health3;
    public Sprite Health4;
    public Sprite Health5;
    public Sprite Health6;
    public Sprite Health7;
    public Sprite Health8;

    int HealthValue8 = 8;
    int HealthValue7 = 7;
    int HealthValue6 = 6;
    int HealthValue5 = 5;
    int HealthValue4 = 4;
    int HealthValue3 = 3;
    int HealthValue2 = 2;
    int HealthValue1 = 1;
    int HealthValue0 = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerChar.Health >= HealthValue8)
        {
            HealthUI.sprite = Health8;
        }

        if (PlayerChar.Health == HealthValue7)
        {
            HealthUI.sprite = Health7;
        }


        if (PlayerChar.Health == HealthValue6)
        {
            HealthUI.sprite = Health6;
        }


        if (PlayerChar.Health == HealthValue5)
        {
            HealthUI.sprite = Health5;
        }


        if (PlayerChar.Health == HealthValue4)
        {
            HealthUI.sprite = Health4;
        }
            
           
        if (PlayerChar.Health == HealthValue3)
        {
            HealthUI.sprite = Health3;
        }


        if (PlayerChar.Health == HealthValue2)
        {
            HealthUI.sprite = Health2;
        }


        if (PlayerChar.Health == HealthValue1)
        {
            HealthUI.sprite = Health1;
        }


        if (PlayerChar.Health <= HealthValue0)
        {
            HealthUI.sprite = Health0;
            PlayerChar.IsDead = true;
        }

        //for(int i = 0; i < 8; i++)
        //{
        //    if(PlayerChar.Health == i)
        //    {

        //    }
        //}
    }
}
