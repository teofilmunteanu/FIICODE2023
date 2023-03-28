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

        PauseManager.Instance.Reset();
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


            if (PauseManager.Instance.IsPauseMenuOpen)
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

        PauseManager.Instance.IsPauseMenuOpen = false;

        if (!PauseManager.Instance.IsModalOpen)
        {
            PauseManager.Instance.Resume();
        }
    }

    public void ShowMenu()
    {
        pauseMenu.SetActive(true);

        PauseManager.Instance.IsPauseMenuOpen = true;

        principalMenu.SetActive(true);
        optionsMenu.SetActive(false);

        if (!PauseManager.Instance.IsModalOpen)
        {
            PauseManager.Instance.Pause();
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