using UnityEngine;

public class SpriteStorage : MonoBehaviour
{
    public Sprite initalSprite;

    public Sprite futureSprite;

    public void SwitchSprites()
    {
        Sprite temp = initalSprite;
        initalSprite = futureSprite;
        futureSprite = temp;
    }
}
