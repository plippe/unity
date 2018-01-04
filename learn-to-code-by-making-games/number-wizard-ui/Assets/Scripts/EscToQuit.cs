using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscToQuit : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager sceneManager = GetComponent<SceneManager>();
            sceneManager.QuitGame();
        }

    }

}
