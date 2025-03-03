using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType
    {
        Shield,     // Tek seferlik mayın koruması
        DoubleScore, // 2x skor
        Rage        // 10 saniyelik yenilmezlik
    }

    public PowerUpType type;
    public float duration = 10f; // Rage için süre
    public float fallSpeed = 2f; // Aşağı düşme hızı
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // Aşağı doğru yavaşça düşme
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Balina veya oyuncu power-up'ı toplayabilir
        if (other.CompareTag("whale") || other.CompareTag("Player"))
        {
            ApplyPowerUp(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void ApplyPowerUp(GameObject collector)
    {
        PowerUpEffect powerUpEffect = collector.GetComponent<PowerUpEffect>();
        if (powerUpEffect == null)
        {
            powerUpEffect = collector.AddComponent<PowerUpEffect>();
        }

        switch (type)
        {
            case PowerUpType.Shield:
                powerUpEffect.StartShieldEffect();
                break;
            case PowerUpType.DoubleScore:
                powerUpEffect.StartDoubleScoreEffect(duration);
                break;
            case PowerUpType.Rage:
                powerUpEffect.StartRageEffect(duration);
                break;
        }
    }
} 