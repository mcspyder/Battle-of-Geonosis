using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringController : MonoBehaviour
{
    public int multiplier = 10;
    public Text scoreText;
    public Text enemyDownText; 
    public int winScore = 5000;
    public GameObject winScreen;
    public void AddScore()
    {
        Scoring.totalScore += multiplier;
        if (scoreText != null)
        {
            scoreText.text = "SCORE: " + Scoring.totalScore.ToString("D5");
        }
        CheckForWin();
        // Show text
        StartCoroutine(ShowEnemyDownText());

    }

   private IEnumerator ShowEnemyDownText()
{
    if (enemyDownText != null)
    {
        enemyDownText.enabled = true; // Show text

        // Play the audio clip
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }

        yield return new WaitForSeconds(1.5f); // Wait for 1.5 seconds
        enemyDownText.enabled = false; // Hide text
    }
}

    public void CheckForWin()
{
    Debug.Log("Checking for win condition. Current Score: " + Scoring.totalScore);

    if (Scoring.totalScore >= winScore)
    {
        Time.timeScale = 0f; // Pause the game
        if (winScreen != null)
        {
            winScreen.SetActive(true); // Show the Win Screen
            Debug.Log("Win screen activated!");
        }
        else
        {
            Debug.LogError("Win screen is not assigned in the Inspector.");
        }
    }
}


}
