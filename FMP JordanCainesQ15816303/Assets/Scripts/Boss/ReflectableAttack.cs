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
    public Transform BossTransform;
    float Distance = 12;
    //[SerializeField] Transform PractiseTarget;

    int OrbReset = 0;
    int Damage = 1;
    int PhaseCheck = 3;
    int LayerCheck = 9;
    int DeathHealth = -1;
    int PhaseIncrease = 1;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, BossTransform.position) > Distance)
        {
            Boss.ReflectOrbCount = OrbReset;
            Destroy(ThisObject);
        }
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
            other.gameObject.GetComponent<Player>().Health = other.gameObject.GetComponent<Player>().Health - Damage;
            other.gameObject.GetComponent<Player>().IsHurt = true;
            Boss.ReflectOrbCount = OrbReset;
            CanDamage = false;
            Destroy(ThisObject);

        }




        if (other.gameObject.layer == LayerCheck)
        {
            if (CanDamage == true)

            {
                if (other.gameObject.GetComponent<Boss>().CurrentPhase == PhaseCheck)
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
                       other.gameObject.GetComponent<Boss>().Health = other.gameObject.GetComponent<Boss>().Health - Damage;
                       //other.gameObject.GetComponent<Boss>().IsHurt = true;
                       CanDamage = false;
                       //Destroy(ThisObject);
                    }
                }
            
                if(other.gameObject.GetComponent<Boss>().CurrentPhase < PhaseCheck)
                {
                    other.gameObject.GetComponent<Boss>().Health = other.gameObject.GetComponent<Boss>().Health - Damage;
                    other.gameObject.GetComponent<Boss>().IsHurt = true;
                    other.gameObject.GetComponent<Boss>().CurrentPhase = other.gameObject.GetComponent<Boss>().CurrentPhase + PhaseIncrease;            
                    //other.gameObject.GetComponent<Boss>().CanFire = true;
                    CanDamage = false;
                    Destroy(ThisObject);
                }

                if (other.gameObject.GetComponent<Boss>().Health == DeathHealth)
                {
                    CanDamage = false;
                    Destroy(ThisObject);
                }
            }

            

           
        }
    }

}
