using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool IsPaused;
    public GameObject PauseScreen;

    int TimeStop = 0;
    int TimeStart = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //Turns the pause menu on and off from clicking the esc key
        {
            if (!IsPaused)
            {
                IsPaused = true;
                UnityEngine.Cursor.visible = true;
            }
            else if (IsPaused)
            {
                IsPaused = false;
                UnityEngine.Cursor.visible = false;
            }
        }

        //Stops time whilst the game is paused, then restarts time after closing the pause menu

        if (IsPaused)
        {
            Time.timeScale = TimeStop;
            PauseScreen.SetActive(true);
        }
        else if (!IsPaused)
        {
            Time.timeScale = TimeStart;
            PauseScreen.SetActive(false);
        }


    }
}
