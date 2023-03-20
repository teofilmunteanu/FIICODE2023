using UnityEngine;

public class InteractableStorage : MonoBehaviour
{
    public Sprite initalSprite;
    public Sprite futureSprite;

    public string activateSoundName;
    public string finishSoundName;

    public void SwitchSprites()
    {
        Sprite temp = initalSprite;
        initalSprite = futureSprite;
        futureSprite = temp;
    }
}
