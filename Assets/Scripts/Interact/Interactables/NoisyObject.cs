public class NoisyObject : PauseInteractables
{
    public ItemInspectionUI itemInspectionUI;

    public override void Interact()
    {
        base.Interact();

        if (!itemInspectionUI.IsSpriteInspectorOpen())
        {
            itemInspectionUI.ActivateSpriteInspector();
        }
        else
        {
            itemInspectionUI.ExitSpriteInspector();
        }

    }
}
