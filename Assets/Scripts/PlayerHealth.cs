using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour, IHittable
{
    public int maxHealth = 3;
    private int currentHealth;
    private bool isDead = false;

    public Action<int> OnHealthChanged;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Start()
    {
        OnHealthChanged?.Invoke(currentHealth);
    }

    public void OnHit()
    {
        if (isDead) return;

        currentHealth -= 1;
        OnHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            isDead = true;
            Die();
        }
    }

    private void Die()
    {
        GameManager.Instance.GameOver();
    }
}