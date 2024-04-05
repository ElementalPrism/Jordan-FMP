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
    public string NPCSpeech3;
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
