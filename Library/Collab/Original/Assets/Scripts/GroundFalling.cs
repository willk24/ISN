using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFalling : MonoBehaviour

{
    public float speedfalling = 2;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, -speedfalling);

        if (transform.position.y <= -20)
        {
            rb.velocity = new Vector2(rb.velocity.x, speedfalling);
        }
        else
        {

        }
    }
}
