using Assets.Scripts.Managers;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody rb;

    Vector3 movement;


    public Transform orintinatorTransform;
    int yRot;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        yRot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = 0;
        movement.z = Input.GetAxisRaw("Vertical");

        //keeps player from rotating on x/z in 2d(unnecessary if using 2d game objects)
        rb.transform.transform.localRotation = Quaternion.identity;

        //rotation shouldn't be updated when paused
        if (!PauseManager.GameIsPaused)
        {
            if (movement.x < 0)
            {
                yRot = -90;
            }
            else if (movement.x > 0)
            {
                yRot = 90;
            }
            else if (movement.z < 0)
            {
                yRot = 180;
            }
            else if (movement.z > 0)
            {
                yRot = 0;
            }
        }

        orintinatorTransform.rotation = Quaternion.Euler(0, yRot, 0);
    }

    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
