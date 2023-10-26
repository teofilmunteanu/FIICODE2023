using UnityEngine;

public class SceneChangerHallway : SceneChanger
{
    [SerializeField]
    private int targetRoomNr;

    [SerializeField]
    private HallwayDoor DoorObject;

    protected override void Start()
    {
        base.Start();
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "Player")
    //    {
    //        ChangeScene();
    //    }
    //}

    protected override void ChangeScene()
    {
        if (sceneChangeManager.IsMainScene())
        {
            Vector3 doorPos = this.transform.position;

            Vector3 newPos = SceneChangeManager.Instance.InitialHallwayPos + new Vector3(doorPos.x - SceneChangeManager.Instance.InitialHallwayPos.x, 0, 0);

            if (!sceneChangeManager.TryLoadAccessibleRoom(targetRoomNr, newPos))
            {
                DoorObject.promptMessage = "Room locked! Complete previous rooms!";
            }
        }
    }
}
