using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureManager : MonoBehaviour
{
    public int TreasureNumber;
    public GameObject Diamond7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TreasureNumber <= 0)
        {
            Diamond7.SetActive(true);
        }
    }
}
