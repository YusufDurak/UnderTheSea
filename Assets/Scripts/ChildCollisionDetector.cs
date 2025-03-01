using UnityEngine;

public class ChildCollisionDetector : MonoBehaviour
{
    private ShipMovement parentShip;
    [SerializeField] public int hitCount = 0;
    [SerializeField] private int maxHits = 3;
    [SerializeField] private float countingCooldown = 0.2f;
    private float lastCountTime = 0f;

    private void Awake()
    {
        parentShip = GetComponentInParent<ShipMovement>(); // Find the parent ship
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("whale") && parentShip != null && Time.time >= lastCountTime + countingCooldown)
        {
            lastCountTime = Time.time;
            hitCount++;
            parentShip.SlowDownForOneSecond();
           // Debug.Log("Whale hit ship collider. Hits: " + hitCount);

            if (hitCount >= maxHits)
            {
                GameManager.Instance.AddScore(10); // Add 10 points when ship is destroyed
                parentShip.DestroyShip(); // Destroy the ship
            }
        }
    }
}
