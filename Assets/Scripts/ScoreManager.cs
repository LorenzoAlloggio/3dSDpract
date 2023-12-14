using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Use TextMeshProUGUI for TextMeshPro
    private int score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
