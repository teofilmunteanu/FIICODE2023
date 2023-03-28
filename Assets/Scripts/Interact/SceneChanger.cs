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

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("collision!");
        if (collider.gameObject.name == "Player")
        {
            ChangeScene();
        }
    }

    public void ChangeScene()
    {


        if (sceneChangeManager.IsMainScene())
        {
            Vector3 doorPos = this.transform.position;
            //Vector3 offset;
            //if (doorPos.z > SceneChangeManager.Instance.InitialHallwayPos.z)
            //{
            //    offset = new Vector3(0, 0, -2);
            //}
            //else
            //{
            //    offset = new Vector3(0, 0, 2);
            //}
            Vector3 newPos = SceneChangeManager.Instance.InitialHallwayPos + new Vector3(doorPos.x - SceneChangeManager.Instance.InitialHallwayPos.x, 0, 0);

            sceneChangeManager.LoadRoom(targetRoomNr, newPos);
        }
        else
        {
            int sceneId = sceneChangeManager.CurrentSceneIndex;
            progressManager.CompleteRoom(sceneId);
            sceneChangeManager.LoadMainScene();
        }
    }
}
