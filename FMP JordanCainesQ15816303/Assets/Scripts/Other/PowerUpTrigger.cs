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
        if (PowerUpManager.GravityPotionUnlocked == true)
        {
            Unlocked = true;
        }





        if (Unlocked == true)
        {
            ThisPowerUp.GetComponent<MeshRenderer>().material = UnlockedMaterial;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            if (Unlocked == true)
            {
                 other.gameObject.GetComponent<Player>().PowerUp = true;
                 ThisPowerUp.SetActive(false);
                 //Destroy(ThisPowerUp);
            }

        }
    }

}
