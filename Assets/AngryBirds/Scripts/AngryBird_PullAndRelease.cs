using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBird_PullAndRelease : MonoBehaviour
{
    // Force ajouté au gameobject
    public float force = 1300;

    // Gameobject pour la trajectoire
    public GameObject trajectoryPoint;
    private GameObject[] trajectoryPoints;
    public int numberOfPoints;

    // Position de départ du gameobject
    private Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;
        trajectoryPoints = new GameObject[numberOfPoints];
    }

    private void OnMouseUp()
    {
        // Désactiver la propriété Kinematic du gameobject
        GetComponent<Rigidbody2D>().isKinematic = false;

        // Ajouter la force
        Vector2 dir = startPos - (Vector2)transform.position;
        GetComponent<Rigidbody2D>().AddForce(dir * force);

        // Détruire les points de la trajectoire
        for (int i = 0; i < numberOfPoints; i++)
        {
            Destroy(trajectoryPoints[i]);
        }

        // Supprimer ce script du gameobject
        Destroy(this);
    }

    private void OnMouseDown()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            trajectoryPoints[i] = Instantiate(trajectoryPoint, gameObject.transform);
        }
    }

    private void OnMouseDrag()
    {
        // Convertir la position de la souris en une position utilisable
        Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Le garder dans un certain rayon
        float radius = 1.8f;
        Vector2 dir = p - startPos;
        if (dir.sqrMagnitude > radius)
            dir = dir.normalized * radius;

        // Assigner la position
        transform.position = startPos + dir;

        // Afficher la trajectoire
        for (int i = 0; i < numberOfPoints; i++)
        {
            trajectoryPoints[i].transform.position = calculatePosition(i * 0.1f);
        }
    }

    private Vector2 calculatePosition(float elapsedTime)
    {
        Vector2 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector2(endPos.x, endPos.y) +
            new Vector2(-(endPos - startPos).x * force / 100, -(endPos - startPos).y * force / 100) * elapsedTime +
            0.5f * Physics2D.gravity * elapsedTime * elapsedTime;
    }
}
