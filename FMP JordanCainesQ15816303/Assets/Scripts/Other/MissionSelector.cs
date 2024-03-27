using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MissionSelector : MonoBehaviour
{
    public static bool Collected1;
    public static bool Collected2;
    public static bool Collected3;
    public static bool Collected4;
    public static bool Collected5;
    public static bool Collected6;
    public static bool Collected7;
    public static bool Collected8;

    [SerializeField] UnityEngine.UI.Image Button1;
    [SerializeField] UnityEngine.UI.Image Button2;
    [SerializeField] UnityEngine.UI.Image Button3;
    [SerializeField] UnityEngine.UI.Image Button4;
    [SerializeField] UnityEngine.UI.Image Button5;
    [SerializeField] UnityEngine.UI.Image Button6;
    [SerializeField] UnityEngine.UI.Image Button7;
    [SerializeField] UnityEngine.UI.Image Button8;

    [SerializeField] GameObject Mission2Button;
    [SerializeField] GameObject Mission3Button;
    [SerializeField] GameObject Mission4Button;
    [SerializeField] GameObject Mission5Button;
    [SerializeField] GameObject Mission6Button;
    [SerializeField] GameObject Mission7Button;
    [SerializeField] GameObject Mission8Button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Collected1)
        {
            Button1.color = new Color(0.23f,0.92f, 0.78f);
            Mission2Button.SetActive(true);
        }

        if (Collected2) 
        {
            Button2.color = new Color(0.23f, 0.92f, 0.78f);
            Mission2Button.SetActive(true);
            Mission3Button.SetActive(true);
        }

        if (Collected3)
        {
            Button3.color = new Color(0.23f, 0.92f, 0.78f);
            Mission3Button.SetActive(true);
            Mission4Button.SetActive(true);
        }

        if (Collected4)
        {
            Button4.color = new Color(0.23f, 0.92f, 0.78f);
            Mission4Button.SetActive(true);
            Mission5Button.SetActive(true);
        }

        if (Collected5)
        {
            Button5.color = new Color(0.23f, 0.92f, 0.78f);
            Mission5Button.SetActive(true);
            Mission6Button.SetActive(true);
        }

        if (Collected6)
        {
            Button6.color = new Color(0.23f, 0.92f, 0.78f);
            Mission6Button.SetActive(true);
            Mission7Button.SetActive(true);
        }

        if (Collected7)
        {
            Button7.color = new Color(0.23f, 0.92f, 0.78f);
            Mission7Button.SetActive(true);
            Mission8Button.SetActive(true);
        }

        if (Collected8)
        {
            Button8.color = new Color(0.23f, 0.92f, 0.78f);
            Mission8Button.SetActive(true);
        }
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
