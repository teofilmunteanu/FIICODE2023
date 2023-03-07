using Assets.Scripts.Managers;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject pauseMenuUI;

    //public AudioMixer masterMixer;
    //public Slider volumeSlider;

    //public Dropdown resDropdown;
    //public Toggle fullscreenToggle;
    //Resolution[] resolutions;

    void Start()
    {
        //float value;
        //masterMixer.GetFloat("Volume", out value);
        //volumeSlider.value = Mathf.Pow(10f, value / 20f);

        //resolutions = Screen.resolutions.Select(resolution => new Resolution
        //{ width = resolution.width, height = resolution.height }).Distinct().ToArray();

        //resDropdown.ClearOptions();

        //List<string> resOptions = new List<string>();

        //int currentResolution = 0;
        //for (int i = 0; i < resolutions.Length; i++)
        //{
        //    string option = resolutions[i].width + "x" + resolutions[i].height;
        //    resOptions.Add(option);

        //    if (resolutions[i].width == PlayerPrefs.GetInt("ResWidth")
        //        && resolutions[i].height == PlayerPrefs.GetInt("ResHeight"))
        //    {
        //        currentResolution = i;
        //    }
        //}
        //resDropdown.AddOptions(resOptions);
        //resDropdown.value = currentResolution;
        //resDropdown.RefreshShownValue();

        //if (PlayerPrefs.GetInt("IsFullscreen") == 1)
        //    fullscreenToggle.isOn = true;
        //else
        //    fullscreenToggle.isOn = false;
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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    private void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void SaveAndExit()
    {
        SavesManager.SaveProgress();
        Debug.Log("get to main menu");

        Resume(); //only for testing, should return to menu
    }

    //public void SetVolume(float volume)
    //{
    //    masterMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    //}

    //public void SetResolution(int resolutionIndex)
    //{
    //    PlayerPrefs.SetInt("ResWidth", resolutions[resolutionIndex].width);
    //    PlayerPrefs.SetInt("ResHeight", resolutions[resolutionIndex].height);
    //    Screen.SetResolution(PlayerPrefs.GetInt("ResWidth"), PlayerPrefs.GetInt("ResHeight"), Screen.fullScreen);
    //}

    //public void SetFullscreen(bool isFullScreen)
    //{
    //    Screen.fullScreen = isFullScreen;
    //    if (isFullScreen)
    //        PlayerPrefs.SetInt("IsFullscreen", 1);
    //    else
    //        PlayerPrefs.SetInt("IsFullscreen", 0);
    //}
}