using UnityEngine;
using TMPro; // Required for TextMeshPro interaction

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to your TextMeshProUGUI element for the score
    public TextMeshProUGUI winText;   // Reference to a TextMeshProUGUI element to display "You Won"
    private int currentScore = 0;

    private void Start()
    {
        // Ensure the references are set in the Inspector
        if (scoreText == null || winText == null)
        {
            Debug.LogError("Score Text or Win Text (TextMeshProUGUI) not assigned in the Inspector!");
        }
        else
        {
            UpdateScoreText();
            winText.gameObject.SetActive(false); // Initially hide the "You Won" text
        }
    }

    public void IncreaseScore(int points)
    {
        currentScore += points;
        UpdateScoreText();

        if (currentScore >= 70) 
        {
            WinGame();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentScore;
    }

    private void WinGame()
    {
        winText.gameObject.SetActive(true); 
        
    }
}