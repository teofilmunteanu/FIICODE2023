using UnityEngine;
using UnityEngine.UI;

public class ItemInspectionUI : MonoBehaviour
{
    [SerializeField]
    private GameObject inspectedContainerUI;

    public Interactable InteractedObject { get; set; }

    private Image inspectedSpriteUI;
    private InteractableStorage interactableStorage;

    //private Sprite InitialSprite;

    //private Sprite FutureSprite;


    //public void SetInspectedSprites(Sprite initialSprite, Sprite futureSprite)
    //{
    //    InitialSprite = initialSprite;
    //    FutureSprite = futureSprite;
    //}

    public void ActivateSpriteInspector()
    {
        inspectedContainerUI.SetActive(true);

        inspectedSpriteUI = inspectedContainerUI.transform.GetChild(0).gameObject.GetComponent<Image>();
        interactableStorage = InteractedObject.GetComponent<InteractableStorage>();

        inspectedSpriteUI.sprite = interactableStorage.initalSprite;
        //inspectedSpriteUI.GetComponent<Image>().sprite = InspectedSprite;

        //inspectedContainerUI = inspectedSpriteUI.transform.parent.gameObject;
        //inspectedContainerUI.SetActive(true);
    }

    public void InteractWithSprite()
    {
        if (!AudioManager.Instance.IsInteractableSoundPlaying())
        {
            inspectedSpriteUI.sprite = interactableStorage.futureSprite;
            InteractedObject.GetComponent<SpriteRenderer>().sprite = interactableStorage.futureSprite;
            interactableStorage.SwitchSprites();

            AudioManager.Instance.PlayInteractableSounds(interactableStorage.activateSoundName, interactableStorage.finishSoundName);
        }
    }

    public void ExitSpriteInspector()
    {
        inspectedContainerUI.SetActive(false);
    }

    public bool IsSpriteInspectorOpen()
    {
        return inspectedContainerUI.activeSelf;
    }

}
