using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OrbAttack : MonoBehaviour
{

    public Transform PlayerTarget;
    [SerializeField] float TargetDistance;
    [SerializeField] float Speed;
    public GameObject ThisObject;
    float Distance = 12;
    public Transform BossTransform;
    Vector3 TargetPosition;

    int Damage = 1;

    // Start is called before the first frame update
    void Start()
    {
       TargetPosition = PlayerTarget.position; //Gets a target from the player
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (Vector3.Distance(transform.position, TargetPosition) < TargetDistance)  //If the orb gets close to the target, it will delete itself
        {
            Destroy(ThisObject);
        }


        Movement();
    }

    void Movement() //This moves orb towards the target spot
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, (Speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other) //The orb deals damage to player and deletes itself if it hits the player
    {
        if (other.gameObject.GetComponent<Player>())
        {
            other.gameObject.GetComponent<Player>().Health = other.gameObject.GetComponent<Player>().Health - Damage;
            other.gameObject.GetComponent<Player>().IsHurt = true;
            Destroy(ThisObject);
        }
    }
}
