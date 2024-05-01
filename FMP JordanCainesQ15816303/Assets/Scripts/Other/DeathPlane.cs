using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    public Player PlayerChar;
    [SerializeField] GameObject PlayerObject;
    [SerializeField] Transform RespawnLocation;
    bool Triggered;
    int Damage = 1;

    int LobbyScene = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(Triggered == false)
        {
           Triggered = true;
           PlayerChar.Health = PlayerChar.Health - Damage;
           PlayerObject.transform.position = RespawnLocation.position;
           Triggered = false;
        }


    }
}
