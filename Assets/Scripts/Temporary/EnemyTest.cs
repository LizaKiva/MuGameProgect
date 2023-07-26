using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    HealthComponent healthComponent;

    private void Start()
    {
        healthComponent = gameObject.GetComponent<HealthComponent>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            healthComponent.Damage(5);
        }
    }
}
