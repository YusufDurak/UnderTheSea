using System.Collections;
using UnityEngine;

public class MineMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float lifetime = 7.5f;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.linearVelocity = moveDirection * moveSpeed;
        StartCoroutine(DestroyAfterTime());
    }

    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction;
        rb.linearVelocity = moveDirection * moveSpeed;

        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("whale"))
        {
            Destroy(other.gameObject); // Destroy the whale
            GameManager.Instance.TriggerGameOver(); //  Notify GameManager
        }
    }
}
