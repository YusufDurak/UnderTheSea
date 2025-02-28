using UnityEngine;

public class WhaleMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
     public float directionChangeCooldown = 0.5f; // Cooldown time in seconds

    private Rigidbody2D rb;
    private float directionX = 1f; // 1 = Right, -1 = Left
    private float verticalInput = 0f;
    private float lastDirectionChangeTime = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleInput();
        Debug.Log(directionChangeCooldown);
    }

    private void FixedUpdate()
    {
        Vector2 moveDirection = new Vector2(directionX, verticalInput).normalized;
        rb.linearVelocity = moveDirection * moveSpeed; // Apply movement
    }

    private void HandleInput()
    {
        verticalInput = 0f;

        if (Input.GetKey(KeyCode.W)) verticalInput = 1f; // Move diagonally up
        if (Input.GetKey(KeyCode.S)) verticalInput = -1f; // Move diagonally down

        if (Time.time >= lastDirectionChangeTime + directionChangeCooldown)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                directionX = -1f; // Flip left
                lastDirectionChangeTime = Time.time;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                directionX = 1f;  // Flip right
                lastDirectionChangeTime = Time.time;
            }
        }
    }
}

