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
    void Update() //Makes sure the camera sensitivity values and music and sfx values are kept to match the ones in the menu.
    {
        SettingsManager.NewXSpeed= CameraXSlider.value;
        SettingsManager.NewYSpeed= CameraYSlider.value;
        SettingsManager.NewMusicVolume = MusicVolumeSlider.value;
        SettingsManager.NewSFXVolume = SFXVolumeSlider.value;
    }

    public void UnPause() //Unpauses the game and closes the menu
    {
        Pause.IsPaused = false;
        UnityEngine.Cursor.visible = false;
    }

    public void ReturnToLobby() //player returns to lobby, resetting the coin count
    {
        Pause.IsPaused = false;
        CoinCounter.CoinAmount = CoinReset;
        CoinCounter.CollectedAmount = CoinReset;
        SceneManager.LoadScene(Lobby);

    }

    public void QuitToMainMenu() //Player quits to main menu
    {
        Pause.IsPaused = false;
        CoinCounter.CoinAmount = CoinReset;
        CoinCounter.CollectedAmount = CoinReset;
        SceneManager.LoadScene(MainMenuValue);
    }


    public void OpenSettings() //these close the pause buttons and opens the settings content
    {
        PauseButtons.SetActive(false);
        SettingsButtons.SetActive(true);
    }

    public void CloseSettings() //Closes the settings and re-opens the pause buttons
    {
        SettingsButtons.SetActive(false);
        PauseButtons.SetActive(true);
    }

    public void ReturnToDefault() //Reset all setting values to default
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
