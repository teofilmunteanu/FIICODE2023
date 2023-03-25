using UnityEngine;

namespace Assets.Scripts.Managers
{
    public static class PauseManager
    {
        public static bool IsGamePaused { get; set; }
        public static bool IsModalOpen { get; set; }
        private static bool isPauseMenuOpen;
        public static bool IsPauseMenuOpen
        {
            get
            {
                return isPauseMenuOpen;
            }
            set
            {
                if (isPauseMenuOpen == value)
                {
                    return;
                }

                isPauseMenuOpen = value;
                if (OnMenuOpenChange != null)
                {
                    OnMenuOpenChange(value);
                }
            }
        }


        public delegate void OnMenuOpenChangeDelegate(bool newVal);
        public static event OnMenuOpenChangeDelegate OnMenuOpenChange;

        public static void Resume()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            IsGamePaused = false;
            IsPauseMenuOpen = false;
            IsModalOpen = false;
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
