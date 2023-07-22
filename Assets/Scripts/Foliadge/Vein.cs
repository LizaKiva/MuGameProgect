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
        // ������ ���������� ������
        Renderer.positionCount = JointCount;

        // �������� ������ �����
        origin = transform;

        // ������� ������� ������ ������� ������� �����
        jointLength = Length / JointCount;
        jointLengthSqr = jointLength * jointLength;

        // �������� ������� ���� ������
        for (int i = 0; i < JointCount; i++)
        {
            Renderer.SetPosition(i, origin.position);
        }
    }

    private void Update()
    {
        // ������ ������� ������ � ������
        Renderer.SetPosition(0, origin.position);

        for (int i = 1; i < JointCount; i++)
        {
            Vector3 previous_node = Renderer.GetPosition(i - 1);
            Vector3 node = Renderer.GetPosition(i);
            Vector3 delta = node - previous_node;

            // ��������� ������ ���� ������� �� ������, ��� ���
            if (delta.sqrMagnitude > jointLengthSqr + safeZone)
            {
                delta *= jointLength / delta.magnitude;
            }
            else
            {
                // �������� �������� ������� ��� ����� ����������
                delta += Vector3.down * jointLength;

                // ��������� �� ������������ ������� ������� �����
                if (delta.sqrMagnitude > jointLengthSqr)
                {
                    delta *= jointLength / delta.magnitude;
                }
            }

            // ��������� ������� �������
            Renderer.SetPosition(i, previous_node + delta);

            Debug.Log("set position of node " + i + ": " + (previous_node + delta));
        }
    }
}
