using UnityEngine;

public class PowerUpDrop : MonoBehaviour
{
    public GameObject[] powerUpPrefabs; // Power-up prefabları
    public float dropChance = 0.2f; // %20 düşme şansı
    public float dropHeight = 2f; // Başlangıç yüksekliği
    public float dropOffset = 1f; // Yatay offset

    public void TryDropPowerUp()
    {
        if (Random.value <= dropChance)
        {
            // Rastgele bir power-up seç
            int randomIndex = Random.Range(0, powerUpPrefabs.Length);
            GameObject powerUpPrefab = powerUpPrefabs[randomIndex];

            // Gemi pozisyonundan biraz yukarıda ve rastgele bir yatay offset ile oluştur
            float randomX = Random.Range(-dropOffset, dropOffset);
            Vector3 dropPosition = transform.position + new Vector3(randomX, dropHeight, 0f);
            Instantiate(powerUpPrefab, dropPosition, Quaternion.identity);
        }
    }
} 