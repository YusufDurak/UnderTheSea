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


    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
       // Debug.Log("Ship speed halved!");

        yield return new WaitForSeconds(1f);

        moveSpeed = defaultSpeed;
        rb.linearVelocity = moveDirection.normalized * moveSpeed;
        isSlowed = false;
       // Debug.Log("Ship speed restored!");
    }

    public void DestroyShip()
    {
        //Debug.Log("Ship destroyed after 3 hits!");

        animator.SetBool("ShipAnim", true);

        Destroy(gameObject, 0.5f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("destroy"))
        {
            DestroyShip(); // Destroy ship if it touches a GameObject tagged "destroy"
        }
    }
}
