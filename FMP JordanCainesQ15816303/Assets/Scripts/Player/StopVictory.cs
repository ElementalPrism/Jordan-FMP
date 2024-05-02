using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopVictory : MonoBehaviour
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

    //This function are called from the victory animation to stop the victoty animation and to allow the player to move again

    public void StopCheer()
    {
        PlayerChar.StopVictory();
    }
}
