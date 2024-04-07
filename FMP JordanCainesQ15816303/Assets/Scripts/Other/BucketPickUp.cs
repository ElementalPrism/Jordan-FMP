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

    public bool IsHolding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Vector3.Distance(transform.position, PlayerTransform.position) < TriggerDistance) && (IsHolding == false))
        {
            InteractIcon.SetActive(true);
           // IsHolding = true;

            if(Input.GetKeyDown(KeyCode.F))
            {
                IsHolding = true;
            }

        }
        else
        {
            InteractIcon.SetActive(false);
        }



        if (IsHolding == true)
        {
            ThisGameObject.transform.position = CarryLocation.transform.position;
        }

    }
}
