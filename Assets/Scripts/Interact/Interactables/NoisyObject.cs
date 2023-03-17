using UnityEngine;

public class NoisyObject : PauseInteractables
{
    [SerializeField]
    private PlayerUI playerUI;

    public override void Interact()
    {
        base.Interact();

        playerUI.ActivateSpriteInspector();
    }
}
