using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveData : MonoBehaviour
{
    [SerializeField] public float GravityScale;          // Обычное притяжение
    [SerializeField] public float FallGravityMultiplier; // Коэфициент притяжения при падении вниз
    [SerializeField] public float JumpForce;             // Сила прыжка
    [SerializeField] public float Speed;                 // Скорость персонажа
}
