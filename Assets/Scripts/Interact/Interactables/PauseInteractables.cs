using Assets.Scripts.Managers;

public abstract class PauseInteractables : Interactable
{
    public override void Interact()
    {
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
