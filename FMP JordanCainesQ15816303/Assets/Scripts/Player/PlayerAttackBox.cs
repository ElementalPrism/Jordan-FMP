using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBox : MonoBehaviour
{
    [SerializeField] Transform BossTarget;

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
        if (other.gameObject.GetComponent<ReflectableAttack>())
        {
            if(BossTarget != null)
            {
                other.gameObject.GetComponent<ReflectableAttack>().TargetTransform = BossTarget;
                other.gameObject.GetComponent<ReflectableAttack>().CanDamage = true;
            }
            
        }
        else if (other.gameObject.GetComponent<Weed>())
        {
                other.gameObject.GetComponent<Weed>().WeedDestruction();
        }
        else
        {
            if(other.gameObject.layer != LayerCheck)
            {
                other.gameObject.GetComponent<Animator>().SetBool("IsDead", true);
            }

            
        }
        
    }
}
