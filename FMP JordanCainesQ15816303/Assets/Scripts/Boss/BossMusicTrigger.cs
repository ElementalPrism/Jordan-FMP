using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusicTrigger : MonoBehaviour
{
    [SerializeField] Boss BossScript;
    [SerializeField] GameObject ThisGameObject;
    [SerializeField] AudioSource LevelMusic;
    [SerializeField] AudioSource BossMusic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Gets rid of the boss music trigger
        if (BossScript.IsDead)
        {
            ThisGameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other) //Activates boss music and allows the boss to attack the player when the player gets within the trigger
    {
        LevelMusic.enabled = false;
        BossMusic.enabled = true;
        BossScript.IsAggro = true;

    }

    private void OnTriggerExit(Collider other) //Stops the boss music and makes the boss stop attacking the player because the player is out of the boss' range
    {
        BossScript.IsAggro = false;
        BossMusic.enabled = false;
        LevelMusic.enabled = true;
    }
}
