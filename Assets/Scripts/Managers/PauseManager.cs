using UnityEngine;

namespace Assets.Scripts.Managers
{
    public static class PauseManager
    {
        public static bool IsGamePaused
        {
            get
            {
                return Time.timeScale == 0;
            }
        }
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
            if (IsGamePaused)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
        }

        public static void Pause()
        {
            if (!IsGamePaused)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
        }

        public static void Reset()
        {
            Resume();
            IsPauseMenuOpen = false;
            IsModalOpen = false;
        }
    }
}
