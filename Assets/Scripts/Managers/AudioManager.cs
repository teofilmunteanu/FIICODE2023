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

    // public void PlayButtonSound(string soundName)
    // {
    //     Sound s = Array.Find(buttonsPressSounds, sound => sound.name == soundName);

    //     if (s != null)
    //     {
    //         buttonsPressSource.clip = s.audioClip;

    //         buttonsPressSource.Play();
    //     }
    // }
    public void PlayButtonSound(AudioClip sound)
    {
        //Sound s = Array.Find(buttonsPressSounds, sound => sound.name == soundName);

        // if (sound != null)
        // {
        buttonsPressSource.clip = sound;

        buttonsPressSource.Play();
        //}
    }

    // public void PlayInteractableSounds(string activateSoundName, string finishSoundName)
    // {
    //     Sound activateSound = Array.Find(interactablesSounds, sound => sound.name == activateSoundName);
    //     //int s1Index = Array.IndexOf(interactablesSounds, s1);

    //     Sound finishSound = Array.Find(buttonsPressSounds, sound => sound.name == finishSoundName);


    //     if (activateSound != null && finishSound != null)
    //     {
    //         double sound1Duration = (double)activateSound.audioClip.samples / activateSound.audioClip.frequency;

    //         interactablesSource.clip = activateSound.audioClip;
    //         buttonsPressSource.clip = finishSound.audioClip;

    //         interactablesSource.PlayScheduled(AudioSettings.dspTime + 0.1);
    //         buttonsPressSource.PlayScheduled(AudioSettings.dspTime + 0.1 + sound1Duration);
    //     }
    // }
    public void PlayInteractableSounds(AudioClip activateSound, AudioClip finishSound)
    {
        //Sound activateSound = Array.Find(interactablesSounds, sound => sound.name == activateSoundName);
        //int s1Index = Array.IndexOf(interactablesSounds, s1);

        //Sound finishSound = Array.Find(buttonsPressSounds, sound => sound.name == finishSoundName);


        if (activateSound != null && finishSound != null)
        {
            double sound1Duration = (double)activateSound.samples / activateSound.frequency;

            interactablesSource.clip = activateSound;
            buttonsPressSource.clip = finishSound;

            interactablesSource.PlayScheduled(AudioSettings.dspTime + 0.1);
            buttonsPressSource.PlayScheduled(AudioSettings.dspTime + 0.1 + sound1Duration);
        }
    }

    public bool IsInteractableSoundPlaying()
    {
        return interactablesSource.isPlaying || buttonsPressSource.isPlaying;
    }
}
