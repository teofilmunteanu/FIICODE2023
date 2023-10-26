using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] PlayerMovement2Dmodified playerMovementScript;
    [SerializeField] GameObject[] buttons;
    [SerializeField] TilemapRenderer tm;

    //maybe follow the collider's positions (cuz the snake has to touch the collider to catch the player)
    //---OOOR, setup a 2nd collider for snake and player
    List<Vector2> playerPositions;
    bool execute = false;
    public GameObject prefab;

    int buttonsPressed;
    public bool gameFinished;

    private IEnumerator couritine;
    void Start()
    {
        playerPositions = new List<Vector2>
        {
           transform.position
        };

        float distance = Vector2.Distance(transform.position, playerMovementScript.rb.position);
        int numberOfPoints = Mathf.CeilToInt(distance / 0.1f);
        Vector2 positionIncrement = (playerMovementScript.rb.position - (Vector2)transform.position) / numberOfPoints;

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
            playerPositions.Add(playerMovementScript.rb.position);
        }
        transform.right = new Vector3(playerPositions[0].x, playerPositions[0].y, 0) - transform.position;
        if (playerPositions.Count > 50 && !execute)
        {
            execute = true;
            //InvokeRepeating("Following", 0.5f, 1f * Time.deltaTime);
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

        if (buttonsPressed == buttons.Length - 3)
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

        while (true)
        {
            if (playerPositions.Count > 2)
            {
                transform.position = playerPositions[2];
                //GameObject newObject;
                i++;
                if (i % 3 == 0)
                {
                    Instantiate(prefab, playerPositions[0], Quaternion.identity);
                    i = i / 3;
                }
                playerPositions.RemoveAt(0);
                //yield return new WaitForSeconds(.1f);
            }
            yield return new WaitForSeconds(1f * Time.fixedDeltaTime);
        }

    }
}


