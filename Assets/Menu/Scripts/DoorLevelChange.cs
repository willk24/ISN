using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class DoorLevelChange : MonoBehaviour
{
    public string sceneName;
    public bool firstLevel;
    public bool secondLevel;
    public bool thirdLevel;
    public Color open;
    public Color close;

    public GameObject textGo;
    public Light2D light2D;
    public SpriteRenderer spriteRendererBackground;

    private bool go;
    private CoinsManager coinsManager;

    private void Start()
    {
        coinsManager = FindObjectOfType<CoinsManager>();
    }

    private void Update()
    {
        if (firstLevel)
        {
            light2D.color = open;
            spriteRendererBackground.color = open;
        }

        if (secondLevel && coinsManager.coin1 == true)
        {
            light2D.color = open;
            spriteRendererBackground.color = open;
        }
        else if (secondLevel && coinsManager.coin1 == false)
        {
            light2D.color = close;
            spriteRendererBackground.color = close;
        }

        if (thirdLevel && coinsManager.coin2 == true && coinsManager.coin3 == true)
        {
            light2D.color = open;
            spriteRendererBackground.color = open;
        }
        else if (thirdLevel && coinsManager.coin2 == false && coinsManager.coin3 == false)
        {
            light2D.color = close;
            spriteRendererBackground.color = close;
        }

        if (textGo.active)
        {
            if(firstLevel)
            {
                if (Input.GetKey(KeyCode.Return))
                {
                    LoadLevel();
                }
            }

            if(secondLevel && coinsManager.coin1 == true)
            {
                if (Input.GetKey(KeyCode.Return))
                {
                    LoadLevel();
                }
            }

            if (thirdLevel && coinsManager.coin2 == true && coinsManager.coin3 == true)
            {
                if (Input.GetKey(KeyCode.Return))
                {
                    LoadLevel();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        textGo.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textGo.SetActive(false);
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}
