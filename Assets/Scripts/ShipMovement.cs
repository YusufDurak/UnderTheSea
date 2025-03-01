using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private Vector2 moveDirection = Vector2.right; // Set direction in Inspector
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.linearVelocity = moveDirection.normalized * moveSpeed; // Set velocity once
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("destroy")) 
        {
            Destroy(gameObject);
        }
    }


}
