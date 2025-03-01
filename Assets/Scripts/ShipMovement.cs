using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private Vector2 moveDirection = Vector2.right; // Set direction in Inspector
    [SerializeField] private float moveSpeed = 5f;
    private float defaultSpeed; // Stores original speed
    private Rigidbody2D rb;
    private bool isSlowed = false; // Prevent multiple slowdowns

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        defaultSpeed = moveSpeed; // Store original speed
        rb.linearVelocity = moveDirection.normalized * moveSpeed; // Set velocity
    }

    public void SlowDownForOneSecond()
    {
        if (!isSlowed) // Prevent multiple slowdowns
        {
            StartCoroutine(SlowDownTemporarily());
        }
    }

    private IEnumerator SlowDownTemporarily()
    {
        isSlowed = true;
        moveSpeed /= 2f; // Reduce speed by half
        rb.linearVelocity = moveDirection.normalized * moveSpeed; // Apply new speed
        Debug.Log("Ship speed halved!");

        yield return new WaitForSeconds(1f); // Wait for 1 second

        moveSpeed = defaultSpeed; // Restore original speed
        rb.linearVelocity = moveDirection.normalized * moveSpeed; // Apply original speed
        isSlowed = false;
        Debug.Log("Ship speed restored!");
    }

    public void DestroyShip()
    {
        Debug.Log("Ship destroyed after 3 hits!");
        Destroy(gameObject);
    }
}
