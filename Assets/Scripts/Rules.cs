using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Rules : MonoBehaviour
{
    public TextMeshProUGUI count;

    void Update()
    {
        count.text = "SCORE: " + GameManager.Instance.GetScore(); 
    }
}
