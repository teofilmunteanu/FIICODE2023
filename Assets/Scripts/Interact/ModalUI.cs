using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModalUI : MonoBehaviour, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    Animator modalAnimator;

    private bool mouseOver = false;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (!mouseOver)
        {
            PauseMenu.Resume();
            modalAnimator.SetTrigger("Open");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
}