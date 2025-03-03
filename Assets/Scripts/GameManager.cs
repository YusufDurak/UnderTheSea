using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject retryScreen; //  Assign in Inspector
    private bool gameOver = false;
    private int score = 0;
    public int scoreMultiplier = 1; // Puan çarpanı


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TriggerGameOver()
    {
        if (!gameOver)
        {
            gameOver = true;
            Time.timeScale = 0f; //  Stop the game
            if (retryScreen != null)
            {
                retryScreen.SetActive(true); //  Show retry screen
            }
        }
    }

    public void RetryGame()
    {
        Time.timeScale = 1f; //  Resume time
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //  Restart the scene
    }

    public void AddScore(int points)
    {
        score += points * scoreMultiplier; // Puan çarpanını uygula
        Debug.Log("Current Score: " + score);
        // Send the score to HighScoreManager to check for a new high score
        if (HighScoreManager.Instance != null)
        {
            HighScoreManager.Instance.UpdateScore(score);
        }
    }

    //  Getter method to access score
    public int GetScore()
    {
        return score;
    }




}
