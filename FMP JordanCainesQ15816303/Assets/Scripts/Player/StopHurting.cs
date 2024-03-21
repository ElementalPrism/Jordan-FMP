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

    public void StopPain()
    {
        PlayerChar.StopHurt();
    }

    public void StopBossPain()
    {
        BossChar.StopHurt();
    }

}
