using Assets.Scripts.Managers;
using System;
using UnityEngine;

public class PlayerMovement2Dmodified : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody2D rb;

    Vector2 movement;


    //public Transform orintinatorTransform;
    //int zRot;
    [NonSerialized]
    public Vector2 orientation;

    Animator movementAnimator;
    int lastVerticalDir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementAnimator = GetComponent<Animator>();
        lastVerticalDir = 0;
        //zRot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");

        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.y > 0)
        {
            lastVerticalDir = 1;
        }
        else if (movement.y < 0)
        {
            lastVerticalDir = -1;
        }

        movement = movement.normalized;

        //keeps player from rotating on x/z in 2d(unnecessary if using 2d game objects)
        //rb.transform.transform.localRotation = Quaternion.identity;
        //rotation shouldn't be updated when paused

        if (!PauseManager.IsGamePaused)
        {
            if ((movement.x != 0 || movement.y != 0) && Mathf.Abs(movement.x) != Mathf.Abs(movement.y))
            {
                orientation = new Vector2(movement.x, movement.y);
            }

            movementAnimator.SetFloat("Horizontal", movement.x);
            movementAnimator.SetFloat("Vertical", movement.y);
            movementAnimator.SetFloat("Speed", movement.sqrMagnitude);

            movementAnimator.SetFloat("LastVertical", lastVerticalDir);
            //if (movement.x < 0)
            //{
            //    orientation = Vector2.left;
            //}
            //else if (movement.x > 0)
            //{
            //    orientation = Vector2.right;
            //}
            //else if (movement.y < 0)
            //{
            //    orientation = Vector2.down;
            //}
            //else if (movement.y > 0)
            //{
            //    orientation = Vector2.up;
            //}
        }

        //orintinatorTransform.rotation = Quaternion.Euler(0, 0, zRot);
        //orintinatorTransform.position = gameObject.transform.position;
    }

    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
