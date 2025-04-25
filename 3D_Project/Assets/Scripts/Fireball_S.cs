using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject fireballObject;
    public float fireballCooldown;
    private float currentCooldown;
    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = fireballCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (Input.GetKey(KeyCode.E) && currentCooldown <= 0)
        {
            currentCooldown = fireballCooldown;
            Instantiate(fireballObject, transform.position, Quaternion.Euler(transform.rotation));
        }
    }
}
