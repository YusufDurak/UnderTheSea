using UnityEngine;
using System.Collections;

public class MineMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float lifetime = 7.5f; // Time before mine disappears
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.linearVelocity = moveDirection * moveSpeed;
        StartCoroutine(DestroyAfterTime()); // Start countdown to disappear
    }

    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction;
        rb.linearVelocity = moveDirection * moveSpeed;

        // Flip sprite if moving left
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Flip horizontally
        }
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("whale")) // If the whale touches the mine
        {
            Destroy(other.gameObject); // Destroy the whale
            Debug.Log("The whale hit a mine and perished!");
        }
    }
}
