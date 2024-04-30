using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    public Player PlayerChar;
    bool Triggered;

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
        if (Triggered == false)
        {
         PlayerChar.RemoveLife();
         SceneManager.LoadScene(LobbyScene);
         Triggered = true;
        }

    }
}
