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
        inspectSpriteUI.enabled = true;
        inspectSpriteUI.sprite = InspectedSprite;
    }

    public void ExitSpriteInspector()
    {
        inspectSpriteUI.enabled = false;
    }
}