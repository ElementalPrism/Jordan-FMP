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

    int NoTreasure = 0;
    int TimeStop = 0;
    int TimeStart = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((TreasureNumber <= NoTreasure) && (!DiamondSpawned))
        {
            DiamondSpawned = true;
            Diamond7.SetActive(true);
            StartCoroutine(DiamondDisableCamera());
        }
    }

    IEnumerator DiamondDisableCamera()
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
