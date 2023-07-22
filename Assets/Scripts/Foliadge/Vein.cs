using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Vein : MonoBehaviour
{
    [SerializeField] LineRenderer Renderer;
    [SerializeField] float Gravitation;
    [SerializeField] float Length;
    [SerializeField] int JointCount;

    float jointLength;
    float jointLengthSqr;
    Transform origin;
    float safeZone = 0.05F;

    void Start()
    {
        // Задаем количество вершин
        Renderer.positionCount = JointCount;

        // Получаем начало лианы
        origin = transform;

        // Считаем квадрат длинны каждого кусочка лианы
        jointLength = Length / JointCount;
        jointLengthSqr = jointLength * jointLength;

        // Зануляем позиции всех вершин
        for (int i = 0; i < JointCount; i++)
        {
            Renderer.SetPosition(i, origin.position);
        }
    }

    private void Update()
    {
        // Первая вершина всегда в начале
        Renderer.SetPosition(0, origin.position);

        for (int i = 1; i < JointCount; i++)
        {
            Vector3 previous_node = Renderer.GetPosition(i - 1);
            Vector3 node = Renderer.GetPosition(i);
            Vector3 delta = node - previous_node;

            // Проверяем далеко наша вершина от предка, или нет
            if (delta.sqrMagnitude > jointLengthSqr + safeZone)
            {
                delta *= jointLength / delta.magnitude;
            }
            else
            {
                // Пытаемся опустить вершину под силой гравитации
                delta += Vector3.down * jointLength;

                // Проверяем не опустилались вершина слижком низко
                if (delta.sqrMagnitude > jointLengthSqr)
                {
                    delta *= jointLength / delta.magnitude;
                }
            }

            // Обновляем позицию вершины
            Renderer.SetPosition(i, previous_node + delta);

            Debug.Log("set position of node " + i + ": " + (previous_node + delta));
        }
    }
}
