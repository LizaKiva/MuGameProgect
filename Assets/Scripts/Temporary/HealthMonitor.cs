using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthMonitor : MonoBehaviour
{
    [SerializeField] HealthComponent healthComponent;

    private TextMeshProUGUI textField;

    private void Start()
    {
        healthComponent.healthNotifier += DisplayHealth;
        textField = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void DisplayHealth(int cuurentHaelth, int maxHealth)
    {
        textField.SetText("Health: " +  cuurentHaelth + '/' + maxHealth);
    }
}
