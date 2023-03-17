using UnityEngine;

public class MainMenu : MonoBehaviour
{
    SceneChangeManager sceneChangeManager;
    ProgressManager progressManager;

    private void Start()
    {
        sceneChangeManager = SceneChangeManager.Instance;
        progressManager = ProgressManager.Instance;
    }

    public void NewGame()
    {
        progressManager.ResetProgress();
        sceneChangeManager.LoadMainScene();
    }

    public void LoadGame()
    {
        progressManager.LoadProgress();
        sceneChangeManager.LoadMainScene();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
