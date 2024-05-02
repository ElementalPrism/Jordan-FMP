using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCheck : MonoBehaviour
{

    public Animator PlayerAnimator;
    int FloorLayer = 3;
    float NullAirSpeed = 0;
    public bool StopYVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //These 2 functions stops the animator from playing the falling animation, if the player is still on the platform but the player's raycast down isn't touching anything

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == FloorLayer)
        {
            StopYVelocity = true;
        }
            
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == FloorLayer)
        {;
            StopYVelocity = true;
        }
    }

    private void OnTriggerExit(Collider other) //Activates the player's y velocity
    {
        StopYVelocity = false;
    }
}
