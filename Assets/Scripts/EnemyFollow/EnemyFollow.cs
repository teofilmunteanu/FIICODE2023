using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] PlayerMovement2Dmodified playerMovementScript;

    List<Vector2> playerPositions;
    bool execute = false;
    public GameObject prefab;

    public float playerColliderOffsetY;

    private float snakeSpeed = 22f;

    bool firstFollowDone;
    float instantiateDelay = 0;

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
    }

    private void FixedUpdate()
    {
        if (playerMovementScript.movement != Vector2.zero)
        {
            Vector2 playerLegsPos = new Vector2(playerMovementScript.rb.position.x, playerMovementScript.rb.position.y + playerColliderOffsetY);
            playerPositions.Add(playerLegsPos);
        }

        if (!Room3ButtonManager.Instance.gameFinished)
        {
            if (playerPositions.Count > 50 || firstFollowDone)
            {
                if (!firstFollowDone && playerPositions.Count > 50)
                {
                    firstFollowDone = true;
                }

                FollowPlayer();
            }
        }
    }

    private void FollowPlayer()
    {
        if (playerPositions.Count > 2)
        {
            SetSnakeDirection();

            transform.position = (Vector3)playerPositions[2];

            instantiateDelay += snakeSpeed * Time.deltaTime;
            if (Mathf.Floor(instantiateDelay) % 3 == 0)
            {
                Instantiate(prefab, playerPositions[0], Quaternion.identity);
                instantiateDelay /= 3;
            }
            playerPositions.RemoveAt(0);
        }
    }

    private void SetSnakeDirection()
    {
        Vector2 movementDirection = (playerPositions[2] - (Vector2)transform.position).normalized;

        Vector3 currentRot = transform.rotation.eulerAngles;

        if (Mathf.Abs(movementDirection.x) > Mathf.Abs(movementDirection.y))
        {
            currentRot.z = 0;

            if (movementDirection.x > 0)
            {
                currentRot.y = 0;
            }
            else if (movementDirection.x < 0)
            {
                currentRot.y = 180;
            }
        }
        else
        {
            currentRot.y = 0;

            if (movementDirection.y > 0)
            {
                currentRot.z = 90;
            }
            else if (movementDirection.y < 0)
            {
                currentRot.z = -90;
            }
        }


        transform.rotation = Quaternion.Euler(currentRot);
    }
}


