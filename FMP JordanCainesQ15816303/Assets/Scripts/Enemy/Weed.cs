using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weed : MonoBehaviour
{
    [SerializeField] NPCSystem NPCChecker;
    public GameObject ThisObject;
    //public JumpKillable JumpDetect;

    int WeedDeduction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (JumpDetect.TakenHit)
        //{
        //    NPCChecker.WeedCounter = NPCChecker.WeedCounter - 1;
        //    Destroy(ThisObject);
        //}
    }

    public void WeedDestruction()
    {
        NPCChecker.WeedCounter = NPCChecker.WeedCounter - WeedDeduction;
        Destroy(ThisObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
