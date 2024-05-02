using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiamondPickup : MonoBehaviour
{
    public float SpinSpeed;
    [SerializeField] bool Diamond1;
    [SerializeField] bool Diamond2;
    [SerializeField] bool Diamond3;
    [SerializeField] bool Diamond4;
    [SerializeField] bool Diamond5;
    [SerializeField] bool Diamond6;
    [SerializeField] bool Diamond7;
    [SerializeField] bool Diamond8;

    public bool Collected1;
    public bool Collected2;
    public bool Collected3;
    public bool Collected4;
    public bool Collected5;
    public bool Collected6;
    public bool Collected7;
    public bool Collected8;

    [SerializeField] GameObject ThisGameObject;
    [SerializeField] MeshRenderer ThisMeshRenderer;
    [SerializeField] Material Faded;
    public TreasureManager TreasureM;
    [SerializeField] Player PlayerObject;

    int TreasureAmount = 6;
    int DiamondIncrease = 1;
    float ValueNull = 0;
    int CoinReset = 0;


    // Start is called before the first frame update
    void Start() //Checks to see if any of the diamonds have been collected and changes their material if they have
    { 
        if (Diamond1)
        {
            if (MissionSelector.Collected1 == true)
            {
                ThisMeshRenderer.material = Faded;
            }
        }
        else if (Diamond2)
        {
            if (Diamond2)
            {
                if (MissionSelector.Collected2 == true)
                {
                    ThisMeshRenderer.material = Faded;
                }
            }
        }
        else if (Diamond3)
        {
            if (Diamond3)
            {
                if (MissionSelector.Collected3 == true)
                {
                    ThisMeshRenderer.material = Faded;
                }
            }
        }
        else if (Diamond4)
        {
            if (Diamond4)
            {
                if (MissionSelector.Collected4 == true)
                {
                    ThisMeshRenderer.material = Faded;
                }
            }
        }
        else if (Diamond5)
        {
            if (Diamond5)
            {
                if (MissionSelector.Collected5 == true)
                {
                    ThisMeshRenderer.material = Faded;
                }
            }
        }
        else if (Diamond6)
        {
            if (Diamond6)
            {
                if (MissionSelector.Collected6 == true)
                {
                    ThisMeshRenderer.material = Faded;
                }
            }
        }
        else if (Diamond7)
        {
            if (Diamond7)
            {
                if (MissionSelector.Collected7 == true)
                {
                    ThisMeshRenderer.material = Faded;
                }
            }
        }
        else if (Diamond8)
        {
            if (Diamond8)
            {
                if (MissionSelector.Collected8 == true)
                {
                    ThisMeshRenderer.material = Faded;
                }
            }
        }
    }

    // Update is called once per frame
    void Update() //Constantly rotates the diamond
    {
        transform.Rotate(ValueNull, SpinSpeed * Time.unscaledDeltaTime, ValueNull);
    }

    private void OnTriggerEnter(Collider other) //Checks to see if the player hasnt collected the diamond already, then adds 1 to the diamond counter
    {
        if (Diamond1)
        {
            if (MissionSelector.Collected1 == false)
            {
                Collected1 = true;
                DiamondManager.DiamondAmount = DiamondManager.DiamondAmount + DiamondIncrease;
                MissionSelector.Collected1 = true;
            }

        }
        else if (Diamond2)
        {
            if (MissionSelector.Collected2 == false)
            {
                Collected2 = true;
                DiamondManager.DiamondAmount = DiamondManager.DiamondAmount + DiamondIncrease;
                MissionSelector.Collected2 = true;
            }

        }
        else if (Diamond3)
        {
            if (MissionSelector.Collected3 == false)
            {
                Collected3 = true;
                DiamondManager.DiamondAmount = DiamondManager.DiamondAmount + DiamondIncrease;
                MissionSelector.Collected3 = true;
            }

        }
        else if (Diamond4)
        {
            if (MissionSelector.Collected4 == false)
            {
                Collected4 = true;
                DiamondManager.DiamondAmount = DiamondManager.DiamondAmount + DiamondIncrease;
                MissionSelector.Collected4 = true;
            }

        }
        else if (Diamond5)
        {
            if (MissionSelector.Collected5 == false)
            {
                Collected5 = true;
                DiamondManager.DiamondAmount = DiamondManager.DiamondAmount + DiamondIncrease;
                MissionSelector.Collected5 = true;
            }
        }
        else if (Diamond6)
        {
            if (MissionSelector.Collected6 == false)
            {
                Collected6 = true;
                DiamondManager.DiamondAmount = DiamondManager.DiamondAmount + DiamondIncrease;
                MissionSelector.Collected6 = true;
                if (TreasureM) //Resets treasure amount
                {
                    TreasureM.TreasureNumber = TreasureAmount;
                }
            }
        }
        else if (Diamond7)
        {
            if (MissionSelector.Collected7 == false)
            {
                Collected7 = true;
                DiamondManager.DiamondAmount = DiamondManager.DiamondAmount + DiamondIncrease;
                MissionSelector.Collected7 = true;
                if (TreasureM) //Resets treasure amount
                {
                    TreasureM.TreasureNumber = TreasureAmount;
                }
            }
        }
        else if (Diamond8)
        {
            if (MissionSelector.Collected8 == false)
            {
                Collected8 = true;
                DiamondManager.DiamondAmount = DiamondManager.DiamondAmount + DiamondIncrease;
                MissionSelector.Collected8 = true;
                if (TreasureM) //Resets treasure amount
                {
                    TreasureM.TreasureNumber = TreasureAmount;
                }
            }
        }

        //Resets coin counter and causes the player character to victory dance
        CoinCounter.CoinAmount = CoinReset;
        CoinCounter.CollectedAmount = CoinReset;
        PlayerObject.VictoryTime = true;


    }

}
