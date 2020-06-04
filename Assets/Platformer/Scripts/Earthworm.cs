using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthworm : MonoBehaviour
{
    public float speedTop = 25f;
    public float speedDown = 5f;

    public float posYTop = -24.32f;
    public float posYDown = -35.45f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, speedTop);
    }

    void Update()
    {
        if (transform.position.y <= posYDown)
        {
            rb.velocity = new Vector2(rb.velocity.x, speedTop);
        }
        else if (transform.position.y >= posYTop)
        {
            rb.velocity = new Vector2(rb.velocity.x, -speedDown);
        }
    }
}
