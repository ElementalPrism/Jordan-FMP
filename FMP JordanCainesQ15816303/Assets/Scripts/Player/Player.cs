using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Player : MonoBehaviour
{
    [SerializeField] float MovementSpeed;
    [SerializeField] float JumpForce;
    [SerializeField] float RaySize;
    [SerializeField] float RaySizeRed;
    [SerializeField] LayerMask Layer;
    [SerializeField] GameObject PlayerAttackBox;
    [SerializeField] CameraPositioning Camera;
    [SerializeField] CinemachineFreeLook CameraFree;
    [SerializeField] GameObject PowerUpObject;
    [SerializeField] GameObject PowerUpSparkles;
    [SerializeField] GameObject WellDeathPlane;


    CameraState cameraState;
    Transform PlayerOrient;
    float Horizon;
    float Vert;
    Vector3 PlayerMovement;
    Transform PlayerTransformSave;
    bool IsGrounded;
    bool IsAttacking;
    public bool IsHurt;
    public int Health;
    public bool IsDead;
    float PlayerY;

    public bool PowerUp;
    bool GravityFlipped;
    bool DoubleJumped;
    bool FlippedOnce;
    bool Flipped;
    public bool CanMove;

    public GameObject ThisPlayer;
    public GameObject ThisKnight;
    public Animator PlayerAnimator;

    public float PowerUpTime;

    //bool MusicTriggered;
    public bool VictoryTime;
    
    public Rigidbody PlayerRigid;
    RaycastHit DownwardRaycast;

    [SerializeField] AudioSource LevelMusic;
    [SerializeField] AudioSource PowerUpMusic;

    [SerializeField] CinemachineBrain MachineBrain;

    int FlipValue = 180;
    float FValueNull = 0f;
    int ValueNull = 0;
    float MGravityValue = -5f;
    float GravityValue = 5f;
    int TimeStop = 0;
    int TimeStart = 1;
    int LivesDeduction = 1;
    int NoLives = 0;
    int Lobby = 1;
    int DefaultJumpForce = 14;
    int FlippedJumpForce = 7;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        UnityEngine.Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * RaySize, Color.blue);
        if (Physics.Raycast(transform.position, Vector3.down, RaySize, Layer))
        {
            IsGrounded = true;
            PlayerAnimator.SetBool("IsGrounded", true);
            FlippedOnce = false;

        }
        else
        {
            IsGrounded = false;
            PlayerAnimator.SetBool("IsGrounded", false);
        }

        Debug.DrawRay(transform.position, Vector3.up * RaySizeRed, Color.red);
        if (Physics.Raycast(transform.position, Vector3.up, RaySizeRed, Layer))
        {
            if (PowerUp == true)
            {
                 IsGrounded = true;
                 PlayerAnimator.SetBool("IsGrounded", true);
                 FlippedOnce = false;
            }

        }





        if (IsGrounded)
        {
            ThisPlayer.GetComponent<ConstantForce>().force = new Vector3(FValueNull, FValueNull, FValueNull);
        }



        if ((Input.GetKeyDown(KeyCode.Space)) && (IsHurt == false) && (CanMove == true)) 
        {
            if (Pause.IsPaused == false)
            {
                if (!VictoryTime)
                {
                    if (IsGrounded) 
                    { 
                        Jump();
                    }
                    else if (!IsGrounded)
                    {

                        if ((PowerUp == true))
                        {
                            if (GravityFlipped == false)
                            {
                                if(FlippedOnce == false)
                                {
                                    ThisPlayer.GetComponent<Rigidbody>().useGravity = false;
                                    //ThisPlayer.GetComponent<ConstantForce>().force = new Vector3(0f, 5f, 0f);
                                    Flipped = true;
                                    FlippedOnce = true;
                                    CameraFree.m_Lens.Dutch = FlipValue;
                                    CameraFree.m_XAxis.m_InvertInput = true;
                                    GravityFlipped = true;
                                }

                            }
                            else if (GravityFlipped == true)
                            {
                                if (FlippedOnce == false) 
                                {
                                    ThisPlayer.GetComponent<Rigidbody>().useGravity = true;
                                    ThisPlayer.GetComponent<ConstantForce>().force = new Vector3(FValueNull, MGravityValue, FValueNull);
                                    Flipped = false;
                                    FlippedOnce = true;
                                    ThisPlayer.transform.Rotate(ValueNull, ValueNull, FlipValue);
                                    CameraFree.m_Lens.Dutch = ValueNull;
                                    CameraFree.m_XAxis.m_InvertInput = false;
                                    GravityFlipped = false;

                                }
                            }

                        }
                    }
                }
                
            }
            

        }

        if ((Input.GetKeyDown(KeyCode.Mouse0)) && (IsHurt == false) && (CanMove == true))
        {
            if (Pause.IsPaused == false)
            {
              if (IsGrounded) 
              {
                if(!VictoryTime)
                {
                   Attack();
                }
               
              }
            }

        }


        if (Flipped == true)
        {
            var PlayerRotation = ThisPlayer.transform.eulerAngles;
            ThisPlayer.GetComponent<ConstantForce>().force = new Vector3(FValueNull, GravityValue, FValueNull);
            ThisPlayer.transform.rotation = Quaternion.Euler(PlayerRotation.x, PlayerRotation.y, FlipValue);
            
        }



        //if (Input.GetKeyDown(KeyCode.Mouse1))
        //{
        //    ThisPlayer.GetComponent<Rigidbody>().useGravity = false;
        //    ThisPlayer.GetComponent<ConstantForce>().force = new Vector3(0f, 5f, 0f);

        //}


        PlayerY = PlayerRigid.velocity.y;
        PlayerAnimator.SetFloat("AirSpeed", PlayerY);


        if (IsHurt == true)
        {
            PlayerAnimator.SetBool("IsHurt", true);

            if(IsAttacking)
            {
                StopAttack();
            }
        }

        if (IsDead == true)
        {
            PlayerAnimator.SetBool("IsDead", true);
        }

        if (PowerUp)
        {
            
           // Debug.Log("Power Up Active");
            if (CanMove == true)
            {
                PowerUpSparkles.SetActive(true);
               // Debug.Log("Can Move");
               // Debug.Log("Disable Level Music");
                   LevelMusic.enabled = false;
                //Debug.Log("Enable Power Up Music");
                PowerUpMusic.enabled = true;

                //Debug.Log("Start Coroutine");
                StartCoroutine(PowerUpTimer());
            }
            //DO NOT REMOVE THE DEBUG LOGS. IDK why this stops the player from dying when switching music but it fixes the issue.
        }

        if(CanMove == false)
        {
            PlayerAnimator.SetFloat("MovementSpeed", ValueNull);
        }

        PlayerTransformSave = ThisPlayer.transform;




        if (VictoryTime)
        {
            PlayerAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
            PlayerAnimator.SetBool("Victory", true);
            Time.timeScale = TimeStop;
        }



        if (!Flipped)
        {
            MachineBrain.m_UpdateMethod = CinemachineBrain.UpdateMethod.FixedUpdate;
            MachineBrain.m_BlendUpdateMethod = CinemachineBrain.BrainUpdateMethod.FixedUpdate;
        }

        if (Flipped)
        {
            MachineBrain.m_UpdateMethod = CinemachineBrain.UpdateMethod.SmartUpdate;
            MachineBrain.m_BlendUpdateMethod = CinemachineBrain.BrainUpdateMethod.LateUpdate;
        }


    }

    private void FixedUpdate()
    {
        //PlayerRigid.velocity = PlayerRigid.transform.TransformVector(PlayerRigid.velocity);
        if (!VictoryTime)
        {
            Movement();
        }

    }

    void Attack()
    {
        if (!IsAttacking)
        {
            IsAttacking = true;
            PlayerAnimator.SetBool("Attack", true);
            PlayerAttackBox.SetActive(true);

        }
    }

    public void StopVictory()
    {
        Time.timeScale = TimeStart;
        PlayerAnimator.SetBool("Victory", false);
        VictoryTime = false;
        Pause.IsPaused = false;
        PlayerAnimator.updateMode = AnimatorUpdateMode.Normal;
        SceneManager.LoadScene(1);
    }

    public void StopAttack()
    {
        PlayerAnimator.SetBool("Attack", false);
        PlayerAttackBox.SetActive(false);
        IsAttacking= false;
    }

    public void StopHurt()
    {
        PlayerAnimator.SetBool("IsHurt", false);
        IsHurt = false;
    }

    public void RemoveLife()
    {
        LivesManager.LivesAmount = LivesManager.LivesAmount - LivesDeduction;

        if (LivesManager.LivesAmount > NoLives)
        {
            SceneManager.LoadScene(Lobby);
        }
    }


    void Jump()
    {
        if (GravityFlipped == false)
        {
           PlayerRigid.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
        else if (GravityFlipped == true)
        {
           PlayerRigid.AddForce(Vector3.down * JumpForce, ForceMode.Impulse);
        }
        //PlayerRigid.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);



    }

    IEnumerator PowerUpTimer()
    {
        //Debug.Log("Timer Active");
        yield return new WaitForSeconds(PowerUpTime);
        //Debug.Log("Timer Ran Out");
        PowerUp = false;
        PowerUpSparkles.SetActive(false);
        ThisPlayer.GetComponent<Rigidbody>().useGravity = true;

        ThisPlayer.GetComponent<ConstantForce>().force = new Vector3(FValueNull, FValueNull, FValueNull);

        if (Flipped == true)
        {
            ThisPlayer.transform.Rotate(ValueNull, ValueNull, FlipValue);
            Flipped = false;
        }


        //Debug.Log("Disable Power Up Music");
        PowerUpMusic.enabled = false;
        //Debug.Log("Enable Level Music");
        LevelMusic.enabled = true;

        CameraFree.m_Lens.Dutch = ValueNull;
        CameraFree.m_XAxis.m_InvertInput = false;
        GravityFlipped = false;
        PowerUpObject.SetActive(true);

    }

    void Movement()
    {
        if ((!IsAttacking) && (IsHurt == false) && (CanMove == true))
        {
            if (Flipped == false)
            {
                Horizon = Input.GetAxis("Horizontal");
                JumpForce = DefaultJumpForce;

            }
            else if (Flipped == true)
            {
                Horizon = -Input.GetAxis("Horizontal");
                JumpForce = FlippedJumpForce;
            }

            Vert = Input.GetAxis("Vertical");

            //PlayerMovement = new Vector3(Horizon, 0, Vert);
            //PlayerMovement.Normalize();

            PlayerOrient = Camera.PlayerOrientation;
            PlayerMovement = (PlayerOrient.forward * Vert) + (PlayerOrient.right * Horizon);
            PlayerMovement.Normalize();
            PlayerAnimator.SetFloat("MovementSpeed", Mathf.Clamp01(PlayerMovement.magnitude));
            //transform.position = transform.position + (PlayerMovement * (Mathf.Clamp01(PlayerMovement.magnitude) * (Time.deltaTime * MovementSpeed)));
            PlayerRigid.velocity = ((PlayerMovement * (Mathf.Clamp01(PlayerMovement.magnitude)) * (Time.deltaTime * MovementSpeed) + new Vector3(FValueNull, PlayerRigid.velocity.y, FValueNull)));
           
            
            
            //PlayerRigid.AddForce((PlayerMovement * (Mathf.Clamp01(PlayerMovement.magnitude) * (Time.deltaTime * MovementSpeed)) - PlayerRigid.velocity), ForceMode.VelocityChange);

            //transform.Translate(PlayerMovement * (Mathf.Clamp01(PlayerMovement.magnitude) * (Time.deltaTime * MovementSpeed)),Space.World);


            //PlayerOrient = Camera.PlayerOrientation;
            //PlayerMovement = (PlayerOrient.forward * Vert) + (PlayerOrient.right * Horizon);
            //PlayerMovement.Normalize();
            //PlayerAnimator.SetFloat("MovementSpeed", Mathf.Clamp01(PlayerMovement.magnitude));
            //PlayerRigid.MovePosition(transform.position + (PlayerMovement * (Mathf.Clamp01(PlayerMovement.magnitude) * (Time.deltaTime * MovementSpeed))));


            if (PlayerMovement != Vector3.zero)
            {
                transform.forward = PlayerMovement;
            }
        }

    }
}
