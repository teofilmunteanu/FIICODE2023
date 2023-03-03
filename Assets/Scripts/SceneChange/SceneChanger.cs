using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    //put script on door, and assign currentRoomDoorNr from editor
    [SerializeField]
    private int targetRoomNr;

    private SceneChangeManager _sceneChangeManager;

    private void Start()
    {
        _sceneChangeManager = SceneChangeManager.Instance;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            changeScene();
        }
    }

    public void changeScene()
    {
        if (_sceneChangeManager.CurrentSceneIndex == 0)
        {
            //_sceneChangeManager.CurrentSceneIndex = targetRoomNr;
            _sceneChangeManager.loadRoom(targetRoomNr);
        }
        else
        {
            //_sceneChangeManager.CurrentSceneIndex = 0;
            _sceneChangeManager.loadMainScene();
        }
    }
}
