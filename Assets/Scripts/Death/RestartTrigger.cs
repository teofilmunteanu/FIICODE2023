using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartTrigger : MonoBehaviour
{
    private Scene scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Application.LoadLevel(scene.name);
    }
}
