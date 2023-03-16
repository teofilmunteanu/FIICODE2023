using UnityEngine;

public class PlayerInteract2 : MonoBehaviour
{
    [SerializeField]
    private Transform cam;

    [SerializeField]
    private float distance = 3f;

    [SerializeField]
    private LayerMask mask;


    private PlayerUI playerUI;

    [SerializeField]
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
        playerUI.UpdateText(string.Empty);

        Ray ray = new Ray(cam.position, cam.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);

                if (inputManager.firstPerson.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
