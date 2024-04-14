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

    public void StopCheer()
    {
        PlayerChar.StopVictory();
    }
}
