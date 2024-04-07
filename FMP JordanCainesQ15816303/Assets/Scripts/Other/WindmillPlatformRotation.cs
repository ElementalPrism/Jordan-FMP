using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillPlatformRotation : MonoBehaviour
{
    public float RotationX;
    public float RotationY;
    public float RotationZ;
   // public GameObject ThisGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(RotationX, RotationY, RotationZ);
    }
}
