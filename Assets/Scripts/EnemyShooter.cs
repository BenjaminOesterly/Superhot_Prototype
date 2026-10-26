using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;

    private Transform playerTransform;
    private float nextFireTime;

    void Start()
    {
        if (GameManager.Instance != null && GameManager.Instance.player != null)
        {
            playerTransform = GameManager.Instance.player.transform;
        }
        nextFireTime = Time.time + fireRate;
    }

    void Update()
    {
        if (playerTransform != null)
        {
            transform.LookAt(playerTransform);

            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}