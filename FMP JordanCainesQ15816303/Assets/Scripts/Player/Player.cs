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

    
    public Rigidbody PlayerRigid;
    RaycastHit DownwardRaycast;

    // Start is called before the first frame update
    void Start()
    {
        
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



        //if (Input.GetKeyDown(KeyCode.Mouse1))
        //{
        //    if(IsHurt == false)
        //    {

        //        if ((PowerUp == true))
        //        {
        //            if (GravityFlipped == false)
        //            {
        //                ThisPlayer.GetComponent<Rigidbody>().useGravity = false;
        //                ThisPlayer.GetComponent<ConstantForce>().force = new Vector3(0f, 5f, 0f);
        //                GravityFlipped = true;
        //            }
        //            else if (GravityFlipped == true)
        //            {
        //                ThisPlayer.GetComponent<Rigidbody>().useGravity = true;
        //                ThisPlayer.GetComponent<ConstantForce>().force = new Vector3(0f, -5f, 0f);
        //                GravityFlipped = false;
        //            }


        //        }

        //    }

        //}



        if (IsGrounded)
        {
            ThisPlayer.GetComponent<ConstantForce>().force = new Vector3(0f, 0f, 0f);
        }



        if ((Input.GetKeyDown(KeyCode.Space)) && (IsHurt == false) && (CanMove == true)) 
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
                            CameraFree.m_Lens.Dutch = 180;
                            CameraFree.m_XAxis.m_InvertInput = true;
                            GravityFlipped = true;
                        }

                    }
                    else if (GravityFlipped == true)
                    {
                        if (FlippedOnce == false) 
                        {
                            ThisPlayer.GetComponent<Rigidbody>().useGravity = true;
                            ThisPlayer.GetComponent<ConstantForce>().force = new Vector3(0f, -5f, 0f);
                            Flipped = false;
                            FlippedOnce = true;
                            ThisPlayer.transform.Rotate(0, 0, 180);
                            CameraFree.m_Lens.Dutch = 0;
                            CameraFree.m_XAxis.m_InvertInput = false;
                            GravityFlipped = false;

                        }
                    }

                }
            }

        }

        if ((Input.GetKeyDown(KeyCode.Mouse0)) && (IsHurt == false) && (CanMove == true))
        {
            if (IsGrounded) 
            {
                Attack();
            }
        }


        if (Flipped == true)
        {
            var PlayerRotation = ThisPlayer.transform.eulerAngles;
            ThisPlayer.GetComponent<ConstantForce>().force = new Vector3(0f, 5f, 0f);
            ThisPlayer.transform.rotation = Quaternion.Euler(PlayerRotation.x, PlayerRotation.y, 180);
            
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
        }

        if (IsDead == true)
        {
            PlayerAnimator.SetBool("IsDead", true);
        }

        if (PowerUp)
        {
            if (CanMove == true)
            {
                 StartCoroutine(PowerUpTimer());
            }
 
        }

        if(CanMove == false)
        {
            PlayerAnimator.SetFloat("MovementSpeed", 0);
        }

        PlayerTransformSave = ThisPlayer.transform;
    }

    private void FixedUpdate()
    {
        Movement();
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
        LivesManager.LivesAmount = LivesManager.LivesAmount - 1;

        if (LivesManager.LivesAmount > 0)
        {
            SceneManager.LoadScene(1);
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
        yield return new WaitForSeconds(PowerUpTime);
        PowerUp = false;
        ThisPlayer.GetComponent<Rigidbody>().useGravity = true;
        ThisPlayer.GetComponent<ConstantForce>().force = new Vector3(0f, 0f, 0f);
        CameraFree.m_Lens.Dutch = 0;
        CameraFree.m_XAxis.m_InvertInput = false;
        GravityFlipped = false;

    }

    void Movement()
    {
        if ((!IsAttacking) && (IsHurt == false) && (CanMove == true))
        {
            if (Flipped == false)
            {
                Horizon = Input.GetAxis("Horizontal");

            }
            else if (Flipped == true)
            {
                Horizon = -Input.GetAxis("Horizontal");
            }

            Vert = Input.GetAxis("Vertical");

            //PlayerMovement = new Vector3(Horizon, 0, Vert);
            //PlayerMovement.Normalize();
            
            PlayerOrient = Camera.PlayerOrientation;
            PlayerMovement = (PlayerOrient.forward * Vert) + (PlayerOrient.right * Horizon);
            PlayerMovement.Normalize();
            PlayerAnimator.SetFloat("MovementSpeed", Mathf.Clamp01(PlayerMovement.magnitude));
            transform.position = transform.position + (PlayerMovement * (Mathf.Clamp01(PlayerMovement.magnitude) * (Time.deltaTime * MovementSpeed)));

            //PlayerOrient = Camera.PlayerOrientation;
            //PlayerMovement = (PlayerOrient.forward * Vert) + (PlayerOrient.right * Horizon);
            //PlayerMovement.Normalize();
            //PlayerAnimator.SetFloat("MovementSpeed", Mathf.Clamp01(PlayerMovement.magnitude));
            ////PlayerRigid.MovePosition(transform.position + (PlayerMovement * (Mathf.Clamp01(PlayerMovement.magnitude) * (Time.deltaTime * MovementSpeed))));

            if (PlayerMovement != Vector3.zero)
            {
                transform.forward = PlayerMovement;
            }
        }

    }
}
