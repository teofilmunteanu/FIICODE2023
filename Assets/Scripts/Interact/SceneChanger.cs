using UnityEngine;

public abstract class SceneChanger : MonoBehaviour
{
    [SerializeField]
    protected GameObject Player;

    protected ProgressManager progressManager;
    protected SceneChangeManager sceneChangeManager;

    protected virtual void Start()
    {
        progressManager = ProgressManager.Instance;
        sceneChangeManager = SceneChangeManager.Instance;
    }

    protected abstract void ChangeScene();
}
