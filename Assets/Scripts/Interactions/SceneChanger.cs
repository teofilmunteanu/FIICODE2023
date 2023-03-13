using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    //put script on door, and assign currentRoomDoorNr from editor
    [SerializeField]
    private int targetRoomNr;

    private ProgressManager progressManager;
    private SceneChangeManager sceneChangeManager;

    private void Start()
    {
        progressManager = ProgressManager.Instance;
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


        if (sceneChangeManager.IsMainScene())
        {
            Vector3 doorPos = this.transform.position;
            Vector3 offset = new Vector3(0, 0, -2);

            sceneChangeManager.LoadRoom(targetRoomNr, doorPos + offset);
        }
        else
        {
            int sceneId = sceneChangeManager.CurrentSceneIndex;
            progressManager.CompleteRoom(sceneId);
            sceneChangeManager.LoadMainScene();
        }
    }
}
