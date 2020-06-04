using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFalling : MonoBehaviour
{
    public float speedfalling = 1;
    public float posYDown;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, -speedfalling);
    }

    void Update()
    {
        if (transform.position.y <= posYDown)
            transform.position = transform.position + new Vector3(0, 10, 0);
    }
}
