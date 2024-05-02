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

    [SerializeField] PlatformCheck CheckPlatform;

    // Start is called before the first frame update
    void Start() //The game hides the cursor in normal gameplay, keeps cursor locked inside of the game window
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        UnityEngine.Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * RaySize, Color.blue); //Shoots a raycast down to see if the player is on the ground
        if (Physics.Raycast(transform.position, Vector3.down, RaySize, Layer)) //If the raycast is a success
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

        Debug.DrawRay(transform.position, Vector3.up * RaySizeRed, Color.red); //Shoots a raycast up to see if the player is on the ground, when they are flipped over via power up
        if (Physics.Raycast(transform.position, Vector3.up, RaySizeRed, Layer)) //if the raycast is a success
        {
            if (PowerUp == true) //if the power up is active
            {
                 IsGrounded = true;
                 PlayerAnimator.SetBool("IsGrounded", true);
                 FlippedOnce = false;
            }

        }





        if (IsGrounded) //Stops force from being added from power up usage
        {
            ThisPlayer.GetComponent<ConstantForce>().force = new Vector3(FValueNull, FValueNull, FValueNull);
        }



        if ((Input.GetKeyDown(KeyCode.Space)) && (IsHurt == false) && (CanMove == true)) 
        {
            if (Pause.IsPaused == false)
            {
                if (!VictoryTime)
                {
                    if (IsGrounded) //Checks if the player can move, if the space bar has been pressed and if the player is grounded for the player to jump
                    { 
                        Jump();
                    }
                    else if (!IsGrounded)
                    {

                        if ((PowerUp == true)) //Checks if power up is currently being used
                        {
                            if (GravityFlipped == false)
                            {
                                if(FlippedOnce == false) //Allows the player to flip upside down once if they havent
                                {
                                    ThisPlayer.GetComponent<Rigidbody>().useGravity = false;
                                    
                                    Flipped = true;
                                    FlippedOnce = true;
                                    CameraFree.m_Lens.Dutch = FlipValue;
                                    CameraFree.m_XAxis.m_InvertInput = true;
                                    GravityFlipped = true;
                                }

                            }
                            else if (GravityFlipped == true)
                            {
                                if (FlippedOnce == false) //Allows the player to flip the correct way once if they havent
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
                if(!VictoryTime) //Checks to see if the player can attack and if the mouse has been left clicked
                {
                   Attack();
                }
               
              }
            }

        }


        if (Flipped == true) //Checks to see if the player wants to flip gravity then adds force to the player to gravitate them to the ceiling
        {
            var PlayerRotation = ThisPlayer.transform.eulerAngles;
            ThisPlayer.GetComponent<ConstantForce>().force = new Vector3(FValueNull, GravityValue, FValueNull);
            ThisPlayer.transform.rotation = Quaternion.Euler(PlayerRotation.x, PlayerRotation.y, FlipValue);
            
        }



        //These 2 functions are used to activate the fall animation if the player is falling and not on the edge of a platform
        if (!CheckPlatform.StopYVelocity)
        {
            PlayerY = PlayerRigid.velocity.y;
            PlayerAnimator.SetFloat("AirSpeed", PlayerY);
        }

        if(CheckPlatform.StopYVelocity)
        {
            PlayerAnimator.SetBool("IsGrounded", true);
        }



        if (IsHurt == true) //Checks to see if the player gets hurt and stops the player attack from occuring if the player is hurt
        {
            PlayerAnimator.SetBool("IsHurt", true);

            if(IsAttacking)
            {
                StopAttack();
            }
        }

        if (IsDead == true) //Activates the death animation
        {
            PlayerAnimator.SetBool("IsDead", true);
        }

        if (PowerUp) //Checks to see if the power up is in affect
        {
            
           
            if (CanMove == true) //if the game isnt paused, the power up particles will appear, the level music will stop, allowing the power up music to play and the power up timer will start ticking down
            {
                PowerUpSparkles.SetActive(true);

                   LevelMusic.enabled = false;
                
                PowerUpMusic.enabled = true;

                
                StartCoroutine(PowerUpTimer());
            }
            
        }

        if(CanMove == false) //sets player speed in the animator to 0 if the player cannot move
        {
            PlayerAnimator.SetFloat("MovementSpeed", ValueNull);
        }

        PlayerTransformSave = ThisPlayer.transform;




        if (VictoryTime) //Activates the player victory dance whilst everything else freezes in place
        {
            PlayerAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
            PlayerAnimator.SetBool("Victory", true);
            Time.timeScale = TimeStop;
        }


        //Changes the way the camera is updated as when the player is upside down with fixed update, the player to will constantly spin when they move in a direction

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
        
        if (!VictoryTime) //checks to see if the player can move
        {
            Movement(); //Player Movement
        }

    }

    void Attack() //Players attack, causes the animation to play and the hitbox to appear
    {
        if (!IsAttacking)
        {
            IsAttacking = true;
            PlayerAnimator.SetBool("Attack", true);
            PlayerAttackBox.SetActive(true);

        }
    }

    public void StopVictory() //Stops the player victory dance and resets everything back to normal before loading the lobby
    {
        Time.timeScale = TimeStart;
        PlayerAnimator.SetBool("Victory", false);
        VictoryTime = false;
        Pause.IsPaused = false;
        PlayerAnimator.updateMode = AnimatorUpdateMode.Normal;
        SceneManager.LoadScene(Lobby);
    }

    public void StopAttack() //Stops the attack animation and deactivates the attack hitbox (called from animation)
    {
        PlayerAnimator.SetBool("Attack", false);
        PlayerAttackBox.SetActive(false);
        IsAttacking= false;
    }

    public void StopHurt() //stops the hurt animation (called from animation)
    {
        PlayerAnimator.SetBool("IsHurt", false);
        IsHurt = false;
    }

    public void RemoveLife() //Removes a life from the player and reloads them at the lobby area
    {
        LivesManager.LivesAmount = LivesManager.LivesAmount - LivesDeduction;

        if (LivesManager.LivesAmount > NoLives)
        {
            SceneManager.LoadScene(Lobby);
        }
    }


    void Jump() //Player Jump Function, checks to see which direction the jump is going due to the force having to go down when the player is upside down
    {
        if (GravityFlipped == false)
        {
           PlayerRigid.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
        else if (GravityFlipped == true)
        {
           PlayerRigid.AddForce(Vector3.down * JumpForce, ForceMode.Impulse);
        }
        



    }

    IEnumerator PowerUpTimer() //This times the power up and causes the player to revert back to normal gravity when the timer is up, also stops the power up music and re-enabled the level music
    {
        
        yield return new WaitForSeconds(PowerUpTime);
        
        PowerUp = false;
        PowerUpSparkles.SetActive(false);
        ThisPlayer.GetComponent<Rigidbody>().useGravity = true;

        ThisPlayer.GetComponent<ConstantForce>().force = new Vector3(FValueNull, FValueNull, FValueNull);

        if (Flipped == true)
        {
            ThisPlayer.transform.Rotate(ValueNull, ValueNull, FlipValue);
            Flipped = false;
        }


        
        PowerUpMusic.enabled = false;
        
        LevelMusic.enabled = true;

        CameraFree.m_Lens.Dutch = ValueNull;
        CameraFree.m_XAxis.m_InvertInput = false;
        GravityFlipped = false;
        PowerUpObject.SetActive(true);

    }

    void Movement()
    {
        if ( (IsHurt == false) && (CanMove == true)) //Checks to see if the player can move
        {
            if (Flipped == false) //Player's normal movement input
            {
                Horizon = Input.GetAxis("Horizontal");
                JumpForce = DefaultJumpForce;

            }
            else if (Flipped == true) //makes the movement axis be the same when the player is upside down, turns down jump force due to it being to high when upside down
            {
                Horizon = -Input.GetAxis("Horizontal");
                JumpForce = FlippedJumpForce;
            }

            Vert = Input.GetAxis("Vertical");

           
            //The following grabs the camera orientation and then moves the player to correspond with where the camera is facing 
            PlayerOrient = Camera.PlayerOrientation;
            PlayerMovement = (PlayerOrient.forward * Vert) + (PlayerOrient.right * Horizon);
            PlayerMovement.Normalize();
            PlayerAnimator.SetFloat("MovementSpeed", Mathf.Clamp01(PlayerMovement.magnitude)); //Clamp is used so that the player doesnt gain more speed by going diagonally
            
            PlayerRigid.velocity = ((PlayerMovement * (Mathf.Clamp01(PlayerMovement.magnitude)) * (Time.deltaTime * MovementSpeed) + new Vector3(FValueNull, PlayerRigid.velocity.y, FValueNull)));
           
            
            



            if (PlayerMovement != Vector3.zero) //Changes the player's forward location to match where it is on the camera
            {
                transform.forward = PlayerMovement;
            }
        }

    }
}
