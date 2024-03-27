using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public BucketPickUp BucketCheck;
    [SerializeField] Transform PlayerTransform;
    [SerializeField] float TriggerDistance;
    [SerializeField] GameObject ThisGameObject;
    [SerializeField] GameObject NewFlower;
    [SerializeField] GameObject Bucket;
    [SerializeField] GameObject Diamond3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector3.Distance(transform.position, PlayerTransform.position) < TriggerDistance) && (BucketCheck.IsHolding == true))
        {
            Bucket.SetActive(false);
            NewFlower.SetActive(true);
            Diamond3.SetActive(true);
            ThisGameObject.SetActive(false);



        }
    }
}
