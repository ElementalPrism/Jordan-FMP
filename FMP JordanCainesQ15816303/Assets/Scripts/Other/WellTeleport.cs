using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WellTeleport : MonoBehaviour
{

    int WellArea = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) //Loads the well area upon entering the trigger
    {
        SceneManager.LoadScene(WellArea);
    }
}
