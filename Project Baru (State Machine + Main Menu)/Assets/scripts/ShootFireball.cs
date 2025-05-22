using UnityEngine;

public class ShootFireball : MonoBehaviour
{
    public GameObject fireballObject;
    public float fireballCooldown;
    public float fireballSpeed = 10f;

    private float currentCooldown;
    private PlayerMovement playerMovement;

    void Start()
    {
        currentCooldown = fireballCooldown;
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E) && currentCooldown <= 0)
        {
            currentCooldown = fireballCooldown;

            float direction = playerMovement.LastMoveDirection;
            Vector2 fireballDirection = new(direction, 0);

            GameObject fireball = Instantiate(fireballObject, transform.position, Quaternion.identity);
            fireball.GetComponent<Fireball>().Initialize(fireballDirection, fireballSpeed);
        }
    }
}
