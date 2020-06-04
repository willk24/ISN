using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingTrap : MonoBehaviour
{
    private Rigidbody2D rb;
    public PlayerCheck playerCheck;
    public float speedrolling = 5;
    public GroundCheck groundCheck;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCheck = GetComponentInChildren<PlayerCheck>();
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    void Update()
    {
        if (playerCheck.falling == true)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.velocity = new Vector2(0, -speedrolling);

            if (groundCheck.grounded == true)
                rb.velocity = new Vector2(speedrolling, 0);

        }
    }
}