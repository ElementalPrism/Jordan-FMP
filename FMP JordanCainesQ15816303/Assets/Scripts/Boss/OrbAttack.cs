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
       TargetPosition = PlayerTarget.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //TargetPosition.position = PlayerTarget.position;

        if (Vector3.Distance(transform.position, TargetPosition) < TargetDistance)
        {
            Destroy(ThisObject);
        }


        Movement();
    }

    void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, (Speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            other.gameObject.GetComponent<Player>().Health = other.gameObject.GetComponent<Player>().Health - Damage;
            other.gameObject.GetComponent<Player>().IsHurt = true;
            Destroy(ThisObject);
        }
    }
}
