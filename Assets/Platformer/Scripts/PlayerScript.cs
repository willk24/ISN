using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] int gravityScale = 1;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float jumpVelocity = 50f;
    [SerializeField] float midAirControl = 3f;
    [SerializeField] private LayerMask platfromsLayerMask;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2d;

    public bool canUseLader = false;

    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }

        if (canUseLader)
            HandleLadderMovement();

        HandleMovement();
    }

    private bool IsGrounded()
    {
        float extraHeightText = 1f;
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, extraHeightText, platfromsLayerMask);
        Color rayColor;
        if (raycastHit2d.collider != null)
            rayColor = Color.green;
        else
            rayColor = Color.red;

        Debug.DrawRay(boxCollider2d.bounds.center + new Vector3(boxCollider2d.bounds.extents.x, 0), Vector2.down * (boxCollider2d.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(boxCollider2d.bounds.center - new Vector3(boxCollider2d.bounds.extents.x, 0), Vector2.down * (boxCollider2d.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(boxCollider2d.bounds.center - new Vector3(boxCollider2d.bounds.extents.x, boxCollider2d.bounds.extents.y + extraHeightText), Vector2.right * (boxCollider2d.bounds.extents.x), rayColor);

        return raycastHit2d.collider != null;
    }

    private void HandleMovement()
    {
        rb.gravityScale = gravityScale;

        if (Input.GetKey(KeyCode.Q))
        {
            if(IsGrounded())
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            else if(canUseLader)
                rb.velocity = new Vector2(-4, rb.velocity.y);
            else
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (IsGrounded())
                    rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
                else if (canUseLader)
                    rb.velocity = new Vector2(4, rb.velocity.y);
                else
                    rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
            }
            else
            {
                if(IsGrounded())
                    rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }

    private void HandleLadderMovement()
    {
        rb.gravityScale = 0;
        if (Input.GetKey(KeyCode.Z))
            rb.velocity = new Vector2(rb.velocity.x, 8);
        else if (Input.GetKey(KeyCode.S))
            rb.velocity = new Vector2(rb.velocity.x, -8);
        else
            rb.velocity = new Vector2(0, 0);
    }

}