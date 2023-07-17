using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private MoveData Data;

    Rigidbody2D rigidbody;
    bool isFacingRight = true;

    void Start()
    {
        // ������ ��������� rigidbody ������� �� ������� �����
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // ������� ������� ��� ����� �����, ��� ����� ���� �� ������ ����������� ����������
        if (rigidbody.velocity.y < 0)
        {
            SetGravityScale(Data.GravityScale * Data.FallGravityMultiplier);
        }
        else
        {
            SetGravityScale(Data.GravityScale);
        }
    }

    public void Run(float speedCoeficient)
    {
        // ���������, ��� �������� ����� �������� ����������� ��������
        if ((speedCoeficient > 0) == (!isFacingRight))
        {
            Flip();
        }

        rigidbody.velocity = new Vector2(speedCoeficient * Data.Speed, rigidbody.velocity.y);
    }

    public void Jump()
    {
        // ������ ������, Impulse ��� �������� ���������� ����
        rigidbody.AddForce(Vector2.up * Data.JumpForce, ForceMode2D.Impulse);
    }

    private void Flip()
    {
        // �������������� ������ ���������
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        isFacingRight = !isFacingRight;
    }

    public void SetGravityScale(float scale)
    {
        // ������������� ���� ����������
        rigidbody.gravityScale = scale;
    }
}

// TODO:
// �������� ��������� ��� �������� � �������������� ��������� �������� �� ��������� � ������������
// �������� ����� �� ��������������� ����� ����������
