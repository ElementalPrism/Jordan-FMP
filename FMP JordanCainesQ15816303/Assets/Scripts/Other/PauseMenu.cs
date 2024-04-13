using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
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
    }

    public void ReturnToLobby()
    {
        Pause.IsPaused = false;
        SceneManager.LoadScene(1);

    }

    public void QuitToMainMenu()
    {
        Pause.IsPaused = false;
        SceneManager.LoadScene(0);
    }
}
