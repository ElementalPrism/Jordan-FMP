using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBox : MonoBehaviour
{
    [SerializeField] Transform BossTarget;
    [SerializeField] AudioSource ReflectSFX;

    int LayerCheck = 9;


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
        if (other.gameObject.GetComponent<ReflectableAttack>()) //if the attack box collides with a reflectable orb, it will reflect the orb back
        {
            if(BossTarget != null)
            {
                other.gameObject.GetComponent<ReflectableAttack>().TargetTransform = BossTarget;
                if (ReflectSFX != null)
                {
                    ReflectSFX.Play();
                }
                other.gameObject.GetComponent<ReflectableAttack>().CanDamage = true;
            }
            
        }
        else if (other.gameObject.GetComponent<Weed>()) //if the object being hit is a weed, then that weed disappears
        {
                other.gameObject.GetComponent<Weed>().WeedDestruction();
        }
        else
        {
            if(other.gameObject.layer != LayerCheck) //If it collides with any enemy, the enemy will play their death animation and disappear
            {
                other.gameObject.GetComponent<Animator>().SetBool("IsDead", true);
            }

            
        }
        
    }
}
