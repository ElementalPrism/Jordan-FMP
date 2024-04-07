using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    [SerializeField] float AggroDistance;
    [SerializeField] Transform PlayerTransform;
    public Transform StandardTargetTransform;

    public Transform HomingTargetTransform;
    [SerializeField] Transform AttackSpawnLocation;
    [SerializeField] float TimeBetweenShots;

    public GameObject Target;
    public GameObject ReflectableAttack;
    public GameObject StandardAttack;

    public int Health;
    public int CurrentPhase;
    public int ShotCounter;
    public bool CanFire = true;
    public bool Reflected;

    [SerializeField] GameObject ThisObject;
    [SerializeField] GameObject ShotSpawner;

    public Animator BossAnimator;
    public bool IsHurt;
    public bool IsDead;
    public bool IsBlocking;

    bool Waiting = false;
    GameObject ReflectAttack;
    GameObject NormalAttack1;

    public static int ReflectOrbCount;

    public GameObject DiamondDrop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerTransform.position) < AggroDistance)
        {

                if (CanFire == true)
                {
                    BossAnimator.SetBool("IsAttacking", true); 
                }

                if (CanFire == false)
                {
                    BossAnimator.SetBool("IsAttacking", false);
                }
                
     

            BossAnimator.SetBool("IsInBattle", true);
        }
        
        if (Vector3.Distance(transform.position, PlayerTransform.position) > AggroDistance)
        {
            BossAnimator.SetBool("IsInBattle", false);
            BossAnimator.SetBool("IsAttacking", false);
            //CanFire = false;
        }

        if (IsHurt == true)
        {
            BossAnimator.SetBool("IsHurt", true);
        }

        if (IsDead == true)
        {
            BossAnimator.SetBool("IsDead", true);
        }

        if (IsBlocking == true)
        {
            BossAnimator.SetBool("Reflect", true);
        }



        HealthSystem();

        if ((ReflectOrbCount == 0) && (Vector3.Distance(transform.position, PlayerTransform.position) < AggroDistance))
        {
            CanFire = true;
        }


        if (CurrentPhase == 3)
        {
            if (ReflectOrbCount == 0)
            {
                Health = 1;
                Reflected = false;
            }
        }





    }

    void HealthSystem()
    {
        if (Health >= 3)
        {
            CurrentPhase = 1;
        }

        if (Health == 2)
        {
            CurrentPhase = 2;
        }

        if (Health == 1)
        {
            CurrentPhase = 3;
        }

        if (Health == -1)
        {
            BossAnimator.SetBool("IsDead", true);
            DiamondDrop.SetActive(true);
            Destroy(ShotSpawner);
            //Destroy(ThisObject);
        }
    }

    public void StopHurt()
    {
        IsHurt = false;
        BossAnimator.SetBool("IsHurt", false);
        CanFire = true;
    }

    public void StopBlock()
    {
        IsBlocking = false;
        BossAnimator.SetBool("Reflect", false);
    }

    IEnumerator StartWait()
    {
        yield return new WaitForSeconds(TimeBetweenShots);
        Waiting = false;
    }


}
