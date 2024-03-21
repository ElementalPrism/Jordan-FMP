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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerTransform.position) < TalkDistance)
        {
            if(Input.GetKeyDown(KeyCode.F) && (IsTalking == false))
            {
                IsTalking = true;
                TargetPlayer.CanMove = false;
                TextBackground.SetActive(true);
                NPCText.SetActive(true);
                NPCText.GetComponent<Text>().text = "Nice Day Today, Isn't it?";
            }
            else if  ((Input.anyKeyDown) && (IsTalking = true))
            {
                IsTalking = false;
                TargetPlayer.CanMove = true;
                TextBackground.SetActive(false);
                NPCText.SetActive(false);
            }


        }
    }
}
