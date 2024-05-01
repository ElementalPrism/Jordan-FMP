using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NPCSystem : MonoBehaviour
{
    [SerializeField] Transform PlayerTransform;
    bool IsTalking;
    public Player TargetPlayer;
    [SerializeField] float TalkDistance;
    [SerializeField] GameObject TextBackground;
    [SerializeField] GameObject NPCText;
    public string NPCSpeech1;
    public string NPCSpeech2;

    [SerializeField] GameObject InteractIcon;

    [SerializeField] bool IsTorch;
    [SerializeField] bool IsPowerUpSign;
    [SerializeField] bool IsSign;
    int TorchDiamondRequirement = 5;
    int TorchDiamondNumber;
    public bool GravityTorchActivated;
    [SerializeField] PowerUpTorch PowerUpTorchObject;

    public int WeedCounter;
    [SerializeField] GameObject Diamond4;
    [SerializeField] float DiamondAppearTime;
    [SerializeField] GameObject DiamondCamera;
    [SerializeField] AudioSource DiamondAppearSFX;
    [SerializeField] AudioSource LevelMusic;
    bool DiamondSpawned;


    int Mission1 = 1;
    int Mission2 = 2;
    int Mission3 = 3;
    int Mission4 = 4;
    int Mission5 = 5;
    int Mission6 = 6;
    int Mission7 = 7;
    int Mission8 = 8;

    int NoWeeds = 0;
    int GotDiamonds = 0;

    int TimeStop = 0;
    int TimeStart = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, PlayerTransform.position) < TalkDistance)
        {
            InteractIcon.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F) && (IsTalking == false))
            {
                IsTalking = true;
                InteractIcon.SetActive(false);
                TargetPlayer.CanMove = false;
                TextBackground.SetActive(true);
                NPCText.SetActive(true);

                if (Level1Manager.CurrentMission == Mission1)
                {
                    NPCText.GetComponent<Text>().text = "An evil skeleton has set up camp at the top of the mountain. Maybe your sword can give it a taste of it's own medicine!";
                }
                else if (Level1Manager.CurrentMission == Mission2)
                {
                    NPCText.GetComponent<Text>().text = "After you defeated that menace, I built a Windmill! I see something shiny up there...";
                }
                else if (Level1Manager.CurrentMission == Mission3)
                {
                    NPCText.GetComponent<Text>().text = "I've noticed a dying flower in the forest. Maybe some water from the well will help it.";
                }
                else if (Level1Manager.CurrentMission == Mission4)
                {
                    if (WeedCounter > NoWeeds)
                    {
                        NPCText.GetComponent<Text>().text = "This place has been overrun with weeds! You have " + WeedCounter + "to kill";
                    }
                    else if (WeedCounter == NoWeeds)
                    {
                        NPCText.GetComponent<Text>().text = "You killed all the weeds! Take this shiny thing I found as a thank you present.";
                    }

                }
                else if (Level1Manager.CurrentMission == Mission5)
                {
                    NPCText.GetComponent<Text>().text = "That flower became a giant sunflower! I think I see something shiny on it's petals.";
                }
                else if (Level1Manager.CurrentMission == Mission6)
                {
                    NPCText.GetComponent<Text>().text = "I heard some sounds coming from inside the well but I am too scared to investigate.";
                }
                else if (Level1Manager.CurrentMission == Mission7)
                {
                    NPCText.GetComponent<Text>().text = "There is a legend about some treasure being left at the bottom of this well. I don't know if this is true as I am scared to enter the well.";
                }
                else if (Level1Manager.CurrentMission == Mission8)
                {
                    NPCText.GetComponent<Text>().text = "I noticed a torch during my trek up another mountain. Maybe that torch is linked to the mysteries of the well!";
                }




                if (IsPowerUpSign)
                {
                    if (PowerUpManager.GravityPotionUnlocked == false)
                    {
                       NPCText.GetComponent<Text>().text = NPCSpeech1;
                    }
                    else if (PowerUpManager.GravityPotionUnlocked == true)
                    {
                       NPCText.GetComponent<Text>().text = NPCSpeech2;
                    }

                }

                if (IsSign)
                {
                    NPCText.GetComponent<Text>().text = NPCSpeech1;
                }









                if (IsTorch)
                {
                    if ((TorchDiamondNumber <= GotDiamonds) && (!GravityTorchActivated))
                    {
                        PowerUpTorchObject.IsActivated = true;
                        GravityTorchActivated = true;
                        PowerUpManager.GravityPotionUnlocked = true;
                        NPCText.GetComponent<Text>().text = NPCSpeech1;
                    }
                    else if (GravityTorchActivated) 
                    {
                        NPCText.GetComponent<Text>().text = NPCSpeech1;
                    }
                    else if (TorchDiamondNumber > GotDiamonds)
                    {
                        NPCText.GetComponent<Text>().text = "You need " + TorchDiamondNumber + " more diamond(s) to light this torch.";
                    }

                }
                

            }
            else if  ((Input.anyKeyDown) && (IsTalking = true))
            {
                IsTalking = false;
                InteractIcon.SetActive(true);
                TargetPlayer.CanMove = true;
                TextBackground.SetActive(false);
                NPCText.SetActive(false);
            }

        }
        else if (Vector3.Distance(transform.position, PlayerTransform.position) > TalkDistance)
        {
            InteractIcon.SetActive(false);
        }





        if ((Vector3.Distance(transform.position, PlayerTransform.position) > TalkDistance) && (IsTalking == true))
        {
            IsTalking = false;
            InteractIcon.SetActive(true);
            TargetPlayer.CanMove = true;
            TextBackground.SetActive(false);
            NPCText.SetActive(false);
        }


        if (IsTorch)
        {
            TorchDiamondNumber = TorchDiamondRequirement - DiamondManager.DiamondAmount;
        }

        if (WeedCounter <= NoWeeds)
        {
            if ((!IsPowerUpSign) && (!IsSign) && (!DiamondSpawned))
            {
               DiamondSpawned = true;
              Diamond4.SetActive(true);
              StartCoroutine(DiamondDisableCamera());
            }

        }

    }

    IEnumerator DiamondDisableCamera()
    {
        LevelMusic.enabled = false;
        Time.timeScale = TimeStop;
        DiamondAppearSFX.Play();
        yield return new WaitForSecondsRealtime(DiamondAppearTime);
        DiamondCamera.SetActive(false);
        Time.timeScale = TimeStart;
        LevelMusic.enabled = true;
    }

}
