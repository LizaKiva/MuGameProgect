using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blobmovement : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float Jumpynes;
    [SerializeField] float JumpForce;
    [SerializeField] float GroundCheckRadius;

    [SerializeField] GameObject Target;
    [SerializeField] Transform GroundCheckObject;
    [SerializeField] LayerMask WhatIsGroud;

    float jumpProbability = 0;
    bool isGrounded = false;
    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheckObject.position, GroundCheckRadius, WhatIsGroud);

        Vector2 vector = Target.transform.position - transform.position;
        rigidbody.velocity = new Vector2((vector * Speed).x, rigidbody.velocity.y);
        jumpProbability += Jumpynes * Time.fixedDeltaTime;

        if(Random.value < jumpProbability)
        {
            Jump();
            jumpProbability = 0;
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            rigidbody.velocity += Vector2.up * JumpForce;
        }
    }
}
