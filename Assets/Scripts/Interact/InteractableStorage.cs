using UnityEngine;

public class InteractableStorage : MonoBehaviour
{
    public Sprite initalSprite;
    public Sprite futureSprite;

    //public string activateSoundName; 
    public AudioClip activateSound;
    //public string finishSoundName;
    public AudioClip finishSound;

    public void SwitchSprites()
    {
        Sprite temp = initalSprite;
        initalSprite = futureSprite;
        futureSprite = temp;
    }
}
