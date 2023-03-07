using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteract : MonoBehaviour
{
    [SerializeField]
    private LayerMask interactableLayerMask;

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    private GameObject interactUI;

    [SerializeField]
    [Min(1)]
    private float hitRange=3;

    private RaycastHit hit;

    void Update()
    {
        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * hitRange, Color.red);
        if (hit.collider != null )
        {
            Debug.Log("vede obiect");
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
            interactUI.SetActive(false);
        }
        if(Physics.Raycast(playerCameraTransform.position,playerCameraTransform.forward, out hit,hitRange,interactableLayerMask))
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
            interactUI.SetActive(true);
        }
    }
}
