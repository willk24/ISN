using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBirds_BreakOnImpact : MonoBehaviour
{
    public float forceNeeded = 700;
    public bool isBird;

    float collisionForce(Collision2D collision)
    {
        // Estimer la force
        float speed = collision.relativeVelocity.sqrMagnitude;
        if (collision.collider.GetComponent<Rigidbody2D>())
            return speed * collision.collider.GetComponent<Rigidbody2D>().mass;
        return speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collisionForce(collision) >= forceNeeded)
        {
            if(isBird)
                FindObjectOfType<AngryBird_EndLevel>().bird++;
            Destroy(gameObject);
        }
    }
}
