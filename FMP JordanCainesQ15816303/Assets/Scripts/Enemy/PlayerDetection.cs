using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{

    public bool PlayerNoticed;
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        PlayerNoticed = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        Target = collision.gameObject;
    }

    private void OnCollisionExit(Collision collision)
    {
        PlayerNoticed = false;
    }

}
