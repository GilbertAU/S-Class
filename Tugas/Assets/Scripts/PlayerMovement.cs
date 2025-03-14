using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded;
    private bool canJump;

    [Header("Dash Settings")]
    public float dashSpeed = 15f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;

    private float currentDashCooldown = 0f;
    private bool isDashing = false;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private float lastMoveDirection = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        canJump = true;
    }

    private void Update()
    {
        Move();
        Jump();
        Dash();
    }

    private void Move()
    {
        if (isDashing) return;

        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput != 0)
        {
            lastMoveDirection = moveInput;
            sprite.flipX = moveInput < 0;
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            isGrounded = false;
            canJump = false;
        }
    }

    private void Dash()
    {
        if (currentDashCooldown > 0)
            currentDashCooldown -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && currentDashCooldown <= 0 && !isDashing)
        {
            StartCoroutine(DashCoroutine());
        }
    }

    private IEnumerator DashCoroutine()
    {
        isDashing = true;
        currentDashCooldown = dashCooldown;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0;

        rb.velocity = new Vector2(lastMoveDirection * dashSpeed, rb.velocity.y);

        yield return new WaitForSeconds(dashDuration);

        rb.gravityScale = originalGravity;
        isDashing = false;
    }
    public void SetGrounded(bool grounded)
    {
        isGrounded = grounded;

        if (grounded)
        {
            canJump = true;
        }
    }
}
