using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton Init
    public static AudioManager Instance;

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

    public Sound[] interactablesSounds, buttonsPressSounds; //sfxSounds, musicSounds ...
    public AudioSource interactablesSource, buttonsPressSource;

    public void PlayButtonSound(string soundName)
    {
        Sound s = Array.Find(buttonsPressSounds, sound => sound.name == soundName);

        if (s != null)
        {
            buttonsPressSource.clip = s.audioClip;

            buttonsPressSource.Play();
        }
    }

    public void PlayInteractableSounds(string soundName)
    {
        Sound s1 = Array.Find(interactablesSounds, sound => sound.name == soundName);
        int s1Index = Array.IndexOf(interactablesSounds, s1);

        Sound s2 = buttonsPressSounds[s1Index];


        if (s1 != null && s2 != null)
        {
            double sound1Duration = (double)s1.audioClip.samples / s1.audioClip.frequency;

            interactablesSource.clip = s1.audioClip;
            buttonsPressSource.clip = s2.audioClip;

            interactablesSource.PlayScheduled(AudioSettings.dspTime + 0.1);
            buttonsPressSource.PlayScheduled(AudioSettings.dspTime + 0.1 + sound1Duration);
        }
    }
}
