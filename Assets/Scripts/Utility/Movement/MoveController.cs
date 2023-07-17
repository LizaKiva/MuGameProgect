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
        // Скрипт управляет rigidbody объекта на котором висит
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Падения быстрее чем полет вверх, для этого если мы падает увеличиваем гравитацию
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
        // Проверяем, что персонаж хочет изменить направление движения
        if ((speedCoeficient > 0) == (!isFacingRight))
        {
            Flip();
        }

        rigidbody.velocity = new Vector2(speedCoeficient * Data.Speed, rigidbody.velocity.y);
    }

    public void Jump()
    {
        // Просто прыжок, Impulse для создания мгновенной силы
        rigidbody.AddForce(Vector2.up * Data.JumpForce, ForceMode2D.Impulse);
    }

    private void Flip()
    {
        // Переворачиваем спрайт персонажа
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        isFacingRight = !isFacingRight;
    }

    public void SetGravityScale(float scale)
    {
        // Устанавливает силу гравитации
        rigidbody.gravityScale = scale;
    }
}

// TODO:
// Добавить ускорение при движении и соответственно разделить скорость на ускорение и максСкорость
// Подумать можно ли соптимизировать смену гравитации
