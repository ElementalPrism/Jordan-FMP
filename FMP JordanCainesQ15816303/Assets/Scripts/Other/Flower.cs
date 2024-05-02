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
    [SerializeField] AudioSource LevelMusic;

    int TimeStop = 0;
    int TimeStart = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector3.Distance(PlantPot.transform.position, PlayerTransform.position) < TriggerDistance) && (BucketCheck.IsHolding == true)) //Checks if the player is nearby with the bucket
        {
            InteractIcon.SetActive(true);

            if(Input.GetKeyDown(KeyCode.F)) //Gets rid of the bucket and grows the flower, spawning the diamond
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


    IEnumerator DiamondDisableCamera() //Causes camera to look at the diamond for a small time
    {
        Time.timeScale = TimeStop;
        LevelMusic.Stop();
        DiamondAppearSFX.Play();
        yield return new WaitForSecondsRealtime(DiamondAppearTime);
        DiamondCamera.SetActive(false);
        Time.timeScale = TimeStart;
        LevelMusic.Play();
    }
}
