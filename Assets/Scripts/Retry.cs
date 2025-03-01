using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void TryAgain()
    {
        SceneManager.LoadSceneAsync(1);

        Time.timeScale = 1f;
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }


}
