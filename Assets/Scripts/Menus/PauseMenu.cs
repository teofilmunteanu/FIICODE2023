using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject pauseMenu;
    public GameObject principalMenu;
    public GameObject optionsMenu;

    private SceneChangeManager sceneChangeManager;

    private void Start()
    {
        sceneChangeManager = SceneChangeManager.Instance;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    private void Pause()
    {
        principalMenu.SetActive(true);
        optionsMenu.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void Exit()
    {
        sceneChangeManager.LoadMainMenu();
    }
}