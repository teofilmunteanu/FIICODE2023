using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage;
    public void BaseInteract()
    {
        Debug.Log("Interact with " + gameObject.name);
        Interact();
    }

    public abstract void Interact();


}
