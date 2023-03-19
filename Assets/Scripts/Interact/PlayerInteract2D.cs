using UnityEngine;

public class PlayerInteract2D : MonoBehaviour
{
    [SerializeField]
    private float distance = 3f;

    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private InputManager inputManager;


    private PlayerUI playerUI;

    //private Transform orientinator;
    private PlayerMovement2Dmodified playerMovement;


    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
        playerMovement = GetComponent<PlayerMovement2Dmodified>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdatePromptText(string.Empty);

        //Ray2D ray = new Ray2D(orientinator.position, Vector2.up);
        //Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        //RaycastHit2D hitInfo = Physics2D.Raycast(ray.origin, ray.direction, distance, mask);

        Ray2D ray = new Ray2D(gameObject.transform.position, playerMovement.orientation);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, distance, mask);

        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        if (hit)
        {
            Debug.Log("collided");

            if (hit.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                playerUI.UpdatePromptText(interactable.promptMessage);

                if (interactable.GetComponent<SpriteRenderer>() != null)
                {
                    playerUI.InspectedSprite = interactable.GetComponent<SpriteRenderer>().sprite;
                }

                if (inputManager.firstPerson.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
