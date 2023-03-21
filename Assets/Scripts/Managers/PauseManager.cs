using UnityEngine;

namespace Assets.Scripts.Managers
{
    public static class PauseManager
    {
        public static bool IsGamePaused { get; set; }
        public static bool IsModalOpen { get; set; }
        public static bool IsPauseMenuOpen { get; set; }

        public static void Resume()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            IsGamePaused = false;
        }

        public static void Pause()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            IsGamePaused = true;
        }
    }
}
