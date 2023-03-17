using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PauseInteractables : Interactable
{
    public override void Interact()
    {
        Debug.Log("Paused");
        if (PauseMenu.GameIsPaused)
        {
            PauseMenu.Resume();
        }
        else
        {
            PauseMenu.Pause();
        }
    }
}
