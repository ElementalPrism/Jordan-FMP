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

    [SerializeField] GameObject InteractIcon;

    [SerializeField] bool IsTorch;
    int TorchDiamondRequirement = 5;
    int TorchDiamondNumber;
    public bool GravityTorchActivated;
    [SerializeField] PowerUpTorch PowerUpTorchObject;

    public int WeedCounter;
    [SerializeField] GameObject Diamond4;

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

                if (Level1Manager.CurrentMission == 1)
                {
                    NPCText.GetComponent<Text>().text = "An evil skeleton has set up camp at the top of the mountain. Maybe your sword can give it a taste of it's own medicine!";
                }
                else if (Level1Manager.CurrentMission == 2)
                {
                    NPCText.GetComponent<Text>().text = "After you defeated that menace, I built a Windmill! I see something shiny up there...";
                }
                else if (Level1Manager.CurrentMission == 3)
                {
                    NPCText.GetComponent<Text>().text = "I've noticed a dying flower in the forest. Maybe some water from the well will help it.";
                }
                else if (Level1Manager.CurrentMission == 4)
                {
                    if (WeedCounter > 0)
                    {
                        NPCText.GetComponent<Text>().text = "This place has been overrun with weeds! You have " + WeedCounter + "to kill";
                    }
                    else if (WeedCounter == 0)
                    {
                        NPCText.GetComponent<Text>().text = "You killed all the weeds! Take this shiny thing I found as a thank you present.";
                    }

                }
                else if (Level1Manager.CurrentMission == 5)
                {
                    NPCText.GetComponent<Text>().text = "That flower became a giant sunflower! I think I see something shiny on it's petals.";
                }
                else if (Level1Manager.CurrentMission == 6)
                {
                    NPCText.GetComponent<Text>().text = "I heard some sounds coming from inside the well but I am too scared to investigate.";
                }
                else if (Level1Manager.CurrentMission == 7)
                {
                    NPCText.GetComponent<Text>().text = "There is a legend about some treasure being left at the bottom of this well. I don't know if this is true as I am scared to enter the well.";
                }
                else if (Level1Manager.CurrentMission == 8)
                {
                    NPCText.GetComponent<Text>().text = "I noticed a torch during my trek up another mountain. Maybe that torch is linked to the mysteries of the well!";
                }














                if (IsTorch)
                {
                    if ((TorchDiamondNumber <= 0) && (!GravityTorchActivated))
                    {
                        PowerUpTorchObject.IsActivated = true;
                        GravityTorchActivated = true;
                        NPCText.GetComponent<Text>().text = NPCSpeech1;
                    }
                    else if (GravityTorchActivated) 
                    {
                        NPCText.GetComponent<Text>().text = NPCSpeech1;
                    }
                    else if (TorchDiamondNumber > 0)
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



        if (IsTorch)
        {
            TorchDiamondNumber = TorchDiamondRequirement - DiamondManager.DiamondAmount;
        }

        if (WeedCounter <= 0)
        {
            Diamond4.SetActive(true);
        }

    }
}
