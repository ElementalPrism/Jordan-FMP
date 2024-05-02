using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Slime : MonoBehaviour
{
    [SerializeField] NavMeshAgent SlimeAgent;
    [SerializeField] Player TargetPlayer;
    [SerializeField] Transform PlayerTransform;
    Vector3 TargetPosition;
    [SerializeField] JumpKillable JumpHitDetection;
    [SerializeField] GameObject ThisSlime;
    [SerializeField] float ChaseDistance;
    [SerializeField] float ChaseTime;
    Vector3 TargetLocator;
    //JumpKillable KillCheck;
    bool CanAttack;
    public bool IsDead;

    public Animator SlimeAnimator;

    float SquishScale = 0.02f;
    int Damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Vector3.Distance(transform.position, PlayerTransform.position) < ChaseDistance) && (TargetPlayer.IsHurt == false)) //Slime chases the player if they are nearby
        {
            if (!IsDead)
            {
                 if(JumpHitDetection.TakenHit == false) //Cannot chase if they are squished
                 {
                     Movement();
                     StartCoroutine(ChaseTimer());
                 }

            }

        }
        else
        {
            SlimeAnimator.SetBool("IsMoving", false);
        }

        if(JumpHitDetection.TakenHit) //Small squish animation for the slimes
        {
            Vector3 SlimeScale = ThisSlime.transform.localScale;
            SlimeScale.y = SquishScale;
            ThisSlime.transform.localScale = SlimeScale;
            SlimeAnimator.SetBool("IsDead", true);

        }

        if (IsDead == true)
        {
            Destroy(ThisSlime);
        }

        SlimeAnimator.SetFloat("MovementSpeed", SlimeAgent.velocity.magnitude);
    }


    void Movement()  //Slime Movement towards player
    {
        SlimeAgent.isStopped = false;
        TargetPosition = PlayerTransform.position;
        TargetPosition.y = transform.position.y;
        SlimeAgent.SetDestination (TargetPosition);


    }

    private void OnCollisionEnter(Collision collision) //Deals damage to player if the player touches the slime
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if(collision.gameObject.GetComponent<Player>().IsHurt == false)
            {
                if(SlimeAnimator.GetBool("IsDead") == false)
                {
                    if(JumpHitDetection.TakenHit == false) 
                    { 
                        collision.gameObject.GetComponent<Player>().Health = collision.gameObject.GetComponent<Player>().Health - Damage;
                        collision.gameObject.GetComponent<Player>().IsHurt = true;
                    }

                }

            }

        }
        else
        {
            //do NOTHING
        }
    }

    IEnumerator ChaseTimer() //Used to have the slime stop chasing for a little bit after a certain time, or after hitting the player
    {
        yield return new WaitForSeconds(ChaseTime);
        SlimeAgent.isStopped = true;
    }

}
