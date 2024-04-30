using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasurePickUp : MonoBehaviour
{
    public TreasureManager TreasureM;
    public GameObject ThisObject;
    [SerializeField] AudioSource CollectedSFX;
    bool IsCollected;

    float Wait1 = 1f;
    int TreasureDeduction = 1;

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
        if (!IsCollected)
        {
            CollectedSFX.Play();
            IsCollected = true;
        }
        
        yield return new WaitForSeconds(Wait1);
        TreasureM.TreasureNumber = TreasureM.TreasureNumber - TreasureDeduction;
        ThisObject.SetActive(false);
    }
}
