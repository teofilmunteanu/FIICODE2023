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
        sceneChangeManager.LoadMainScene();
        progressManager.ResetProgress();
    }

    public void LoadGame()
    {
        sceneChangeManager.LoadMainScene();

        //get data from save file
        //load selected save file
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
