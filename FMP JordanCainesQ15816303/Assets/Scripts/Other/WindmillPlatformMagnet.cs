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

    private void OnTriggerEnter(Collider other)
    {
        PlayerSize = other.transform.localScale;
        other.transform.SetParent(transform);
        //other.transform.position.Set(transform.position.x, transform.position.y, transform.position.z);
    }

  

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
        other.transform.localScale = PlayerSize;
    }
}
