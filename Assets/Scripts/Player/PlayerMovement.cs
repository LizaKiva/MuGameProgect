using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float GroundCheckRadius;
    [SerializeField] float JumpForce;

    [SerializeField] Transform GroundCheckObject;
    [SerializeField] LayerMask WhatIsGroud;

    float horisontalMove = 0;
    bool isGrounded = false;
    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horisontalMove = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheckObject.position, GroundCheckRadius, WhatIsGroud);

        rigidbody.velocity = new Vector2(horisontalMove * Speed, rigidbody.velocity.y);

        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rigidbody.velocity += Vector2.up * JumpForce;
        }
    }
}
