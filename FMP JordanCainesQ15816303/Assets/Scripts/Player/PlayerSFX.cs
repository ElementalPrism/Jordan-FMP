using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    [SerializeField] AudioSource PlayerJumpSFX;
    [SerializeField] AudioSource PlayerLandSFX;
    [SerializeField] AudioSource PlayerWalkSFX;
    [SerializeField] AudioSource PlayerSwingSFX;
    [SerializeField] AudioSource PlayerHurtSFX;
    [SerializeField] AudioSource PlayerVictorySFX;
    [SerializeField] AudioSource LevelMusic;
    [SerializeField] AudioSource PowerUpMusic;
    
    //[SerializeField] AudioSource PlayerDeathSFX;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Various SFX functions that are called from animations

    public void PlayJump()
    {
        PlayerJumpSFX.Play();
    }

    public void PlayLand()
    {
        PlayerLandSFX.Play();
    }

    public void PlayWalk()
    {
        PlayerWalkSFX.Play();
    }

    public void PlaySwing()
    {
        PlayerSwingSFX.Play();
    }
    public void PlayHurt()
    {
        PlayerHurtSFX.Play();
    }

    public void PlayVictory() //This stops all music then plays the victory theme
    {
        LevelMusic.Stop();
        if (PowerUpMusic)
        {
            PowerUpMusic.Stop();
        }
        PlayerVictorySFX.Play();
    }


}
