using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSFX : MonoBehaviour
{

    [SerializeField] AudioSource SlimeMovement;
    [SerializeField] AudioSource SlimeDeath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Various SFX functions that are called from the animations

    public void PlayMovement()
    {
        SlimeMovement.Play();
    }

    public void PlayDeath()
    {
        SlimeDeath.Play();
    }

}
