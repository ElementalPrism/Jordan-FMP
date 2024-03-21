using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionSelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mission1()
    {
        Level1Manager.CurrentMission = 1;
        SceneManager.LoadScene(3);
    }

    public void Mission2()
    {
        Level1Manager.CurrentMission = 2;
        SceneManager.LoadScene(3);
    }

    public void Mission3()
    {
        Level1Manager.CurrentMission = 3;
        SceneManager.LoadScene(3);
    }
    public void Mission4()
    {
        Level1Manager.CurrentMission = 4;
        SceneManager.LoadScene(3);
    }
    public void Mission5()
    {
        Level1Manager.CurrentMission = 5;
        SceneManager.LoadScene(3);
    }
    public void Mission6()
    {
        Level1Manager.CurrentMission = 6;
        SceneManager.LoadScene(3);
    }
    public void Mission7()
    {
        Level1Manager.CurrentMission = 7;
        SceneManager.LoadScene(3);
    }
    
    public void Mission8()
    {
        Level1Manager.CurrentMission = 8;
        SceneManager.LoadScene(3);
    }
}
