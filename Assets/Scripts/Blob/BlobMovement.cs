using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blobmovement : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] GameObject target;

    Rigidbody2D rigidbody;

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
        Vector2 vector = target.transform.position - transform.position;
        //Debug.Log("Move: " + vector);
        rigidbody.velocity = new Vector2((vector * Speed).x, rigidbody.velocity.y);
    }
}
