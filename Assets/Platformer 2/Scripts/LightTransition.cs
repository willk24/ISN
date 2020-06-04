using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightTransition : MonoBehaviour
{
    public Light2D globalLight;
    public GameObject lightPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        globalLight.intensity = 0.5f;
        lightPlayer.SetActive(true);
    }
}
