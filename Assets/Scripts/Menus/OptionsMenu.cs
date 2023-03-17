using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider volumeSlider;

    public Dropdown resDropdown;
    Resolution[] resolutions;

    public Toggle fullscreenToggle;

    void Start()
    {
        VolumeInit();
        ResoltionsInit();
        FullscreenInit();
    }

    public void VolumeInit()
    {
        float value;
        masterMixer.GetFloat("MasterVolume", out value);
        volumeSlider.value = Mathf.Pow(10f, value / 20f);
    }

    public void ResoltionsInit()
    {
        resolutions = Screen.resolutions.Select(resolution => new Resolution
        {
            width = resolution.width,
            height = resolution.height
        }).Distinct().ToArray();

        resDropdown.ClearOptions();

        List<string> resOptions = new List<string>();

        int currentResolution = 0;
        for (int i = resolutions.Length - 1; i >= 0; i--)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            resOptions.Add(option);

            if (resolutions[i].width == PlayerPrefs.GetInt("ResWidth")
                && resolutions[i].height == PlayerPrefs.GetInt("ResHeight"))
            {
                currentResolution = i;
            }
        }

        resDropdown.AddOptions(resOptions);
        resDropdown.value = currentResolution;
        resDropdown.RefreshShownValue();
    }

    public void FullscreenInit()
    {
        if (PlayerPrefs.GetInt("IsFullscreen") == 1)
            fullscreenToggle.isOn = true;
        else
            fullscreenToggle.isOn = false;
    }

    public void SetVolume(float volume)
    {
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

    public void SetVideoQuality(int qualityLevel)
    {
        QualitySettings.SetQualityLevel(qualityLevel);
    }

    public void SetResolution(int resolutionIndex)
    {
        PlayerPrefs.SetInt("ResWidth", resolutions[resolutionIndex].width);
        PlayerPrefs.SetInt("ResHeight", resolutions[resolutionIndex].height);
        Screen.SetResolution(PlayerPrefs.GetInt("ResWidth"), PlayerPrefs.GetInt("ResHeight"), Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

        if (isFullScreen)
            PlayerPrefs.SetInt("IsFullscreen", 1);
        else
            PlayerPrefs.SetInt("IsFullscreen", 0);
    }
}
