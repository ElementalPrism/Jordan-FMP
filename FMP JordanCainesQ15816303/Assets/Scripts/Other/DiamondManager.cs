using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondManager : MonoBehaviour
{
    public GameObject DiamondInfo;
    public static int DiamondAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //Updates Diamond UI text
    {
        DiamondInfo.GetComponent<Text>().text = "x " + DiamondAmount;
    }
}
