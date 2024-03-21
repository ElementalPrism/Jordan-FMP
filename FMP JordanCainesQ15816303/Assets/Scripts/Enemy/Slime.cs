using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Slime : MonoBehaviour
{
    [SerializeField] NavMeshAgent SlimeAgent;
    [SerializeField] Transform PlayerTransform;
    [SerializeField] JumpKillable JumpHitDetection;
    [SerializeField] GameObject ThisSlime;
    [SerializeField] float ChaseDistance;
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
        if (Vector3.Distance(transform.position, PlayerTransform.position) < ChaseDistance)
        {
            Movement();
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
    }


    void Movement()
    {
        SlimeAgent.SetDestination (PlayerTransform.position);
        SlimeAnimator.SetBool("IsMoving", true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().Health = collision.gameObject.GetComponent<Player>().Health - 1;
            collision.gameObject.GetComponent<Player>().IsHurt = true;
        }
        else
        {
            //do NOTHING
        }
    }
}
