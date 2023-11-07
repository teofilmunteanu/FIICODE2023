using UnityEngine;

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
            int sceneId = sceneChangeManager.CurrentSceneIndex;
            progressManager.CompleteRoom(sceneId);
            sceneChangeManager.LoadMainScene();
        }
    }
}
