using Assets.Scripts.Managers;

public abstract class PauseInteractables : Interactable
{
    public override void Interact()
    {
        if (PauseManager.IsGamePaused)
        {
            PauseManager.IsModalOpen = false;

            PauseManager.Resume();
        }
        else
        {
            PauseManager.IsModalOpen = true;

            PauseManager.Pause();
        }
    }
}
