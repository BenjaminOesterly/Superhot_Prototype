using UnityEngine;

public class Enemy : MonoBehaviour, IHittable
{
    public int health = 3;

    public void OnHit()
    {
        health -= 1;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnEnemyDefeated();
        }

        Destroy(gameObject);
    }
}