using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class PauseManager : MonoBehaviour
    {
        #region Singleton Init
        public static PauseManager Instance;

        void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }

            DontDestroyOnLoad(gameObject);
        }
        #endregion

        public bool IsModalOpen;
        public bool isPauseMenuOpen;
        public bool IsPauseMenuOpen
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
        public event OnMenuOpenChangeDelegate OnMenuOpenChange;

        public void Resume()
        {
            if (IsGamePaused())
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
        }

        public void Pause()
        {
            if (!IsGamePaused())
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
        }

        public void Reset()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;

            IsPauseMenuOpen = false;
            IsModalOpen = false;
        }

        public bool IsGamePaused()
        {
            return Time.timeScale == 0;
        }
    }
}
