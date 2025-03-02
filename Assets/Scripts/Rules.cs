using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Rules : MonoBehaviour
{
    public TextMeshProUGUI count;

    public TextMeshProUGUI Highest;

    void Update()
    {
        count.text = "SCORE: " + GameManager.Instance.GetScore();

        Highest.text = "HIGHEST: " + HighScoreManager.Instance.getHigh();

    }
}
