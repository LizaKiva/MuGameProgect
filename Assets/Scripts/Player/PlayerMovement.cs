using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int ExtraJumps;              // Количество дополнительных прыжков
    [SerializeField] float RetryTime;             // Время попыток прыгать после нажатия прыжка
    [SerializeField] float JumpCooldownTime;      // Время перезарядки прыжка
    [SerializeField] float CoyoteTime;            // Время в течение которого после покидания земли можно прыгать
    [SerializeField] float GroundCheckRadius;     // Размер круга проверяющего стояние на земле
    [SerializeField] Transform GroundCheckObject; // Объект проверяющий что игрок стоит на земле
    [SerializeField] LayerMask WhatIsGroud;       // Слой земли
    [SerializeField] MoveController Controller;   // Контроллер отвечающий за движение

    int jumpsLeft = 0;               // Сколько прыжков до касания земли ещё можно сделать
    float jumpCooldown = 0;          // Сколько секунд ещё нельзя прыгать
    float jumpRetryTimer;            // Сколько секунд ещё персонаж будет пытаться выполнить прыжок
    float timeSinceLastGrounded = 0; // Сколько секунд прошло с последнего касания земли
    float horisontalMove = 0;        // Input игрока по горизонтали
    bool isGrounded = false;         // Находится ли сейчас игрок на земле
    Rigidbody2D rigidbody;           // Компонент Rigidbody игрока

    void Start()
    {
        // Инициализация Rigidbody
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Уменьшение кулдауна прыжка (может уйти меньше 0)
        jumpCooldown -= Time.deltaTime;

        // Обновление timeSinceLastGrounded
        if (isGrounded)
        {
            timeSinceLastGrounded = 0;
        }
        else
        {
            timeSinceLastGrounded += Time.deltaTime;
        }

        // Получение нажатия игрока по горизонтали
        horisontalMove = Input.GetAxis("Horizontal");

        // Проверяем, пытается ли игрок прыгнуть
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpRetryTimer = RetryTime;
        }

        // Проверяем хотим ли мы попа=ытаться прыгнуть и пытаемся
        if (jumpRetryTimer > 0)
        {
            jumpRetryTimer -= Time.deltaTime;
            TryJump();
        }
    }

    void FixedUpdate()
    {
        // Обновляем, на земле ли персонаж
        isGrounded = Physics2D.OverlapCircle(GroundCheckObject.position, GroundCheckRadius, WhatIsGroud);

        // Запускаем бег игрока
        Controller.Run(horisontalMove);
    }

    bool TryJump()
    {
        // Проверяем что можем прыгнуть (кулдаун)
        if (jumpCooldown <= 0)
        {
            if (isGrounded || timeSinceLastGrounded < CoyoteTime)
            {
                // Проверяем, что он на земле, или недавно её покинул
                // Тогда обновляем все нужные параметры
                Controller.Jump();
                jumpsLeft = ExtraJumps;
                jumpCooldown = JumpCooldownTime;
                return true;
            }
            else if (jumpsLeft > 0)
            {
                // Проверяем, что раз мы не можем прыгнуть от земли, у нас ещё есть лишние прыжки
                // Тогда обновляем все нужные параметры
                Controller.Jump();
                jumpsLeft--;
                jumpCooldown = JumpCooldownTime;
                return true;
            }
        }

        return false;
    }
}
