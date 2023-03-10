using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    //put script on door, and assign currentRoomDoorNr from editor
    [SerializeField]
    private int targetRoomNr;

    private SceneChangeManager sceneChangeManager;

    private void Start()
    {
        sceneChangeManager = SceneChangeManager.Instance;
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
        if (sceneChangeManager.CurrentSceneIndex == 0)
        {
            Vector3 doorPos = this.transform.position;
            Vector3 offset = new Vector3(0, 0, -2);
            sceneChangeManager.UpdateLastPlayerPosition(doorPos + offset);
            sceneChangeManager.LoadRoom(targetRoomNr);
        }
        else
        {
            sceneChangeManager.LoadMainScene();
        }
    }
}
