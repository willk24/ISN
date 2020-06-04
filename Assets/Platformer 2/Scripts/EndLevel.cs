using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{

    public string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LoadLevel();
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}
