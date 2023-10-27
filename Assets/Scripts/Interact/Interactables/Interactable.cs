using Assets.Scripts.Managers;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage;
    public void BaseInteract()
    {
        if (!PauseManager.Instance.IsPauseMenuOpen)
        {
            Interact();
        }
    }

    public abstract void Interact();
}
