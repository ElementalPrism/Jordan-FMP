using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public BucketPickUp BucketCheck;
    [SerializeField] Transform PlayerTransform;
    [SerializeField] float TriggerDistance;
    [SerializeField] GameObject ThisGameObject;
    [SerializeField] GameObject PlantPot;
    [SerializeField] GameObject NewFlower;
    [SerializeField] GameObject Bucket;
    [SerializeField] GameObject Diamond3;
    [SerializeField] GameObject InteractIcon;

    [SerializeField] float DiamondAppearTime;
    [SerializeField] GameObject DiamondCamera;
    [SerializeField] AudioSource DiamondAppearSFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector3.Distance(PlantPot.transform.position, PlayerTransform.position) < TriggerDistance) && (BucketCheck.IsHolding == true))
        {
            InteractIcon.SetActive(true);

            if(Input.GetKeyDown(KeyCode.F))
            {
                BucketCheck.IsHolding = false;
                Bucket.SetActive(false);
                NewFlower.SetActive(true);
                Diamond3.SetActive(true);
                ThisGameObject.SetActive(false);
                StartCoroutine(DiamondDisableCamera());


            }

        }
        else
        {
            InteractIcon.SetActive(false);
        }

    }


    IEnumerator DiamondDisableCamera()
    {
        Time.timeScale = 0;
        DiamondAppearSFX.Play();
        yield return new WaitForSecondsRealtime(DiamondAppearTime);
        DiamondCamera.SetActive(false);
        Time.timeScale = 1;
    }
}
