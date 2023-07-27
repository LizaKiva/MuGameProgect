using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private MoveData Data;

    Rigidbody2D rigidbody;     // ��������� Rigidbody ������
    bool isFacingRight = true; // ������� �� �������� �������
    bool wasJumpCut = false;   // ���� �� ������� ��������� ������

    void Start()
    {
        // ������ ��������� rigidbody ������� �� ������� �����
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // ���� �� ����� �������� ������, �� �������� ����������, � ��� ������� ��� ���������
        if (wasJumpCut)
        {
            SetGravityScale(Data.GravityScale * Data.FallGravityMultiplier);

            // �� ��� ������, ������ ������ ���
            if (rigidbody.velocity.y < 0)
            {
                wasJumpCut = false;
            }
        }
        else
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
    }

    public void Run(float speedCoeficient)
    {
        // ���������, ��� �������� ����� �������� ����������� ��������
        if ((speedCoeficient != 0) && ((speedCoeficient > 0) == (!isFacingRight)))
        {
            Flip();
        }

        rigidbody.velocity = new Vector2(speedCoeficient * Data.Speed, rigidbody.velocity.y);
    }

    public void CutJump()
    {
        // ������ �������, ��� ������ ��� ����������
        wasJumpCut = true;
    }

    public void Jump()
    {
        // ������� ������������ ��������, ����� ������ ��� ������ ���������� ����
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);

        // ��� ������, Impulse ��� �������� ���������� ����
        rigidbody.AddForce(Vector2.up * Data.JumpForce, ForceMode2D.Impulse);

        // ������ ��������, ����� ����� �� ����������
        wasJumpCut = false;
    }

    private void Flip()
    {
        // �������������� ������ ���������
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        // ������ �� ������� � ������ �������
        isFacingRight = !isFacingRight;
    }

    public void SetGravityScale(float scale)
    {
        // ������������� ���� ����������
        rigidbody.gravityScale = scale;
    }
}
