using UnityEngine;

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
            ChangeScene();
        }
    }

    public void ChangeScene()
    {
        if (_sceneChangeManager.CurrentSceneIndex == 0)
        {
            _sceneChangeManager.UpdateLastPlayerPosition();
            _sceneChangeManager.LoadRoom(targetRoomNr);
        }
        else
        {
            _sceneChangeManager.LoadMainScene();
        }
    }
}
