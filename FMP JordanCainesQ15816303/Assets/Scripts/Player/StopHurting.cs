using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopHurting : MonoBehaviour
{
    public Player PlayerChar;
    public Boss BossChar;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //These functions are called from animations to stop certain animations and to allow the object to take damage again

    public void StopPain()
    {
        PlayerChar.StopHurt();
    }

    public void StopBossPain()
    {
        BossChar.StopHurt();
    }

}
