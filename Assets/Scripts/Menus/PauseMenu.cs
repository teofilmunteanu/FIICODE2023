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
            pauseMenu.SetActive(!GameIsPaused);

            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                principalMenu.SetActive(true);
                optionsMenu.SetActive(false);

                Pause();
            }
        }
    }

    public static void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    public static void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void Exit()
    {
        sceneChangeManager.LoadMainMenu();
    }
}