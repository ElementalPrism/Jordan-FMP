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

    [SerializeField] AudioSource LevelMusic;
    [SerializeField] AudioSource BossMusic;


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
    [SerializeField] float DiamondAppearTime;
    [SerializeField] GameObject DiamondCamera;
    [SerializeField] AudioSource DiamondAppearSFX;
    bool ReactivateMusic;

    int ReflectOrbReset = 0;
    int Phase1 = 1;
    int Phase2 = 2;
    int Phase3 = 3;

    int Phase1Health = 3;
    int Phase2Health = 2;
    int Phase3Health = 1;
    int HealthCatch = -1;

    int TimeStop = 0;
    int TimeStart = 1;

    public bool IsAggro;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAggro)
        {
            if(!IsDead)
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

        }
        
        if (!IsAggro)
        {
            if (!IsDead)
            {
                BossAnimator.SetBool("IsInBattle", false);
                BossAnimator.SetBool("IsAttacking", false);


            }

            //CanFire = false;
        }

        if (IsHurt == true)
        {
            BossAnimator.SetBool("IsHurt", true);
        }

        if (IsDead == true)
        {
            
            //LevelMusic.enabled = false;
            //BossMusic.enabled = false;
            BossAnimator.SetBool("IsDead", true);
        }

        if (IsBlocking == true)
        {
            BossAnimator.SetBool("Reflect", true);
        }



        HealthSystem();

        if ((ReflectOrbCount == ReflectOrbReset) && (IsAggro))
        {
            CanFire = true;
        }


        if (CurrentPhase == Phase3)
        {
            if (ReflectOrbCount == ReflectOrbReset)
            {
                Health = Phase3Health;
                Reflected = false;
            }
        }

        //if ((IsDead) &&(ReactivateMusic))
        //{
        //    LevelMusic.enabled = true;
        //}



    }

    void HealthSystem()
    {
        if (Health >= Phase1Health)
        {
            CurrentPhase = Phase1;
        }

        if (Health == Phase2Health)
        {
            CurrentPhase = Phase2;
        }

        if (Health == Phase3Health)
        {
            CurrentPhase = Phase3;
        }

        if (Health == HealthCatch)
        {
            //BossAnimator.SetBool("IsDead", true);
            DiamondDrop.SetActive(true);
            StartCoroutine(DiamondCameraDisable());
            IsDead = true;
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

    IEnumerator DiamondCameraDisable()
    {
        BossMusic.enabled = false;
        Time.timeScale = TimeStop;
        yield return new WaitForSecondsRealtime(DiamondAppearTime);
        DiamondCamera.SetActive(false);
        Time.timeScale = TimeStart;
        
    }


}
