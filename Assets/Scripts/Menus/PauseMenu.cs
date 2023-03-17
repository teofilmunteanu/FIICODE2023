using Assets.Scripts.Managers;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject principalMenu;
    public GameObject optionsMenu;

    private SceneChangeManager sceneChangeManager;

    private void Start()
    {
        sceneChangeManager = SceneChangeManager.Instance;

        PauseManager.Resume();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseManager.GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);

        PauseManager.Resume();
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);

        principalMenu.SetActive(true);
        optionsMenu.SetActive(false);

        PauseManager.Pause();
    }

    public void Exit()
    {
        sceneChangeManager.LoadMainMenu();
    }
}