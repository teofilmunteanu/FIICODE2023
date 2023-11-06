using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] PlayerMovement2Dmodified playerMovementScript;
    [SerializeField] GameObject[] buttons;
    [SerializeField] TilemapRenderer tm;

    List<Vector2> playerPositions;
    bool execute = false;
    public GameObject prefab;

    int buttonsPressed;
    public bool gameFinished;

    public float playerColliderOffsetY;

    private IEnumerator couritine;
    private float snakeMoveDelay = 60.06f;

    void Start()
    {
        playerPositions = new List<Vector2>
        {
           transform.position
        };

        BoxCollider2D playerCollider = playerMovementScript.rb.GetComponent<BoxCollider2D>();
        playerColliderOffsetY = 2 * (playerCollider.offset.y - playerCollider.size.y);
        Vector2 playerLegsPos = new Vector2(playerMovementScript.rb.position.x, playerMovementScript.rb.position.y + playerColliderOffsetY);

        float distance = Vector2.Distance(transform.position, playerLegsPos);
        int numberOfPoints = Mathf.CeilToInt(distance / 0.1f);
        Vector2 positionIncrement = (playerLegsPos - (Vector2)transform.position) / numberOfPoints;

        for (int i = 0; i < numberOfPoints; i++)
        {
            Vector2 newPosition = (Vector2)transform.position + i * positionIncrement;
            playerPositions.Add(newPosition);
        }

        gameFinished = false;

        couritine = Following();
    }

    private void FixedUpdate()
    {
        if (playerMovementScript.movement != Vector2.zero)
        {
            Vector2 playerLegsPos = new Vector2(playerMovementScript.rb.position.x, playerMovementScript.rb.position.y + playerColliderOffsetY);
            playerPositions.Add(playerLegsPos);
        }
        transform.right = new Vector3(playerPositions[0].x, playerPositions[0].y, 0) - transform.position;

        Vector3 currentRot = transform.rotation.eulerAngles;
        currentRot.z = 0;
        transform.rotation = Quaternion.Euler(currentRot);

        if (playerPositions.Count > 50 && !execute)
        {
            execute = true;
            StartCoroutine(couritine);
        }


        buttonsPressed = 0;

        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].GetComponent<PressedButton>().isPressed)
            {
                buttonsPressed++;
            }
        }

        if (buttonsPressed == buttons.Length)
        {
            StopCoroutine(couritine);
            tm.enabled = false;

            gameFinished = true;

            foreach (var collider in tm.GetComponentsInChildren<Collider2D>())
            {
                collider.enabled = false;
            }
        }
    }

    IEnumerator Following()
    {
        int i = 0;

        while (!gameFinished)
        {
            if (playerPositions.Count > 2)
            {
                transform.position = playerPositions[2];

                i++;
                if (i % 3 == 0)
                {
                    Instantiate(prefab, playerPositions[0], Quaternion.identity);
                    i = i / 3;
                }
                playerPositions.RemoveAt(0);
            }
            yield return new WaitForSeconds(1f / snakeMoveDelay);
        }

    }
}


