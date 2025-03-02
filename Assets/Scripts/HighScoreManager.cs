using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance { get; private set; }
    public int highScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across levels
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate instances
            return;
        }
    }

    public void UpdateScore(int newScore)
    {
        if (newScore > highScore)
        {
            highScore = newScore;
            Debug.Log("New High Score: " + highScore);
        }
    }


    public int getHigh()
    {
        return highScore;
    }
}
