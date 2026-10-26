using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public TextMeshProUGUI healthText;
    public GameObject winScreenPanel;
    public GameObject lossScreenPanel;
    public PlayerHealth playerHealth;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if (winScreenPanel != null) winScreenPanel.SetActive(false);
        if (lossScreenPanel != null) lossScreenPanel.SetActive(false);
    }

    void OnEnable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged += UpdateHealthUI;
        }
    }

    void OnDisable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= UpdateHealthUI;
        }
    }

    private void UpdateHealthUI(int currentHealth)
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }
    }

    public void ShowWinScreen()
    {
        if (winScreenPanel != null)
        {
            winScreenPanel.SetActive(true);
        }
    }

    public void ShowGameOverScreen()
    {
        if (lossScreenPanel != null)
        {
            lossScreenPanel.SetActive(true);
        }
    }
}