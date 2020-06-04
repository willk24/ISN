using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFalling : MonoBehaviour

{
    public float speedfalling = 2;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, -speedfalling);
        if (transform.position.y <= -20)
        {
            rb.velocity = new Vector2(rb.velocity.x, speedfalling);
        }
        else
        {}
    }
}
