using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTrigger : MonoBehaviour
{
    public GameObject ThisPowerUp;
    public bool Unlocked;

    [SerializeField] Material UnlockedMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PowerUpManager.GravityPotionUnlocked == true) //Checks to see if the player has unlocked the power up
        {
            Unlocked = true;
        }





        if (Unlocked == true) //potion changes material into a more vibrant material to show it being unlocked
        {
            ThisPowerUp.GetComponent<MeshRenderer>().material = UnlockedMaterial;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            if (Unlocked == true) //If the player collides with the power up, the player will then be able to use the power up
            {
                 other.gameObject.GetComponent<Player>().PowerUp = true;
                 ThisPowerUp.SetActive(false);
                 //Destroy(ThisPowerUp);
            }

        }
    }

}
