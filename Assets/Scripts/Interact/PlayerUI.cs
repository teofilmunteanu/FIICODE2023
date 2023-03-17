using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private Text promptTextUI;

    [SerializeField]
    private GameObject spriteContainerUI;

    public Sprite InspectedSprite { get; set; }


    public void UpdatePromptText(string promptMessage)
    {
        promptTextUI.text = promptMessage;
    }

    public void ActivateSpriteInspector()
    {
        spriteContainerUI.GetComponent<Image>().sprite = InspectedSprite;
        spriteContainerUI.SetActive(true);
    }

    public void ExitSpriteInspector()
    {
        spriteContainerUI.SetActive(false);
    }

    public bool IsSpriteInspectorOpen()
    {
        return spriteContainerUI.activeSelf;
    }
}