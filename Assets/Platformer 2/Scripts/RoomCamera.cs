using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCamera : MonoBehaviour
{
    public GameObject virtualCamera;
    public ObstacleCollider obstacleCollider;
    public int roomNumber;

    private void Start()
    {
        obstacleCollider = FindObjectOfType<ObstacleCollider>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            virtualCamera.SetActive(true);
            obstacleCollider.respawnPointSeletect = roomNumber;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            virtualCamera.SetActive(false);
        }
    }
}
