using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject player;
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    private int totalEnemies;
    private int enemiesDefeated = 0;
    private bool isLevelComplete = false;
    private bool isGameOver = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        Time.timeScale = 1f;
    }

    void Start()
    {
        SpawnEnemies();
    }

    void Update()
    {
        if (isLevelComplete || isGameOver)
        {
            if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void SpawnEnemies()
    {
        totalEnemies = Mathf.Min(5, spawnPoints.Length);

        for (int i = 0; i < totalEnemies; i++)
        {
            Instantiate(enemyPrefab, spawnPoints[i].position, spawnPoints[i].rotation);
        }
    }

    public void OnEnemyDefeated()
    {
        enemiesDefeated++;
        if (enemiesDefeated >= totalEnemies)
        {
            WinLevel();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        DisablePlayer();
        UIManager.Instance.ShowGameOverScreen();
    }

    private void WinLevel()
    {
        isLevelComplete = true;
        Time.timeScale = 0f;
        DisablePlayer();
        UIManager.Instance.ShowWinScreen();
    }

    private void DisablePlayer()
    {
        if (player != null)
        {
            PlayerController pc = player.GetComponent<PlayerController>();
            if (pc != null) pc.enabled = false;

            PlayerInput pi = player.GetComponent<PlayerInput>();
            if (pi != null) pi.enabled = false;
        }
    }
}