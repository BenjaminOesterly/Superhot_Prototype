using UnityEngine;

public class EnemyTarget : MonoBehaviour, IHittable
{
    public void OnHit()
    {
        Destroy(gameObject);
    }
}