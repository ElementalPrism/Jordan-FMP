using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBox : MonoBehaviour
{
    [SerializeField] Transform BossTarget;
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
        else
        {
            if(other.gameObject.layer != 9)
            {
                other.gameObject.GetComponent<Animator>().SetBool("IsDead", true);
            }
            
        }
        
    }
}
