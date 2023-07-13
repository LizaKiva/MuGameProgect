using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Blobmovement : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float Jumpynes;
    [SerializeField] float JumpForce;
    [SerializeField] float GroundCheckRadius;
    [SerializeField] float OuterRadius;
    [SerializeField] float InnerRadius;

    [SerializeField] GameObject Target;
    [SerializeField] Transform GroundCheckObject;
    [SerializeField] LayerMask WhatIsGroud;

    float jumpProbability = 0;
    bool isGrounded = false;
    bool isFlying = false;
    Rigidbody2D rigidbody;
    Collider2D collider;

    float FLY_COEFICENT = (float)(1 / 1.3); // 1.3 is just sligtly smaller than sqrt(2)

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        Vector2 vector = Target.transform.position - transform.position;

        if(!isFlying && vector.magnitude > OuterRadius)
        {
            isFlying = true;
            collider.enabled = false;
        }

        if(vector.magnitude < InnerRadius)
        {
            isFlying = false;
            collider.enabled = true;
            transform.rotation = Quaternion.identity;
        }

        if (isFlying)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            Vector3 direction = mousePosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            rigidbody.velocity = vector * Speed * FLY_COEFICENT;
        }
        else
        {
            isGrounded = Physics2D.OverlapCircle(GroundCheckObject.position, GroundCheckRadius, WhatIsGroud);

            rigidbody.velocity = new Vector2((vector * Speed).x, rigidbody.velocity.y);
            jumpProbability += Jumpynes * Time.fixedDeltaTime;

            if (Random.value < jumpProbability)
            {
                Jump();
                jumpProbability = 0;
            }
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
