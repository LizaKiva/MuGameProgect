using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private MoveData Data;

    Rigidbody2D rigidbody;     // Компонент Rigidbody игрока
    bool isFacingRight = true; // Смотрит ли персонаж направо
    bool wasJumpCut = false;   // Была ли команда прерывать прыжок

    void Start()
    {
        // Скрипт управляет rigidbody объекта на котором висит
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Если мы хотим прервать прыжок, мы увеличим гравитацию, и это быстрее его остановит
        if (wasJumpCut)
        {
            SetGravityScale(Data.GravityScale * Data.FallGravityMultiplier);

            // Мы уже падаем, прыжка больше нет
            if (rigidbody.velocity.y < 0)
            {
                wasJumpCut = false;
            }
        }
        else
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
    }

    public void Run(float speedCoeficient)
    {
        // Проверяем, что персонаж хочет изменить направление движения
        if ((speedCoeficient != 0) && ((speedCoeficient > 0) == (!isFacingRight)))
        {
            Flip();
        }

        rigidbody.velocity = new Vector2(speedCoeficient * Data.Speed, rigidbody.velocity.y);
    }

    public void CutJump()
    {
        // Просто говорим, что прыжок был остановлен
        wasJumpCut = true;
    }

    public void Jump()
    {
        // Убираем вертикальную скорость, чтобы прыжок был всегда одинаковой силы
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);

        // Сам прыжок, Impulse для создания мгновенной силы
        rigidbody.AddForce(Vector2.up * Data.JumpForce, ForceMode2D.Impulse);

        // Только прыгнули, пыжок точно не остановлен
        wasJumpCut = false;
    }

    private void Flip()
    {
        // Переворачиваем спрайт персонажа
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        // Теперь он смотрит в другую сторону
        isFacingRight = !isFacingRight;
    }

    public void SetGravityScale(float scale)
    {
        // Устанавливает силу гравитации
        rigidbody.gravityScale = scale;
    }
}
