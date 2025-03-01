using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject retryScreen; //  Assign in Inspector
    private bool gameOver = false;
    private int score = 0;


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
        score += points;
        Debug.Log("Score: " + score);
    }

    //  Getter method to access score
    public int GetScore()
    {
        return score;
    }




}
