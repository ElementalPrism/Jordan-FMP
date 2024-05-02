using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillRotation : MonoBehaviour
{
    public float SpinSpeed;

    float ValueNull = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate() //Mill Constantly rotates
    {
        transform.Rotate(ValueNull, ValueNull, SpinSpeed * Time.deltaTime);
    }
}
