using Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModalCloseUI : MonoBehaviour, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    protected bool mouseOver = false;

    private void Start()
    {
        PauseManager.Instance.OnMenuOpenChange += OnMenuOpenChangeHandler;
    }

    protected void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    public virtual void OnDeselect(BaseEventData eventData)
    {
        if (!mouseOver && !PauseManager.Instance.IsPauseMenuOpen && PauseManager.Instance.IsModalOpen)
        {
            PauseManager.Instance.Resume();
            PauseManager.Instance.IsModalOpen = false;
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

    private void OnMenuOpenChangeHandler(bool newVal)
    {
        if (this != null)
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }
    }
}