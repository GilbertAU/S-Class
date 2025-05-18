using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float fireballSpeed;
    public float damage;
    public float graceDuration;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        rb.velocity = new Vector2(fireballSpeed, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<IDamageable>() == null)
        {
            return;
        }
        other.GetComponent<IDamageable>().Damage(damage);
        Destroy(gameObject);
    }
}