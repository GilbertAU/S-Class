using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float damage;
    public float graceDuration;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(Vector2 direction, float speed)
    {
        moveDirection = direction.normalized * speed;
    }

    void Update()
    {
        graceDuration -= Time.deltaTime;
        if (graceDuration <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveDirection;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy"))
        {
            return;
        }

        if (other.GetComponent<IDamageable>() == null)
        {
            return;
        }
        other.GetComponent<IDamageable>().Damage(damage);
        Destroy(gameObject);
    }
}
