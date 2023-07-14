using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingRenderer : MonoBehaviour
{
    [SerializeField] LineRenderer Renderer;
    [SerializeField] float Radius;
    [SerializeField] int Angles;
    [SerializeField] Transform centre;

    // Start is called before the first frame update
    void Start()
    {
        DrawCircle();
    }
    void FixedUpdate()
    {
        DrawCircle();
    }

    void DrawCircle()
    {
        Renderer.positionCount = Angles;

        for (int step = 0; step < Angles; ++step)
        {
            float circleProgress = (float)step / Angles;
            float angleRadian = circleProgress * 2 * Mathf.PI;

            float x = Mathf.Cos(angleRadian) * Radius;
            float y = Mathf.Sin(angleRadian) * Radius;

            Renderer.SetPosition(step, new Vector3(x, y, 0) + centre.transform.position);
        }
    }
}
