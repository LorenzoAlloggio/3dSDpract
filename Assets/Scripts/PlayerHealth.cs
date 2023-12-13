using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public TextMeshProUGUI healthText; // Reference to the UI text element

    void Start()
    {
        currentHealth = maxHealth;

        // Find the Text component if not set in the Inspector
        if (healthText == null)
        {
            healthText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();
        }

        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Taking damage: " + damage);
        currentHealth -= damage;
        UpdateHealthUI();

        // Check if the player is dead
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // You can replace "YourNextSceneName" with the name of the scene you want to load.
        SceneManager.LoadScene("1_Main_Menu");
    }
}
