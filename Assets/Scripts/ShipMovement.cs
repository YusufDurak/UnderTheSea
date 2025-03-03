using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private Vector2 moveDirection = Vector2.right;
    [SerializeField] private float moveSpeed = 5f;
    private float defaultSpeed;
    private Rigidbody2D rb;
    private bool isSlowed = false;
    private Animator animator;
    private bool isShaking = false;
    private PowerUpDrop powerUpDrop;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        powerUpDrop = GetComponent<PowerUpDrop>();
    }

    private void Start()
    {
        defaultSpeed = moveSpeed;
        animator = GetComponent<Animator>();
        rb.linearVelocity = moveDirection.normalized * moveSpeed;
    }

    public void SlowDownForOneSecond()
    {
        if (!isSlowed)
        {
            StartCoroutine(SlowDownTemporarily());
        }
    }

    private IEnumerator SlowDownTemporarily()
    {
        isSlowed = true;
        moveSpeed /= 2f;
        rb.linearVelocity = moveDirection.normalized * moveSpeed;

        yield return new WaitForSeconds(1f);

        moveSpeed = defaultSpeed;
        rb.linearVelocity = moveDirection.normalized * moveSpeed;
        isSlowed = false;
    }

    public void DestroyShip()
    {
        animator.SetBool("ShipAnim", true);
        
        // Power-up düşürme şansını kontrol et
        if (powerUpDrop != null)
        {
            powerUpDrop.TryDropPowerUp();
        }
        
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("destroy"))
        {
            DestroyShip();
        }
    }

    public void ShakeShip()
    {
        if (!isShaking)
        {
            StartCoroutine(ShakeCoroutine());
        }
    }

    private IEnumerator ShakeCoroutine()
    {
        isShaking = true;
        Vector3 originalPosition = transform.position;

        float shakeDuration = 0.5f;
        float elapsedTime = 0f;
        float shakeAmount = 0.1f;

        while (elapsedTime < shakeDuration)
        {
            float offsetX = Random.Range(-shakeAmount, shakeAmount);
            float offsetY = Random.Range(-shakeAmount, shakeAmount);
            transform.position = originalPosition + new Vector3(offsetX, offsetY, 0);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
        isShaking = false;
    }
}
