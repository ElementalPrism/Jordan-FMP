using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    public float SpinSpeed;

    float ValueNull = 0;
    int MissionScreen = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //Level portal constantly rotates
    {
        transform.Rotate(ValueNull, SpinSpeed * Time.deltaTime, ValueNull);
    }

    private void OnTriggerEnter(Collider other) //Loads the mission select screen scene
    {
        SceneManager.LoadScene(MissionScreen);
    }
}
