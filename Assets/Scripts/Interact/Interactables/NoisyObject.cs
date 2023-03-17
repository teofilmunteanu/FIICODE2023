using UnityEngine;

public class NoisyObject : PauseInteractables
{
    [SerializeField]
    private PlayerUI playerUI;

    public override void Interact()
    {
        base.Interact();

        if (!playerUI.IsSpriteInspectorOpen())
        {
            playerUI.ActivateSpriteInspector();
        }
        else
        {
            playerUI.ExitSpriteInspector();
        }

    }
}
