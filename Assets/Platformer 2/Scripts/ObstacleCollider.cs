using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollider : MonoBehaviour
{
    public Transform[] respawnPoint;
    public int respawnPointSeletect;

    private MovingPlatform[] movingPlatforms;

    private void Awake()
    {
        movingPlatforms = FindObjectsOfType<MovingPlatform>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            foreach (var platform in movingPlatforms)
            {
                platform.ResetPosition();
            }
            collision.gameObject.transform.position = respawnPoint[respawnPointSeletect - 1].position;
        }
    }
}
