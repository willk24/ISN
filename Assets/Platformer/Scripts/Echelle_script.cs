using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echelle_script : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Activer la possibilité de monter à une echelle pour le joueur dans le script "PlayerScript"
        collision.gameObject.GetComponent<PlayerScript>().canUseLader = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<PlayerScript>().canUseLader = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Désactiver cette possibilité 
        collision.gameObject.GetComponent<PlayerScript>().canUseLader = false;
    }
}
 