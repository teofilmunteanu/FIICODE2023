using UnityEngine;

public class InteractableStorage : MonoBehaviour
{
    public Sprite initalSprite;
    public Sprite futureSprite;

    //public string activateSoundName; 
    public AudioClip activateSound;
    //public string finishSoundName;
    public int keypadButton;

    public int orderDigit;

    public void SwitchSprites()
    {
        Sprite temp = initalSprite;
        initalSprite = futureSprite;
        futureSprite = temp;
    }
}
