using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject howToPlayPanel; // Nasıl oynanır paneli
    public Button closeButton; // Kapatma butonu
    public TextMeshProUGUI instructionsText; // Talimatlar metni

    private void Start()
    {
        // Panel başlangıçta kapalı olsun
        if (howToPlayPanel != null)
        {
            howToPlayPanel.SetActive(false);
        }

        // Kapatma butonuna tıklama olayını ekle
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CloseHowToPlay);
        }

        // Talimatları ayarla
        if (instructionsText != null)
        {
            instructionsText.text = "NASIL OYNANIR?\n\n" +
                                  "• Ok tuşları ile geminizi kontrol edin\n" +
                                  "• Mayınlardan kaçının\n" +
                                  "• Power-up'ları toplayarak avantaj elde edin\n" +
                                  "• Mümkün olduğunca yüksek skor elde edin\n\n" +
                                  "POWER-UP'LAR:\n" +
                                  "• Kalkan: Geçici koruma sağlar\n" +
                                  "• Hız Artırımı: Geminizi hızlandırır\n" +
                                  "• Çift Puan: Puanlarınızı iki katına çıkarır\n" +
                                  "• Yenilmezlik: Geçici olarak hasar almazsınız";
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowHowToPlay()
    {
        if (howToPlayPanel != null)
        {
            howToPlayPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void CloseHowToPlay()
    {
        if (howToPlayPanel != null)
        {
            howToPlayPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}