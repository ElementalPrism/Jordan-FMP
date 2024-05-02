using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) //This sees if the other object has the jump killable script, and if it does, then deals damage to the object
    {
        if (other.gameObject.GetComponent<JumpKillable>())
        {
            other.gameObject.GetComponent<JumpKillable>().TakenHit = true;
        }
        else
        {
            //Do NOTHING
        }
    }


}
