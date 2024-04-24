using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureManager : MonoBehaviour
{
    public int TreasureNumber;
    public GameObject Diamond7;


    [SerializeField] float DiamondAppearTime;
    [SerializeField] GameObject DiamondCamera;
    [SerializeField] AudioSource DiamondAppearSFX;
    [SerializeField] AudioSource LevelMusic;
    bool DiamondSpawned;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((TreasureNumber <= 0) && (!DiamondSpawned))
        {
            DiamondSpawned = true;
            Diamond7.SetActive(true);
            StartCoroutine(DiamondDisableCamera());
        }
    }

    IEnumerator DiamondDisableCamera()
    {
        Time.timeScale = 0;
        LevelMusic.Stop();
        DiamondAppearSFX.Play();
        yield return new WaitForSecondsRealtime(DiamondAppearTime);
        DiamondCamera.SetActive(false);
        Time.timeScale = 1;
        LevelMusic.Play();
    }
}
