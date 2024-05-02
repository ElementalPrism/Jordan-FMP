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

    int Mission1Value = 1;
    int Mission2Value = 2;
    int Mission3Value = 3;
    int Mission4Value = 4;
    int Mission5Value = 5;
    int Mission6Value = 6;
    int Mission7Value = 7;
    int Mission8Value = 8;

    float ColourReset = 1f;

    float RColour = 0.23f;
    float GColour = 0.92f;
    float BColour = 0.78f;

    int Level1 = 3;



    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.visible = true;
    }

    // Update is called once per frame
    void Update() //Changes the button colour on the mission select screen if the player has collected the corresponding diamond, allows the player to select the next mission, if available
    {
        if (Collected1)
        {
            Button1.color = new Color(RColour, GColour, BColour);
            Mission2Button.SetActive(true);
        }
        else if (!Collected1) //Resets everything back if the player recieves a game over
        {
            Button1.color = new Color(ColourReset, ColourReset, ColourReset);
            Button2.color = new Color(ColourReset, ColourReset, ColourReset);
            Button3.color = new Color(ColourReset, ColourReset, ColourReset);
            Button4.color = new Color(ColourReset, ColourReset, ColourReset);
            Button5.color = new Color(ColourReset, ColourReset, ColourReset);
            Button6.color = new Color(ColourReset, ColourReset, ColourReset);
            Button7.color = new Color(ColourReset, ColourReset, ColourReset);
            Button8.color = new Color(ColourReset, ColourReset, ColourReset);
            Mission2Button.SetActive(false);
            Mission3Button.SetActive(false);
            Mission4Button.SetActive(false);
            Mission5Button.SetActive(false);
            Mission6Button.SetActive(false);
            Mission7Button.SetActive(false);
            Mission8Button.SetActive(false);
        }

        if (Collected2) 
        {
            Button2.color = new Color(RColour, GColour, BColour);
            Mission2Button.SetActive(true);
            Mission3Button.SetActive(true);
        }

        if (Collected3)
        {
            Button3.color = new Color(RColour, GColour, BColour);
            Mission3Button.SetActive(true);
            Mission4Button.SetActive(true);
        }

        if (Collected4)
        {
            Button4.color = new Color(RColour, GColour, BColour);
            Mission4Button.SetActive(true);
            Mission5Button.SetActive(true);
        }

        if (Collected5)
        {
            Button5.color = new Color(RColour, GColour, BColour);
            Mission5Button.SetActive(true);
            Mission6Button.SetActive(true);
        }

        if (Collected6)
        {
            Button6.color = new Color(RColour, GColour, BColour);
            Mission6Button.SetActive(true);
            Mission7Button.SetActive(true);
        }

        if (Collected7)
        {
            Button7.color = new Color(RColour, GColour, BColour);
            Mission7Button.SetActive(true);
            Mission8Button.SetActive(true);
        }

        if (Collected8)
        {
            Button8.color = new Color(RColour, GColour, BColour);
            Mission8Button.SetActive(true);
        }





        


    }

    //Each of these functions stores the current mission number and then loads the main level

    public void Mission1()
    {
        Level1Manager.CurrentMission = Mission1Value;
        SceneManager.LoadScene(Level1);
    }

    public void Mission2()
    {
        Level1Manager.CurrentMission = Mission2Value;
        SceneManager.LoadScene(Level1);
    }

    public void Mission3()
    {
        Level1Manager.CurrentMission = Mission3Value;
        SceneManager.LoadScene(Level1);
    }
    public void Mission4()
    {
        Level1Manager.CurrentMission = Mission4Value;
        SceneManager.LoadScene(Level1);
    }
    public void Mission5()
    {
        Level1Manager.CurrentMission = Mission5Value;
        SceneManager.LoadScene(Level1);
    }
    public void Mission6()
    {
        Level1Manager.CurrentMission = Mission6Value;
        SceneManager.LoadScene(Level1);
    }
    public void Mission7()
    {
        Level1Manager.CurrentMission = Mission7Value;
        SceneManager.LoadScene(Level1);
    }
    
    public void Mission8()
    {
        Level1Manager.CurrentMission = Mission8Value;
        SceneManager.LoadScene(Level1);
    }
}
