using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    SceneChangeManager sceneChangeManager;
    private void Start()
    {
        Debug.Log("MainMenu");
        sceneChangeManager = SceneChangeManager.Instance;
    }

    public void NewGame()
    {
        SceneChangeManager.Instance.test();
        //reset everything
    }

    public void LoadGame()
    {
        sceneChangeManager.LoadMainScene();
        //get data from save file
        //load selected save file
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
