using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blobmovement : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] GameObject Target;
    [SerializeField] float Jumpynes;
    [SerializeField] float JumpForce;

    Rigidbody2D rigidbody;
    float jumpProbability = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
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
        rigidbody.AddForce(new Vector2 (0f, JumpForce));
    }
}
