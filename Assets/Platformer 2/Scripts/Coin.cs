using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CoinsManager coinsManager = FindObjectOfType<CoinsManager>();

        if (coinIndex == 1)
            coinsManager.coin1 = true;
        else if (coinIndex == 2)
            coinsManager.coin2 = true;
        else if (coinIndex == 3)
            coinsManager.coin3 = true;

        Destroy(this.gameObject);
    }
}
