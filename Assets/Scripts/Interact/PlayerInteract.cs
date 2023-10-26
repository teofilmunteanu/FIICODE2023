using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private Transform cam;

    [SerializeField]
    private float distance = 3f;

    [SerializeField]
    private LayerMask mask;


    private PlayerUI playerUI;

    private InputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdatePromptText(string.Empty);

        Ray ray = new Ray(cam.position, cam.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {

            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();

                playerUI.UpdatePromptText(interactable.promptMessage);


                //if (interactable.GetComponent<SpriteRenderer>() != null)
                //{
                //    playerUI.InspectedSprite = interactable.GetComponent<SpriteRenderer>().sprite;
                //}

                if (inputManager.firstPerson.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
