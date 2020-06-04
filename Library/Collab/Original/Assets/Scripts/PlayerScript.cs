using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int nbJump = 0;
    
    public float speedwalk = 10;
    public float speedjump = 5;

    private Rigidbody2D rb;
    public GroundCheck groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speedwalk, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            rb.velocity = new Vector2(-speedwalk, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.Space) && groundCheck.grounded == true)
        {
            rb.AddForce(Vector2.up * speedjump, ForceMode2D.Impulse);
            nbJump++;
            if (nbJump == 2)
            {
                groundCheck.grounded = false;
                nbJump = 0;
            }
        }
    }
}