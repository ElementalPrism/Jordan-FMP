using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositioning : MonoBehaviour
{

    Vector3 SightDirection;
    float HorizontalInput;
    float VerticalInput;
    Vector3 InputDirection;
    public Transform PlayerOrientation;
    [SerializeField] Transform PlayerTransform;
    [SerializeField] Transform PlayerObjectTransform;
    [SerializeField] Rigidbody PlayerRigidbody;
    [SerializeField] float RotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        SightDirection = PlayerTransform.position - new Vector3(transform.position.x, PlayerTransform.position.y, transform.position.z);
        PlayerOrientation.forward = SightDirection.normalized;

        //HorizontalInput = Input.GetAxis("Horizontal");
        //VerticalInput = Input.GetAxis("Vertical");



    }
}
