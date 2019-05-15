using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFood : MonoBehaviour
{

    public float Speed = 50.0f;
    private bool BeingCarried = false;
    private bool CollideWithObject = false;
    private bool CloseToPlayer = false;

    public Transform HeldPoint;
    public Transform PlayerCamera;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, HeldPoint.position);

        if(distance <= 0.7f)
        {
            CloseToPlayer = true;
        }
        else
        {
            CloseToPlayer = false;
        }

        if(CloseToPlayer && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && !BeingCarried)
        {
            PickUpFood();
        }

        if(BeingCarried)
        {
            if (CollideWithObject)
            {
                FoodCollision();
            }
            if(OVRInput.Get(OVRInput.RawButton.Back))
            {
                Throw();
            }
        }
    }

    void FoodCollision()
    {
        rb.isKinematic = false;
        transform.parent = null;
        BeingCarried = false;
        CollideWithObject = false;
    }

    void PickUpFood()
    {
        rb.isKinematic = true;
        transform.parent = HeldPoint;
        BeingCarried = true;
    }

    void Throw()
    {
        rb.isKinematic = false;
        transform.parent = null;
        BeingCarried = false;
        rb.AddForce(PlayerCamera.forward * Speed);
    }

     void OnTriggerEnter()
    {
        if (BeingCarried)
        {
            CollideWithObject = true;
        }
    }
}
