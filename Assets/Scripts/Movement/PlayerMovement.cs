using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float Speed;

    Vector2 horisontalMove = new Vector2(0,0);
    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horisontalMove = new Vector2(Input.GetAxis("Horizontal"), 0);
    }

    void FixedUpdate()
    {
        Vector2 vector = horisontalMove * Speed;
        //Debug.Log("Move: " + vector);
        rigidbody.AddForce(vector);
    }
}
