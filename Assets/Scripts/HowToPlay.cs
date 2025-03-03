using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HowToPlay : MonoBehaviour
{
    public GameObject howToPlayPanel;
    public Button closeButton;
    public TextMeshProUGUI instructionsText;

    private void Start()
    {
        // Panel başlangıçta açık olsun
        if (howToPlayPanel != null)
        {
            howToPlayPanel.SetActive(true);
            Time.timeScale = 0f; // Oyunu duraklat
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
                                  "• Ok tuşları ile balinanızı kontrol edin\n" +
                                  "• Mayınlardan kaçının\n" +
                                  "• Gemileri yok ederek puan kazanın\n" +
                                  "• Gemiler bazen power-up düşürür (%20 şans)\n\n" +
                                  "POWER-UP'LAR:\n" +
                                  "• Kalkan: Tek seferlik mayın koruması sağlar\n" +
                                  "• 2X Skor: Geçici olarak puanlarınızı iki katına çıkarır\n" +
                                  "• Rage: 10 saniye boyunca mayınlardan etkilenmezsiniz\n\n" +
                                  "İYİ OYUNLAR!";
        }
    }

    public void CloseHowToPlay()
    {
        if (howToPlayPanel != null)
        {
            howToPlayPanel.SetActive(false);
            Time.timeScale = 1f; // Oyunu devam ettir
        }
    }
} 