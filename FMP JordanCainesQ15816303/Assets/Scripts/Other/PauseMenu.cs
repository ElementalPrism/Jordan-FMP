using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    int CoinReset = 0;
    int Lobby = 1;
    int MainMenuValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
