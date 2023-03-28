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

        PauseManager.Reset();
    }

    public float timeTest;

    void Update()
    {
        //test
        timeTest = Time.timeScale;

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


            if (PauseManager.IsPauseMenuOpen)
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

        if (!PauseManager.IsModalOpen)
        {
            PauseManager.Pause();
        }
    }

    public void Exit()
    {
        //if (PauseManager.IsModalOpen)
        //{
        //    PauseManager.IsModalOpen = false;
        //}

        sceneChangeManager.LoadMainMenu();
    }
}