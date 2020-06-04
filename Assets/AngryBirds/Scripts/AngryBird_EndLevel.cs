using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AngryBird_EndLevel : MonoBehaviour
{

    public string sceneName;
    public int bird;

    void Update()
    {
        if (bird == 5)
            LoadLevel();
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}
