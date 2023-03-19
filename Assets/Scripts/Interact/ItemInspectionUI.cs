using UnityEngine;
using UnityEngine.UI;

public class ItemInspectionUI : MonoBehaviour
{
    [SerializeField]
    private GameObject inspectedContainerUI;


    public Interactable InteractedObject { get; set; }


    private Image inspectedSpriteUI;

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


        SpriteStorage spriteStorage = InteractedObject.GetComponent<SpriteStorage>();
        inspectedSpriteUI.sprite = spriteStorage.initalSprite;
        //inspectedSpriteUI.GetComponent<Image>().sprite = InspectedSprite;

        //inspectedContainerUI = inspectedSpriteUI.transform.parent.gameObject;
        //inspectedContainerUI.SetActive(true);
    }

    public void InteractWithSprite()
    {
        SpriteStorage spriteStorage = InteractedObject.GetComponent<SpriteStorage>();

        inspectedSpriteUI.sprite = spriteStorage.futureSprite;
        InteractedObject.GetComponent<SpriteRenderer>().sprite = spriteStorage.futureSprite;

        spriteStorage.SwitchSprites();

        //Only switch sprites if the sfx sound isn't playing
        //Eventually play sound from here??? (but then I'd need a field for the song name)
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
