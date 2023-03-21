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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //zRot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");

        movement.y = Input.GetAxisRaw("Vertical");

        //keeps player from rotating on x/z in 2d(unnecessary if using 2d game objects)
        //rb.transform.transform.localRotation = Quaternion.identity;

        //rotation shouldn't be updated when paused
        if (!PauseManager.GameIsPaused)
        {
            if ((movement.x != 0 || movement.y != 0) && Mathf.Abs(movement.x) != Mathf.Abs(movement.y))
            {
                orientation = new Vector2(movement.x, movement.y);
            }
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
