using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    protected ProgressManager progressManager;
    protected SceneChangeManager sceneChangeManager;

    protected virtual void Start()
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

    protected virtual void ChangeScene()
    {
        if (!sceneChangeManager.IsMainScene())
        {
            int sceneId = sceneChangeManager.CurrentSceneIndex;
            progressManager.CompleteRoom(sceneId);
            sceneChangeManager.LoadMainScene();
        }
    }
}
