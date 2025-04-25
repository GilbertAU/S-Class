using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float fireballSpeed;
    public float damage;
    public float graceDuration;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
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
        rb.velocity = Vector3.forward * fireballSpeed;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        /*kalo musuh kena
        if (other.compareTag("Enemy")
        {
        other.GetComponent<IDamageable>().TakeDamage(damage);
        Destroy(gameObject);
        }
        if (other.compareTag("Wall")
        {
        Destroy(gameObject);
        }
        */
    }
}
