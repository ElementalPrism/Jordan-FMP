using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StopAttacking : MonoBehaviour
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

    //These functions are called from animations to stop certain animations

    public void Stop()
    {
        PlayerChar.StopAttack();
    }

    public void BossStopBlock()
    {
        BossChar.StopBlock();
    }

}
