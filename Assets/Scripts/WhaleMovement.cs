using UnityEngine;

public class WhaleMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    public float directionChangeCooldown = 0.5f;

    private Rigidbody2D rb;
    private float directionX = 1f; // 1 = Right, -1 = Left
    private float verticalInput = 0f;
    private float lastDirectionChangeTime = 0f;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get SpriteRenderer
    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        Vector2 moveDirection = new Vector2(directionX, verticalInput).normalized;
        rb.linearVelocity = moveDirection * moveSpeed;
    }

    private void HandleInput()
    {
        verticalInput = 0f;

        if (Input.GetKey(KeyCode.W)) verticalInput = 1f;
        if (Input.GetKey(KeyCode.S)) verticalInput = -1f;

        if (Time.time >= lastDirectionChangeTime + directionChangeCooldown)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                directionX = -1f;
                lastDirectionChangeTime = Time.time;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                directionX = 1f;
                lastDirectionChangeTime = Time.time;
            }
        }

        //  Flip sprite if moving left
        spriteRenderer.flipX = (directionX > 0);
    }
}
