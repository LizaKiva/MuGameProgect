using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] int MaxHealth; // ������������ ��������
    
    int currentHealth; // ������� ��������

    public delegate void healthUpdate(int new_health, int new_max_health);
    public event healthUpdate healthNotifier;

    private void Start()
    {
        currentHealth = MaxHealth;
    }

    public void SetMaxHealth(int newMaxHealth)
    {
        // ���������, ��� ���-�� ���������
        if (MaxHealth != newMaxHealth)
        {
            MaxHealth = newMaxHealth;
            if (currentHealth > MaxHealth)
            {
                currentHealth = MaxHealth;
            }
            healthNotifier?.Invoke(currentHealth, MaxHealth);
        }
    }

    public void Heal(int heal_amount)
    {
        // ���������, ��� ���-�� ���������
        if (currentHealth < MaxHealth && heal_amount != 0)
        {
            currentHealth += heal_amount;
            if (currentHealth > MaxHealth)
            {
                currentHealth = MaxHealth;
            }
            healthNotifier?.Invoke(currentHealth, MaxHealth);
        }
    }

    public void Damage(int damage)
    {
        // ���������, ��� ���-�� ���������
        if (damage != 0)
        {
            currentHealth -= damage;
            healthNotifier?.Invoke(currentHealth, MaxHealth);
            if (currentHealth < 0)
            {
                Died();
            }
        }
    }

    public int GetCurrentHeath()
    {
        return currentHealth;
    }

    public int GetMaxHeath()
    {
        return MaxHealth;
    }

    public void Died()
    {
        Destroy(gameObject);
    }
}
