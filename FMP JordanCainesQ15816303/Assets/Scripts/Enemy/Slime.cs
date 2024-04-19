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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Vector3.Distance(transform.position, PlayerTransform.position) < ChaseDistance) && (TargetPlayer.IsHurt == false))
        {
            Movement();
            StartCoroutine(ChaseTimer());
        }
        else
        {
            SlimeAnimator.SetBool("IsMoving", false);
        }

        if(JumpHitDetection.TakenHit)
        {
            Destroy(ThisSlime);
        }

        if (IsDead == true)
        {
            Destroy(ThisSlime);
        }

        SlimeAnimator.SetFloat("MovementSpeed", SlimeAgent.velocity.magnitude);
    }


    void Movement()
    {
        SlimeAgent.isStopped = false;
        TargetPosition = PlayerTransform.position;
        TargetPosition.y = transform.position.y;
        SlimeAgent.SetDestination (TargetPosition);

        //SlimeAnimator.SetBool("IsMoving", true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if(collision.gameObject.GetComponent<Player>().IsHurt == false)
            {
                if(SlimeAnimator.GetBool("IsDead") == false)
                {
                    collision.gameObject.GetComponent<Player>().Health = collision.gameObject.GetComponent<Player>().Health - 1;
                    collision.gameObject.GetComponent<Player>().IsHurt = true;
                }

            }

        }
        else
        {
            //do NOTHING
        }
    }

    IEnumerator ChaseTimer()
    {
        yield return new WaitForSeconds(ChaseTime);
        SlimeAgent.isStopped = true;
    }

}
