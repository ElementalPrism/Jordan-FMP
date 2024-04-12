using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSFX : MonoBehaviour
{
    [SerializeField] AudioSource SpawnAttackSFX;
    [SerializeField] AudioSource BlockAttackSFX;
    [SerializeField] AudioSource HitSFX;
    [SerializeField] AudioSource DeathSFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySpawnAttack()
    {
        SpawnAttackSFX.Play();
    }

    public void PlayBlockAttack()
    {
        BlockAttackSFX.Play();
    }

    public void PlayDeath()
    {
        DeathSFX.Play();
    }

    public void PlayHit()
    {
        HitSFX.Play();
    }
}
