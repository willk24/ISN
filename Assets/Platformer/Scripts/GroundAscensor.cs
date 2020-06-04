using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundAscensor : MonoBehaviour

{
    public float speedfalling = 5;

    public float posYTop;
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
        {
            rb.velocity = new Vector2(rb.velocity.x, speedfalling);
        }
        else if(transform.position.y >= posYTop)
        {
            rb.velocity = new Vector2(rb.velocity.x, -speedfalling);
        }
    }
}
