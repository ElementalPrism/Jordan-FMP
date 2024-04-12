using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasurePickUp : MonoBehaviour
{
    public TreasureManager TreasureM;
    public GameObject ThisObject;
    [SerializeField] AudioSource CollectedSFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(PlaySound());
    }

    IEnumerator PlaySound()
    {
        CollectedSFX.Play();
        yield return new WaitForSeconds(1f);
        TreasureM.TreasureNumber = TreasureM.TreasureNumber - 1;
        ThisObject.SetActive(false);
    }
}
