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
        if (IsAggro)  //This checks if the player is within range of the boss
        {
            if(!IsDead) //This checks if the boss is still alive
            {
                //These two if statements are used to activate the boss attack animation
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
        
        if (!IsAggro) // This segment makes the boss return to its' normal idle animation if the player is not currently fighting it
        {
            if (!IsDead)
            {
                BossAnimator.SetBool("IsInBattle", false);
                BossAnimator.SetBool("IsAttacking", false);


            }

        }

        //These 3 if statements are animation triggers
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

        //These control when the boss can fire a green reflectable attack

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

    }

    void HealthSystem() //Used to monitor the boss phases and as well as spawn the diamond upon defeat
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

            DiamondDrop.SetActive(true);
            StartCoroutine(DiamondCameraDisable());
            IsDead = true;
            Destroy(ShotSpawner);
        }
    }

    public void StopHurt() //Stops the Hurt effect and allows the boss to fire again(is called within the hurt animation to stop hurting)
    {
        IsHurt = false;
        BossAnimator.SetBool("IsHurt", false);
        CanFire = true;
    }

    public void StopBlock() //Stops the block effect (is called within the block animation to stop blocking)
    {
        IsBlocking = false;
        BossAnimator.SetBool("Reflect", false);
    }

    IEnumerator StartWait() //Waiting time between fired shots
    {
        yield return new WaitForSeconds(TimeBetweenShots);
        Waiting = false;
    }

    IEnumerator DiamondCameraDisable() //Stops the music and spawns the camera to look at the diamond
    {
        BossMusic.enabled = false;
        Time.timeScale = TimeStop;
        yield return new WaitForSecondsRealtime(DiamondAppearTime);
        DiamondCamera.SetActive(false);
        Time.timeScale = TimeStart;
        
    }


}
