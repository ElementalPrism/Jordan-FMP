using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{

    public static int CurrentMission;
    int VisibleMission;
    //Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //Stores the number of what the current mission number is
    {
        VisibleMission = CurrentMission;
    }
}
