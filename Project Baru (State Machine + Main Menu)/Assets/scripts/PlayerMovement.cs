using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded;

    [Header("Dash Settings")]
    public float dashSpeed = 15f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;

    private float currentDashCooldown = 0f;
    private bool isDashing = false;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private float lastMoveDirection = 1;
    public float LastMoveDirection => lastMoveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isDashing) return;

        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput != 0)
        {
            lastMoveDirection = moveInput;
            sprite.flipX = moveInput < 0;
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        Jump();
        Dash();
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
    }

    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            isGrounded = false;
            animator.SetBool("IsJumping", true);
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
            animator.SetBool("IsJumping", false);
        }
    }
}
