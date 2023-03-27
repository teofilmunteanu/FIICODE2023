using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedButton : MonoBehaviour
{
    [SerializeField] Transform snake;
    SpriteRenderer renderer;
    public bool isPressed = false;

    private void Update()
    {
        if(transform.position.x + 0.5f >= snake.position.x && transform.position.x -0.5f <= snake.position.x)
        {
            if(transform.position.y + 0.5f >= snake.position.y && transform.position.y - 0.5f <= snake.position.y)
                isPressed = true;
        }
    }
}
