using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReflectableAttack : MonoBehaviour
{

    [SerializeField] float Speed;
    public Transform TargetTransform;
    public GameObject ThisObject;
    public bool CanDamage;
    //[SerializeField] Transform PractiseTarget;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetTransform.position, (Speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<Player>())
        {
            other.gameObject.GetComponent<Player>().Health = other.gameObject.GetComponent<Player>().Health - 1;
            other.gameObject.GetComponent<Player>().IsHurt = true;
        }




        if (other.gameObject.layer == 9)
        {
            if (CanDamage == true)

            {
                if (other.gameObject.GetComponent<Boss>().CurrentPhase == 3)
                {
                   if(other.gameObject.GetComponent<Boss>().Reflected == false)
                   {
                       TargetTransform = other.gameObject.GetComponent<Boss>().HomingTargetTransform;
                       other.gameObject.GetComponent<Boss>().IsBlocking = true;
                       other.gameObject.GetComponent<Boss>().Reflected = true;
                       CanDamage = false; 
                   }

                   if (other.gameObject.GetComponent<Boss>().Reflected == true)
                   {
                       other.gameObject.GetComponent<Boss>().Health = other.gameObject.GetComponent<Boss>().Health - 1;
                       //other.gameObject.GetComponent<Boss>().IsHurt = true;
                       CanDamage = false;
                       //Destroy(ThisObject);
                    }
                }
            
                if(other.gameObject.GetComponent<Boss>().CurrentPhase < 3)
                {
                    other.gameObject.GetComponent<Boss>().Health = other.gameObject.GetComponent<Boss>().Health - 1;
                    other.gameObject.GetComponent<Boss>().IsHurt = true;
                    other.gameObject.GetComponent<Boss>().CurrentPhase = other.gameObject.GetComponent<Boss>().CurrentPhase + 1;            
                    other.gameObject.GetComponent<Boss>().CanFire = true;
                    CanDamage = false;
                    Destroy(ThisObject);
                }

                if (other.gameObject.GetComponent<Boss>().Health == -1)
                {
                    CanDamage = false;
                    Destroy(ThisObject);
                }
            }

            

           
        }
    }

}
