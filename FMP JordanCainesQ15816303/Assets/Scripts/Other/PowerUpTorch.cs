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
        //if (DiamondManager.DiamondAmount < 5)
        //{
        //    ThisObject.SetActive(false);
        //}
        //else if (DiamondManager.DiamondAmount >= 5)
        //{
        //    ThisObject.SetActive(true);
        //}

    }

    // Update is called once per frame
    void Update()
    {        
        if (!IsActivated)
        {
            ParticleEffect.SetActive(false);
            PowerUpManager.GravityPotionUnlocked = false;
        }
        else if (IsActivated)
        {
            ParticleEffect.SetActive(true);
            PowerUpManager.GravityPotionUnlocked = true;
        }



    }
}
