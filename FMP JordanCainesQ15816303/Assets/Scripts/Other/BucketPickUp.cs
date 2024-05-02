using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketPickUp : MonoBehaviour
{
    [SerializeField] GameObject ThisGameObject;
    [SerializeField] GameObject CarryLocation;
    [SerializeField] Transform PlayerTransform;
    [SerializeField] float TriggerDistance;
    [SerializeField] GameObject InteractIcon;
    [SerializeField] CapsuleCollider ThisCollider;

    public bool IsHolding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Vector3.Distance(transform.position, PlayerTransform.position) < TriggerDistance) && (IsHolding == false)) //Checks to see if the player is nearby and empty handed
        {
            InteractIcon.SetActive(true);


            if(Input.GetKeyDown(KeyCode.F)) //Player picks up bucket
            {
                IsHolding = true;
                ThisCollider.enabled = false;
            }

        }
        else
        {
            InteractIcon.SetActive(false);
        }



        if (IsHolding == true) //Moves bucket position to the players head
        {
            ThisGameObject.transform.position = CarryLocation.transform.position;
        }

    }
}
