using UnityEngine;

public class SlowBullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    private bool hasHit = false;

    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (hasHit) return;

        if (other.TryGetComponent<IHittable>(out var target))
        {
            target.OnHit();
            hasHit = true;
        }

        Destroy(gameObject);
    }
}