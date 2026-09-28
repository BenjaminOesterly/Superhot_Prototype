using UnityEngine;

public class SlowBullet : MonoBehaviour
{
    public float bulletSpeed = 10f;

    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IHittable>(out var target))
        {
            target.OnHit();
        }

        Destroy(gameObject);
    }
}