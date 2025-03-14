using System.Collections;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f; // Kecepatan normal pemain

    [Header("Dash Settings")]
    public float dashSpeed = 15f; // Kecepatan dash
    public float dashDuration = 0.2f; // Lama dash
    public float dashCooldown = 1f; // Cooldown antara dash

    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private Vector2 moveDirection;
    private bool isDashing = false;
    private bool canDash = true;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isDashing) return; // Tidak bisa mengontrol saat dash

        // Ambil input arah
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(horizontal, vertical).normalized;

        // Flip sprite berdasarkan arah gerakan
        if (horizontal > 0) sprite.flipX = false;
        if (horizontal < 0) sprite.flipX = true;

        // Dash ketika menekan Shift dan cooldown selesai
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && moveDirection != Vector2.zero)
        {
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            body.velocity = moveDirection * speed; // Gerakan normal
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        body.velocity = moveDirection * dashSpeed; // Tambah kecepatan dash

        yield return new WaitForSeconds(dashDuration);

        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true; // Aktifkan kembali dash setelah cooldown
    }
}
