using Assets.Scripts.Managers;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage;
    public void BaseInteract()
    {
        Debug.Log("Interact with " + gameObject.name);
        if (!PauseManager.Instance.IsPauseMenuOpen)
        {
            Interact();
        }
    }

    public abstract void Interact();
}
