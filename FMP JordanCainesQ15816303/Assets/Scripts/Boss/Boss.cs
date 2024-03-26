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

           // if (CurrentPhase == 1)
           // {
                if (CanFire == true)
                {
                    BossAnimator.SetBool("IsAttacking", true); 
                }

                if (CanFire == false)
                {
                    BossAnimator.SetBool("IsAttacking", false);
                }
                
            //}

            //if (CurrentPhase == 2)
            ////{
            //    if (CanFire == true) 
            //    { 
            //        //if((Waiting == false) && (ShotCounter < 3))
            //        //{
            //        //    NormalAttack1 = Instantiate(StandardAttack, AttackSpawnLocation);
            //        //    NormalAttack1.GetComponent<OrbAttack>().PlayerTarget = StandardTargetTransform;
            //        //    ShotCounter = ShotCounter + 1;
            //        //    Waiting = true;
            //        //    StartCoroutine(StartWait());
            //        //}



            //        if (ShotCounter == 3)
            //        {
            //            Waiting = true;
            //            StartCoroutine(StartWait());
            //            ReflectAttack = Instantiate(ReflectableAttack, AttackSpawnLocation);
            //            ReflectAttack.GetComponent<ReflectableAttack>().TargetTransform = HomingTargetTransform;
            //            ShotCounter = 0;
            //            CanFire = false;
            //        }
            //    }

            //}

            //if (CurrentPhase == 3)
            //{
            //    if (CanFire == true)
            //    {
            //        if ((Waiting == false) && (ShotCounter < 3))
            //        {
            //            NormalAttack1 = Instantiate(StandardAttack, AttackSpawnLocation);
            //            NormalAttack1.GetComponent<OrbAttack>().PlayerTarget = StandardTargetTransform;
            //            ShotCounter = ShotCounter + 1;
            //            Waiting = true;
            //            StartCoroutine(StartWait());
            //        }



            //        if (ShotCounter == 3)
            //        {
            //            Waiting = true;
            //            StartCoroutine(StartWait());
            //            ReflectAttack = Instantiate(ReflectableAttack, AttackSpawnLocation);
            //            ReflectAttack.GetComponent<ReflectableAttack>().TargetTransform = HomingTargetTransform;
            //            ShotCounter = 0;
            //            CanFire = false;
            //        }

            //    }
            //}

            BossAnimator.SetBool("IsInBattle", true);
        }
        
        if (Vector3.Distance(transform.position, PlayerTransform.position) > AggroDistance)
        {
            BossAnimator.SetBool("IsInBattle", false);
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
