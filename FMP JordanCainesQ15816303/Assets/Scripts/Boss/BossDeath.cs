using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : MonoBehaviour
{
    [SerializeField] Boss BossObject;
    [SerializeField] AudioSource LevelMusic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Death()  //Re-enabled the level music when the boss gets defeated
    {
        if (BossObject != null)
        {
            LevelMusic.enabled = true;
            BossObject.IsDead = true;
        }
    }
}
