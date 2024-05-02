using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{

    float DefaultCameraYSpeed = 2f;
    float DefaultCameraXSpeed = 300f;
    float DefaultSFXVolume = 1f;


    public static float NewYSpeed;
    public static float NewXSpeed;

    public static float NewMusicVolume = 1f;
    public static float NewSFXVolume = 1f;

    public List<AudioSource> Music;
    public List<AudioSource> SFX;

    [SerializeField] CinemachineFreeLook ThisCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {//Sets the volume for everything in each list to it's corresponding setting volume
        foreach (AudioSource source in Music)
        {
            source.volume = NewMusicVolume;
        }

        foreach (AudioSource source in SFX)
        {
            
            source.volume = NewSFXVolume;
        }

        if(ThisCamera != null) //Sets the values of camera sensitivity to the ones within the settings menu
        {
            ThisCamera.m_XAxis.m_MaxSpeed = NewXSpeed;
            ThisCamera.m_YAxis.m_MaxSpeed = NewYSpeed;
        }

    }
}
