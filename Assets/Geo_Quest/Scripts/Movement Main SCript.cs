using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float dashSpeed = 10f;
    public float dashDuration = 0.5f;
    public float fireBlastCooldown = 2f;
    private float lastFireBlastTime = 0f;

    private Rigidbody2D rb;
    private bool isDashing = false;
    private float dashTime = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleMovement();
        HandleJump();
        HandleShoot();
        HandleDash();
        HandleFireBlast();
    }

    private void HandleMovement()
    {
        float moveDirection = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection = 1f;
        }

        if (!isDashing)
        {
            rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Mathf.Abs(rb.velocity.y) < 0.01f) // Check if grounded
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void HandleShoot()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        if (bulletPrefab && shootPoint)
        {
            Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        }
    }

    private void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    private System.Collections.IEnumerator Dash()
    {
        isDashing = true;
        float originalSpeed = moveSpeed;
        moveSpeed = dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        moveSpeed = originalSpeed;
        isDashing = false;
    }

    private void HandleFireBlast()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Time.time - lastFireBlastTime > fireBlastCooldown)
            {
                // LaunchFireBlast();
                lastFireBlastTime = Time.time;
            }
        }
    }
}

