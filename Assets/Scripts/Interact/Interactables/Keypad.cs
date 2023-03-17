using UnityEngine;

public class Keypad : PauseInteractables
{
    [SerializeField]
    Animator keypadAnimator;


    public override void Interact()
    {
        base.Interact();

        keypadAnimator.SetTrigger("Open");
    }
}
