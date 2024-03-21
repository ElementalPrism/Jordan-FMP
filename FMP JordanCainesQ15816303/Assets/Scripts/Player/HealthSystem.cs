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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerChar.Health >= 8)
        {
            HealthUI.sprite = Health8;
        }

        if (PlayerChar.Health == 7)
        {
            HealthUI.sprite = Health7;
        }


        if (PlayerChar.Health == 6)
        {
            HealthUI.sprite = Health6;
        }


        if (PlayerChar.Health == 5)
        {
            HealthUI.sprite = Health5;
        }


        if (PlayerChar.Health == 4)
        {
            HealthUI.sprite = Health4;
        }
            
           
        if (PlayerChar.Health == 3)
        {
            HealthUI.sprite = Health3;
        }


        if (PlayerChar.Health == 2)
        {
            HealthUI.sprite = Health2;
        }


        if (PlayerChar.Health == 1)
        {
            HealthUI.sprite = Health1;
        }


        if (PlayerChar.Health <= 0)
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
