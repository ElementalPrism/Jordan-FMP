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

    public static float NewMusicVolume;
    public static float NewSFXVolume;

    public List<AudioSource> Music;
    public List<AudioSource> SFX;

    [SerializeField] CinemachineFreeLook ThisCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (AudioSource source in Music)
        {
            source.volume = NewMusicVolume;
        }

        foreach (AudioSource source in SFX)
        {
            
            source.volume = NewSFXVolume;
        }

        if(ThisCamera != null)
        {
            ThisCamera.m_XAxis.m_MaxSpeed = NewXSpeed;
            ThisCamera.m_YAxis.m_MaxSpeed = NewYSpeed;
        }

    }
}
