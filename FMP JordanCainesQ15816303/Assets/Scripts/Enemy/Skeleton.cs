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

    public Animator SkeletonAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Vector3.Distance(transform.position, PlayerTransform.position) < TriggerDistance) && Waiting == false) 
        { 
            if(!Charging)
            {
               // SkeletonAnimator.SetBool("IsMoving", true);
                TargetPosition = PlayerTransform.position;
                transform.LookAt(TargetPosition);
                Charging = true;
            }

            SkeletonAnimator.SetBool("IsInCombat", true);

        }
        
        if(Vector3.Distance(transform.position, PlayerTransform.position) > TriggerDistance)
        {
            SkeletonAnimator.SetBool("IsInCombat", false);
        }


        if ((Vector3.Distance(transform.position, TargetPosition) < TargetDistance) && Charging)
        {
            SkeletonAnimator.SetBool("IsMoving", false);
            Charging = false;
            Waiting = true;
            StartCoroutine(StartWait());
            
        }

        if (JumpHitDetection.TakenHit)
        {
            ThisSkeleton.SetActive(false);
        }

        if (IsDead == true)
        {
            Destroy(ThisSkeleton);
        }


        Movement();

    }

    void Movement()
    {
        if(Charging)
        {
            SkeletonAgent.SetDestination(TargetPosition);
            SkeletonAnimator.SetBool("IsMoving", true);
        }
    }

    IEnumerator StartWait()
    {
        yield return new WaitForSeconds(WaitTime);
        Waiting = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if (collision.gameObject.GetComponent<Player>().IsHurt == false)
            {
                if (SkeletonAnimator.GetBool("IsDead") == false)
                {
                    collision.gameObject.GetComponent<Player>().Health = collision.gameObject.GetComponent<Player>().Health - 2;
                    collision.gameObject.GetComponent<Player>().IsHurt = true;
                }

            }

        }
        else
        {
            //do NOTHING
        }
    }
}
