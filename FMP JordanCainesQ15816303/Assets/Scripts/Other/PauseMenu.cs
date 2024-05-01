using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    int CoinReset = 0;
    int Lobby = 1;
    int MainMenuValue = 0;

    [SerializeField] GameObject PauseButtons;
    [SerializeField] GameObject SettingsButtons;

    [SerializeField] Slider CameraXSlider;
    [SerializeField] Slider CameraYSlider;
    [SerializeField] Slider MusicVolumeSlider;
    [SerializeField] Slider SFXVolumeSlider;

    float DefaultXSlider = 300f;
    float DefaultYSlider = 2f;
    float DefaultMusicSlider = 0.5f;
    float DefaultSFXSlider = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SettingsManager.NewXSpeed= CameraXSlider.value;
        SettingsManager.NewYSpeed= CameraYSlider.value;
        SettingsManager.NewMusicVolume = MusicVolumeSlider.value;
        SettingsManager.NewSFXVolume = SFXVolumeSlider.value;
    }

    public void UnPause()
    {
        Pause.IsPaused = false;
        UnityEngine.Cursor.visible = false;
    }

    public void ReturnToLobby()
    {
        Pause.IsPaused = false;
        CoinCounter.CoinAmount = CoinReset;
        CoinCounter.CollectedAmount = CoinReset;
        SceneManager.LoadScene(Lobby);

    }

    public void QuitToMainMenu()
    {
        Pause.IsPaused = false;
        CoinCounter.CoinAmount = CoinReset;
        CoinCounter.CollectedAmount = CoinReset;
        SceneManager.LoadScene(MainMenuValue);
    }


    public void OpenSettings()
    {
        PauseButtons.SetActive(false);
        SettingsButtons.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsButtons.SetActive(false);
        PauseButtons.SetActive(true);
    }

    public void ReturnToDefault()
    {   
        SettingsManager.NewXSpeed = DefaultXSlider;
        SettingsManager.NewYSpeed = DefaultYSlider;
        SettingsManager.NewMusicVolume = DefaultMusicSlider;
        SettingsManager.NewSFXVolume = DefaultSFXSlider;
        CameraXSlider.value = DefaultXSlider;
        CameraYSlider.value = DefaultYSlider;
        MusicVolumeSlider.value = DefaultMusicSlider;
        SFXVolumeSlider.value = DefaultSFXSlider;

    }
}
