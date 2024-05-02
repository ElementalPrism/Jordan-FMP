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
        if (Vector3.Distance(transform.position, BossTransform.position) > Distance) //If the reflect orb travels too far away from the boss, the orb will delete itself and allow the boss the shoot another reflect orb
        {
            Boss.ReflectOrbCount = OrbReset;
            Destroy(ThisObject);
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement() //reflect orb movement towards target
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetTransform.position, (Speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other) //If the reflect orb collides with the player, they take damage, reflect orb is destroyed and boss can fire another reflect orb
    {

        if (other.gameObject.GetComponent<Player>())
        {
            other.gameObject.GetComponent<Player>().Health = other.gameObject.GetComponent<Player>().Health - Damage;
            other.gameObject.GetComponent<Player>().IsHurt = true;
            Boss.ReflectOrbCount = OrbReset;
            CanDamage = false;
            Destroy(ThisObject);

        }




        if (other.gameObject.layer == LayerCheck) //This checks to see if the object it has collided with's layer is the same as the boss' layer
        {
            if (CanDamage == true)

            {
                if (other.gameObject.GetComponent<Boss>().CurrentPhase == PhaseCheck) //Checks to see which boss phase it is 
                {
                   if(other.gameObject.GetComponent<Boss>().Reflected == false) //This only occurs on the final phase where the boss will reflect the player's reflected attack back
                   {
                       TargetTransform = other.gameObject.GetComponent<Boss>().HomingTargetTransform;
                       other.gameObject.GetComponent<Boss>().IsBlocking = true;
                       other.gameObject.GetComponent<Boss>().Reflected = true;
                       CanDamage = false; 
                   }

                   if (other.gameObject.GetComponent<Boss>().Reflected == true)
                   {
                       other.gameObject.GetComponent<Boss>().Health = other.gameObject.GetComponent<Boss>().Health - Damage;
                       CanDamage = false;
                    }
                }
            
                if(other.gameObject.GetComponent<Boss>().CurrentPhase < PhaseCheck) //Deals damage to boss and deletes reflect orb
                {
                    other.gameObject.GetComponent<Boss>().Health = other.gameObject.GetComponent<Boss>().Health - Damage;
                    other.gameObject.GetComponent<Boss>().IsHurt = true;
                    other.gameObject.GetComponent<Boss>().CurrentPhase = other.gameObject.GetComponent<Boss>().CurrentPhase + PhaseIncrease;            
                    CanDamage = false;
                    Destroy(ThisObject);
                }

                if (other.gameObject.GetComponent<Boss>().Health == DeathHealth) //Gets rid of any reflect orbs when the boss dies
                {
                    CanDamage = false;
                    Destroy(ThisObject);
                }
            }

            

           
        }
    }

}
