using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private Text promptTextUI;


    [SerializeField]
    private Image inspectSpriteUI;

    public Sprite InspectedSprite { get; set; }


    private void Start()
    {
        inspectSpriteUI.enabled = false;
    }

    public void UpdatePromptText(string promptMessage)
    {
        promptTextUI.text = promptMessage;
    }

    public void ActivateSpriteInspector()
    {
        inspectSpriteUI.sprite = InspectedSprite;
        inspectSpriteUI.enabled = true;
    }

    public void ExitSpriteInspector()
    {
        inspectSpriteUI.enabled = false;
    }
}