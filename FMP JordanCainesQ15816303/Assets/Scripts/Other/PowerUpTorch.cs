using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTorch : MonoBehaviour
{
    public GameObject ThisObject;
    public GameObject ParticleEffect;
    public bool IsActivated;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update() //Triggers the particle effect on the torch if the potion is unlocked
    {        
        if (!IsActivated)
        {
            if (PowerUpManager.GravityPotionUnlocked == false)
            {
               ParticleEffect.SetActive(false);
            }
            
            
        }



        if (PowerUpManager.GravityPotionUnlocked == true)
        {
            ParticleEffect.SetActive(true);
        }


    }
}
