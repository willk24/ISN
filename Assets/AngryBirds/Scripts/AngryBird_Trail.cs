using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBird_Trail : MonoBehaviour
{
    // Trail Prefabs
    public GameObject[] trails;
    int next = 0;

    void Start()
    {
        // Spawn une nouvelle trainer toutes les 100 ms
        InvokeRepeating("spawnTrail", 0.1f, 0.1f);
    }

    void spawnTrail()
    {
        // Spawn spawn une trainer si il va assez vite
        if (GetComponent<Rigidbody2D>().velocity.sqrMagnitude > 25)
        {
            GameObject go = Instantiate(trails[next], transform.position, Quaternion.identity);
            Destroy(go, 10f);
            next = (next + 1) % trails.Length;
        }
    }
}
