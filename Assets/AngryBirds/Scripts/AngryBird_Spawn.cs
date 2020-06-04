using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBird_Spawn : MonoBehaviour
{
    public GameObject bird;

    private bool occupied = false;

    private void FixedUpdate()
    {
        if (!occupied && !sceneIsMoving())
            SpawnBird();
    }

    private void SpawnBird()
    {
        Instantiate(bird, transform.position, Quaternion.identity);
        occupied = true;
    }

    bool sceneIsMoving()
    {
        //On cherche tous les Rigidbody2D de la scene pour vérifier si il y en a qui sont entrains de bouger
        Rigidbody2D[] bodies = FindObjectsOfType(typeof(Rigidbody2D)) as Rigidbody2D[];
        foreach (Rigidbody2D rb in bodies)
            if (rb.velocity.sqrMagnitude > 5)
                return true;
        return false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        occupied = false;
    }
}
