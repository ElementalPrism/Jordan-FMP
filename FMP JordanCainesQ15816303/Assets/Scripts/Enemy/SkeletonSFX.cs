using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSFX : MonoBehaviour
{

    [SerializeField] AudioSource SkeletonCharge;
    [SerializeField] AudioSource SkeletonDeath;
    bool StartedCharge = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Various SFX functions to be called by the animations

    public void PlayCharge() 
    {
        if (StartedCharge == false)
        {
            SkeletonCharge.Play();
            StartedCharge = true;
        }

    }

    public void PlayDeath()
    {
        SkeletonDeath.Play();
    }

    public void StopCharge()
    {
        StartedCharge = false;
    }
}
