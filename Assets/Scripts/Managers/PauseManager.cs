using UnityEngine;

namespace Assets.Scripts.Managers
{
    public static class PauseManager
    {
        public static bool GameIsPaused;

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
    }
}
