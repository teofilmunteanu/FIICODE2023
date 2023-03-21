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
            //if (PauseManager.IsGamePaused)
            //{
            //    HideMenu();
            //}
            //else if (!PauseManager.IsGamePaused || PauseManager.IsModalOpen)
            //{
            //    ShowMenu();
            //}


            if (pauseMenu.activeSelf)
            {
                HideMenu();
            }
            else
            {
                ShowMenu();
            }

        }
    }

    public void HideMenu()
    {
        pauseMenu.SetActive(false);

        PauseManager.IsPauseMenuOpen = false;

        if (!PauseManager.IsModalOpen)
        {
            PauseManager.Resume();
        }
    }

    public void ShowMenu()
    {
        pauseMenu.SetActive(true);

        PauseManager.IsPauseMenuOpen = true;

        principalMenu.SetActive(true);
        optionsMenu.SetActive(false);

        PauseManager.Pause();
    }

    public void Exit()
    {
        sceneChangeManager.LoadMainMenu();
    }
}