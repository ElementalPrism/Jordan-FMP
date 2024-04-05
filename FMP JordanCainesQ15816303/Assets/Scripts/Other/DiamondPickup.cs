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
    [SerializeField] Material Faded;
    public TreasureManager TreasureM;




    // Start is called before the first frame update
    void Start()
    {
        if (Diamond1)
        {
            if (MissionSelector.Collected1 == true)
            {
                ThisGameObject.GetComponent<MeshRenderer>().material = Faded;
            }
        }
        else if (Diamond2)
        {
            if (Diamond2)
            {
                if (MissionSelector.Collected2 == true)
                {
                    ThisGameObject.GetComponent<MeshRenderer>().material = Faded;
                }
            }
        }
        else if (Diamond3)
        {
            if (Diamond3)
            {
                if (MissionSelector.Collected3 == true)
                {
                    ThisGameObject.GetComponent<MeshRenderer>().material = Faded;
                }
            }
        }
        else if (Diamond4)
        {
            if (Diamond4)
            {
                if (MissionSelector.Collected4 == true)
                {
                    ThisGameObject.GetComponent<MeshRenderer>().material = Faded;
                }
            }
        }
        else if (Diamond5)
        {
            if (Diamond5)
            {
                if (MissionSelector.Collected5 == true)
                {
                    ThisGameObject.GetComponent<MeshRenderer>().material = Faded;
                }
            }
        }
        else if (Diamond6)
        {
            if (Diamond6)
            {
                if (MissionSelector.Collected6 == true)
                {
                    ThisGameObject.GetComponent<MeshRenderer>().material = Faded;
                }
            }
        }
        else if (Diamond7)
        {
            if (Diamond7)
            {
                if (MissionSelector.Collected7 == true)
                {
                    ThisGameObject.GetComponent<MeshRenderer>().material = Faded;
                }
            }
        }
        else if (Diamond8)
        {
            if (Diamond8)
            {
                if (MissionSelector.Collected8 == true)
                {
                    ThisGameObject.GetComponent<MeshRenderer>().material = Faded;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, SpinSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Diamond1)
        {
            if (MissionSelector.Collected1 == false)
            {
                Collected1 = true;
                DiamondManager.DiamondAmount = DiamondManager.DiamondAmount + 1;
                MissionSelector.Collected1 = true;
            }

        }
        else if (Diamond2)
        {
            if (MissionSelector.Collected2 == false)
            {
                Collected2 = true;
                DiamondManager.DiamondAmount = DiamondManager.DiamondAmount + 1;
                MissionSelector.Collected2 = true;
            }

        }
        else if (Diamond3)
        {
            if (MissionSelector.Collected3 == false)
            {
                Collected3 = true;
                DiamondManager.DiamondAmount = DiamondManager.DiamondAmount + 1;
                MissionSelector.Collected3 = true;
            }

        }
        else if (Diamond4)
        {
            if (MissionSelector.Collected4 == false)
            {
                Collected4 = true;
                DiamondManager.DiamondAmount = DiamondManager.DiamondAmount + 1;
                MissionSelector.Collected4 = true;
            }

        }
        else if (Diamond5)
        {
            if (MissionSelector.Collected5 == false)
            {
                Collected5 = true;
                DiamondManager.DiamondAmount = DiamondManager.DiamondAmount + 1;
                MissionSelector.Collected5 = true;
            }
        }
        else if (Diamond6)
        {
            if (MissionSelector.Collected6 == false)
            {
                Collected6 = true;
                DiamondManager.DiamondAmount = DiamondManager.DiamondAmount + 1;
                MissionSelector.Collected6 = true;
                if (TreasureM)
                {
                    TreasureM.TreasureNumber = 6;
                }
            }
        }
        else if (Diamond7)
        {
            if (MissionSelector.Collected7 == false)
            {
                Collected7 = true;
                DiamondManager.DiamondAmount = DiamondManager.DiamondAmount + 1;
                MissionSelector.Collected7 = true;
                if (TreasureM)
                {
                    TreasureM.TreasureNumber = 6;
                }
            }
        }
        else if (Diamond8)
        {
            if (MissionSelector.Collected5 == false)
            {
                Collected8 = true;
                DiamondManager.DiamondAmount = DiamondManager.DiamondAmount + 1;
                MissionSelector.Collected8= true;
                if (TreasureM)
                {
                    TreasureM.TreasureNumber = 6;
                }
            }
        }

        CoinCounter.CoinAmount = 0;
        SceneManager.LoadScene(1);

    }

}
