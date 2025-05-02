using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class ShootFireball_S : MonoBehaviour
{
    public GameObject fireballObject;
    public float fireballCooldown;
    private float currentCooldown;

    void Start()
    {
        currentCooldown = fireballCooldown;
    }

    void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(Keycode.E) && currentCooldown <= 0)
        {
            currentCooldown = fireballCooldown;
            Instantiate(fireballObject, transform.position, Quaternion.Euler(transform.rotation));
        }
    }
}