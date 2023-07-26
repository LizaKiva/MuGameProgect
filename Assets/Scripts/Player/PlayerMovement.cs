using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int ExtraJumps;              // ���������� �������������� �������
    [SerializeField] float RetryTime;             // ����� ������� ������� ����� ������� ������
    [SerializeField] float JumpCooldownTime;      // ����� ����������� ������
    [SerializeField] float CoyoteTime;            // ����� � ������� �������� ����� ��������� ����� ����� �������
    [SerializeField] float GroundCheckRadius;     // ������ ����� ������������ ������� �� �����
    [SerializeField] Transform GroundCheckObject; // ������ ����������� ��� ����� ����� �� �����
    [SerializeField] LayerMask WhatIsGroud;       // ���� �����
    [SerializeField] MoveController Controller;   // ���������� ���������� �� ��������

    int jumpsLeft = 0;               // ������� ������� �� ������� ����� ��� ����� �������
    float jumpCooldown = 0;          // ������� ������ ��� ������ �������
    float jumpRetryTimer;            // ������� ������ ��� �������� ����� �������� ��������� ������
    float timeSinceLastGrounded = 0; // ������� ������ ������ � ���������� ������� �����
    float horisontalMove = 0;        // Input ������ �� �����������
    bool isGrounded = false;         // ��������� �� ������ ����� �� �����
    Rigidbody2D rigidbody;           // ��������� Rigidbody ������

    void Start()
    {
        // ������������� Rigidbody
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ���������� �������� ������ (����� ���� ������ 0)
        jumpCooldown -= Time.deltaTime;

        // ���������� timeSinceLastGrounded
        if (isGrounded)
        {
            timeSinceLastGrounded = 0;
        }
        else
        {
            timeSinceLastGrounded += Time.deltaTime;
        }

        // ��������� ������� ������ �� �����������
        horisontalMove = Input.GetAxis("Horizontal");

        // ���������, �������� �� ����� ��������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpRetryTimer = RetryTime;
        }

        // ��������� ����� �� �� ����=������� �������� � ��������
        if (jumpRetryTimer > 0)
        {
            jumpRetryTimer -= Time.deltaTime;
            TryJump();
        }
    }

    void FixedUpdate()
    {
        // ���������, �� ����� �� ��������
        isGrounded = Physics2D.OverlapCircle(GroundCheckObject.position, GroundCheckRadius, WhatIsGroud);

        // ��������� ��� ������
        Controller.Run(horisontalMove);
    }

    bool TryJump()
    {
        // ��������� ��� ����� �������� (�������)
        if (jumpCooldown <= 0)
        {
            if (isGrounded || timeSinceLastGrounded < CoyoteTime)
            {
                // ���������, ��� �� �� �����, ��� ������� � �������
                // ����� ��������� ��� ������ ���������
                Controller.Jump();
                jumpsLeft = ExtraJumps;
                jumpCooldown = JumpCooldownTime;
                return true;
            }
            else if (jumpsLeft > 0)
            {
                // ���������, ��� ��� �� �� ����� �������� �� �����, � ��� ��� ���� ������ ������
                // ����� ��������� ��� ������ ���������
                Controller.Jump();
                jumpsLeft--;
                jumpCooldown = JumpCooldownTime;
                return true;
            }
        }

        return false;
    }
}
