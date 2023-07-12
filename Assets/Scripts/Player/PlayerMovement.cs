using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float Speed;

    float horisontalMove = 0;
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
        rigidbody.velocity = new Vector2(horisontalMove * Speed, rigidbody.velocity.y);
    }
}
