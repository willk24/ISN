using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [Header("Layers")]
    public LayerMask groundLayer;

    [Space]

    public bool onGround;
    public bool onWall;
    public bool onRightWall;
    public bool onLeftWall;
    public int wallSide;

    [Space]

    [Header("Collision")]

    public Vector2 collisionSizeBottom;
    public Vector2 collisionSizeLeft;
    public Vector2 collisionSizeRight;
    public Vector2 bottomOffset, rightOffset, leftOffset;
    private Color debugCollisionColor = Color.red;

    void Update()
    {
        onGround = Physics2D.OverlapBox((Vector2)transform.position + bottomOffset, collisionSizeBottom, 0, groundLayer);
        onWall = Physics2D.OverlapBox((Vector2)transform.position + rightOffset, collisionSizeRight, 0, groundLayer)
            || Physics2D.OverlapBox((Vector2)transform.position + leftOffset, collisionSizeLeft, 0, groundLayer);

        onRightWall = Physics2D.OverlapBox((Vector2)transform.position + rightOffset, collisionSizeRight, 0, groundLayer);
        onLeftWall = Physics2D.OverlapBox((Vector2)transform.position + leftOffset, collisionSizeLeft, 0, groundLayer);

        wallSide = onRightWall ? -1 : 1;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { bottomOffset, rightOffset, leftOffset };

        Gizmos.DrawWireCube((Vector2)transform.position + bottomOffset, collisionSizeBottom);
        Gizmos.DrawWireCube((Vector2)transform.position + rightOffset, collisionSizeRight);
        Gizmos.DrawWireCube((Vector2)transform.position + leftOffset, collisionSizeLeft);
    }
}
