using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeath : MonoBehaviour
{
    public Player PlayerChar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Death() //Removes a life from the player (is called from the player death animation)
    {
        PlayerChar.RemoveLife();
    }
}
