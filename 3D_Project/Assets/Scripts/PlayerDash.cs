using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : Player
{
    public float dashDistance;
    public float dashCooldown;
    private Rigidbody rb;
    private float currentDashCooldown;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentDashCooldown = dashCooldown;
    }

    // Update is called once per frame
    private void Update()
    {
        currentDashCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) && currentDashCooldown <= 0)
        {
            rb.AddForce(GetComponent<playerMoves>().moveDirection * dashDistance, ForceMode.Impulse);
            currentDashCooldown = dashCooldown;
        }
    }
}
