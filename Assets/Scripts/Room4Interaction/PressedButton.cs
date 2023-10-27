using UnityEngine;

public class PressedButton : MonoBehaviour
{
    [SerializeField]
    GameObject Snake;

    public bool isPressed = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject == Snake)
        {
            isPressed = true;
        }
    }
}
