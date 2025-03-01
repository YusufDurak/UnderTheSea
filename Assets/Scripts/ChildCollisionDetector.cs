using UnityEngine;

public class ChildCollisionDetector : MonoBehaviour
{
    public static int hit = 0;
    private float lastCountTime = 0f;
    private bool isColliding = false; // Tracks if currently colliding
    [SerializeField] private float countingCooldown = 0.2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("whale") && !isColliding) // 
        {
            isColliding = true; // Collision started
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("whale") && isColliding && Time.time >= lastCountTime + countingCooldown)
        {    
            hit++; 
            Debug.Log("Exited collision with Whale. Total hits: " + hit);
            lastCountTime = Time.time;
        }

        
    }

    
}
