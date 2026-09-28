using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Transform player;

    private float shootTimer = 2f;

    void Start()
    {
        PlayerController foundPlayer = GameObject.FindFirstObjectByType<PlayerController>();
        if (foundPlayer != null)
        {
            player = foundPlayer.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        transform.LookAt(player);
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0f)
        {
            shootTimer = 2f;

            Vector3 spawnPos = transform.position + (transform.forward * 1.5f) + (Vector3.up * 0.5f);

            Instantiate(bulletPrefab, spawnPos, transform.rotation);
        }
    }
}