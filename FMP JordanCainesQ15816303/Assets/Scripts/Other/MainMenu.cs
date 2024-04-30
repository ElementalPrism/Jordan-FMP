using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject MainMenuObjects;
    [SerializeField] GameObject CreditsObjects;
    // Start is called before the first frame update

    int Lobby = 1;
    int TitleScreen = 0;

    void Start()
    {
        UnityEngine.Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(Lobby);
    }

    public void GameOverReturn()
    {
        SceneManager.LoadScene(TitleScreen);
    }


    public void ExitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #endif
    }

    public void OpenCredits()
    {
        MainMenuObjects.SetActive(false);
        CreditsObjects.SetActive(true);
    }

    public void CloseCredits()
    {
        MainMenuObjects.SetActive(true);
        CreditsObjects.SetActive(false);
    }
}
