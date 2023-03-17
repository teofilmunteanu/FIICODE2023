using Assets.Scripts.Managers;
using UnityEngine;

public abstract class PauseInteractables : Interactable
{
    public override void Interact()
    {
        Debug.Log("Paused");
        if (PauseManager.GameIsPaused)
        {
            PauseManager.Resume();
        }
        else
        {
            PauseManager.Pause();
        }
    }
}
