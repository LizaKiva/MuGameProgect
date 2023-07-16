using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private MoveData Data;

    Rigidbody2D rigidbody;
    bool isFacingRight = true;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (rigidbody.velocity.y < 0)
        {
            SetGravityScale(Data.GravityScale * Data.FallGravityMultiplier);
        }
        else
        {
            SetGravityScale(Data.GravityScale);
        }
    }

    public void Run(float force)
    {

    }

    public void Jump()
    {
        rigidbody.AddForce(Vector2.up * Data.JumpForce, ForceMode2D.Impulse);
    }

    private void Turn()
    {
        //stores scale and flips the player along the x axis, 
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        isFacingRight = !isFacingRight;
    }

    public void SetGravityScale(float scale)
    {
        rigidbody.gravityScale = scale;
    }
}
