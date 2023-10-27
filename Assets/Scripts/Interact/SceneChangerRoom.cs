using UnityEngine;

// MAKE SEPARATE CLASS FOR RoomSceneChanger

public class SceneChangerRoom : SceneChanger
{
    protected override void Start()
    {
        base.Start();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject == Player)
        {
            ChangeScene();
        }
    }

    protected override void ChangeScene()
    {
        if (!sceneChangeManager.IsMainScene())
        {
            Debug.Log(sceneChangeManager.CurrentSceneIndex);
            int sceneId = sceneChangeManager.CurrentSceneIndex;

            //null reference ??????
            Debug.Log(progressManager.CompletedRooms[0]);
            //progressManager.CompleteRoom(sceneId);
            //sceneChangeManager.LoadMainScene();
        }
    }
}
