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

    public void StartGame() //Loads the lobby scene
    {
        SceneManager.LoadScene(Lobby);
    }

    public void GameOverReturn() //Loads the main menu screen
    {
        SceneManager.LoadScene(TitleScreen);
    }


    public void ExitGame()
    {
        Application.Quit(); //closes the game

        #if UNITY_EDITOR  //This is here to prevent the editor from crashing after clicking application exit
        EditorApplication.ExitPlaymode(); //This bit of code was added from my following a tutorial ([(Taylor, V. (2021)] -> referenced in my code references in my FMP documentation), I can't really change it since its purpose is to stop unity from crashing.
#endif
    }

    public void OpenCredits() //Closes main menu buttons and opens the credits
    {
        MainMenuObjects.SetActive(false);
        CreditsObjects.SetActive(true);
    }

    public void CloseCredits() //Closes the credits and makes the main menu buttons reappear
    {
        MainMenuObjects.SetActive(true);
        CreditsObjects.SetActive(false);
    }
}
