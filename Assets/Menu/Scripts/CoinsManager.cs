using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public bool coin1;
    public bool coin2;
    public bool coin3;

    private void Awake()
    {
        CoinsManager[] instances = FindObjectsOfType<CoinsManager>();

        if(instances.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
