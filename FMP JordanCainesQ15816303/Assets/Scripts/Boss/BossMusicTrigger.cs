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
        if (BossScript.IsDead)
        {
            ThisGameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        LevelMusic.enabled = false;
        BossMusic.enabled = true;
        BossScript.IsAggro = true;

    }

    private void OnTriggerExit(Collider other)
    {
        BossScript.IsAggro = false;
        BossMusic.enabled = false;
        LevelMusic.enabled = true;
    }
}
