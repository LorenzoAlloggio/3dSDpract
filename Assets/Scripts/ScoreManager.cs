using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Use TextMeshProUGUI for TextMeshPro
    private int enemiesKilled = 0;

    void Start()
    {
        UpdateScoreText();
    }

    public void IncreaseEnemiesKilled()
    {
        enemiesKilled++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + enemiesKilled;
    }
}
