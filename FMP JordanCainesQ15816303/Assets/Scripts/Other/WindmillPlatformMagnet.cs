using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillPlatformMagnet : MonoBehaviour
{
    Vector3 PlayerSize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) //Attaches the player to the platform for smooth movement
    {
        PlayerSize = other.transform.localScale;
        other.transform.parent = transform;

    }




    private void OnTriggerExit(Collider other) //Unattaches the player from the platform
    {
        other.transform.SetParent(null);
        other.transform.localScale = PlayerSize;
    }
}
