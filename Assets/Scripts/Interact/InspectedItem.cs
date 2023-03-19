using UnityEngine;
using UnityEngine.UI;

public class InspectedItem : MonoBehaviour
{
    [SerializeField]
    private GameObject inspectedContainerUI;

    private Image inspectedSpriteUI;

    public Sprite InspectedSprite { get; set; }

    public void ActivateSpriteInspector()
    {
        inspectedContainerUI.SetActive(true);

        inspectedSpriteUI = inspectedContainerUI.transform.GetChild(0).gameObject.GetComponent<Image>();
        inspectedSpriteUI.sprite = InspectedSprite;
        //inspectedSpriteUI.GetComponent<Image>().sprite = InspectedSprite;

        //inspectedContainerUI = inspectedSpriteUI.transform.parent.gameObject;
        //inspectedContainerUI.SetActive(true);
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
