using Assets.Scripts.Managers;

public abstract class PauseInteractables : Interactable
{
    public override void Interact()
    {
        if (PauseManager.Instance.IsGamePaused() && PauseManager.Instance.IsModalOpen)
        {
            PauseManager.Instance.IsModalOpen = false;

            PauseManager.Instance.Resume();
        }
        else
        {
            PauseManager.Instance.IsModalOpen = true;

            PauseManager.Instance.Pause();
        }
    }
}
