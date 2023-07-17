using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float GroundCheckRadius;
    [SerializeField] Transform GroundCheckObject;
    [SerializeField] LayerMask WhatIsGroud;
    [SerializeField] MoveController Controller;

    float horisontalMove = 0;
    bool isGrounded = false;
    Rigidbody2D rigidbody;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horisontalMove = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheckObject.position, GroundCheckRadius, WhatIsGroud);

        Controller.Run(horisontalMove);
        //rigidbody.velocity = new Vector2(horisontalMove * Speed, rigidbody.velocity.y);

        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            //rigidbody.velocity += Vector2.up * JumpForce;
            Controller.Jump();
        }
    }
}
