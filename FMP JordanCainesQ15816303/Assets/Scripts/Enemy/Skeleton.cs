using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    [SerializeField] NavMeshAgent SkeletonAgent;
    [SerializeField] Transform PlayerTransform; 
    [SerializeField] JumpKillable JumpHitDetection;
    [SerializeField] GameObject ThisSkeleton;
    Vector3 TargetPosition;
    [SerializeField] float TriggerDistance;
    [SerializeField] float TargetDistance;
    [SerializeField] float WaitTime;
    bool Charging;
    bool Waiting;
    public bool IsDead; 
    [SerializeField] float ChaseTime;

    public Animator SkeletonAnimator;

    int Damage = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Vector3.Distance(transform.position, PlayerTransform.position) <= TriggerDistance) && Waiting == false) //Checks to see if the player is nearby and the skeleton is not on cooldown
        { 
            if(!Charging) //Causes the skeleton to charge at the player if they are not on cooldown
            {
                SkeletonAgent.isStopped = false;
                TargetPosition = PlayerTransform.position;
                TargetPosition.y = transform.position.y;
                transform.LookAt(TargetPosition);
                StartCoroutine(ChaseTimer());
                Charging = true;
            }

            SkeletonAnimator.SetBool("IsInCombat", true); //Activates skeleton battle stance
            
        }
        
        if(Vector3.Distance(transform.position, PlayerTransform.position) > TriggerDistance) //Deactivates skeleton battle stance
        {
            SkeletonAnimator.SetBool("IsInCombat", false);
        }


        if ((Vector3.Distance(transform.position, TargetPosition) < TargetDistance) && Charging) //After the skeleton chases a target position for a while, it will cause the skeleton to go on cooldown and not move
        {
            SkeletonAnimator.SetBool("IsMoving", false);
            Charging = false;
            Waiting = true;
            StartCoroutine(StartWait());
            
        }


        if (IsDead == true) //Gets rid of the skeleton after death animation
        {
            Destroy(ThisSkeleton);
        }


        Movement();
        
    }

    void Movement() //Skeleton Movement
    {
        if(Charging)
        {
            SkeletonAgent.SetDestination(TargetPosition);
            SkeletonAnimator.SetBool("IsMoving", true);
            Debug.Log("Start Timer");  
        }
    }

    IEnumerator StartWait() //Activates timer for the skeleton to wait before charging again
    {
        yield return new WaitForSeconds(WaitTime);
        Waiting = false;
    }

    private void OnCollisionEnter(Collision collision) //Hurts the player if the player gets hit by the skeleton
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if (collision.gameObject.GetComponent<Player>().IsHurt == false)
            {
                if (SkeletonAnimator.GetBool("IsDead") == false)
                {
                    collision.gameObject.GetComponent<Player>().Health = collision.gameObject.GetComponent<Player>().Health - Damage;
                    collision.gameObject.GetComponent<Player>().IsHurt = true;
                }

            }

        }
        else
        {
            //do NOTHING
        }
    }

    IEnumerator ChaseTimer() //Activates how long the skeleton chases, if they don't reach their target in time, they will stop charging
    {
        yield return new WaitForSeconds(ChaseTime);
        SkeletonAgent.isStopped = true;
        SkeletonAnimator.SetBool("IsMoving", false);
        Charging = false;
        Waiting = true;
        StartCoroutine(StartWait());

    }
}
