using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTorch : MonoBehaviour
{
    public GameObject ThisObject;
    public GameObject ParticleEffect;
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

        if (DiamondManager.DiamondAmount < 5)
        {
            ParticleEffect.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (DiamondManager.DiamondAmount >= 5)
        {
            ParticleEffect.SetActive(true);
            PowerUpManager.GravityPotionUnlocked = true;
        }

    }
}
