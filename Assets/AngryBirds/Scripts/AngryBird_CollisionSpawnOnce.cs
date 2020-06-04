using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBird_CollisionSpawnOnce : MonoBehaviour
{
    // Gameobject à être spawn
    public GameObject effect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Spawn l'effet
        GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(go, 2f);
        // Supprimer le script
        Destroy(gameObject);
    }
}
