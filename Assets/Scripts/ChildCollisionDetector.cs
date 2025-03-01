using UnityEngine;

public class ChildCollisionDetector : MonoBehaviour
{
    private ShipMovement parentShip; // Reference to the ship this collider belongs to
    private int hitCount = 0; // Tracks the number of whale hits
    [SerializeField] private int maxHits = 3; // Number of hits before destruction
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
            hitCount++; // Increase the hit count
            parentShip.SlowDownForOneSecond(); // Slow down the ship for 1 second
            Debug.Log("Whale hit ship collider. Hits: " + hitCount);

            if (hitCount >= maxHits)
            {
                parentShip.DestroyShip(); // Destroy the ship after 3 hits
            }
        }
    }
}
