using Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Interact
{
    public class AnimatedModalCloseUI : ModalCloseUI
    {
        [SerializeField]
        Animator modalAnimator;

        public void CloseModal()
        {
            modalAnimator.SetTrigger("Open");
            PauseManager.Instance.IsModalOpen = false;
            PauseManager.Instance.Resume();
        }

        public override void OnDeselect(BaseEventData eventData)
        {
            base.OnDeselect(eventData);

            if (!mouseOver && !PauseManager.Instance.IsPauseMenuOpen)
            {
                modalAnimator.SetTrigger("Open");
            }
        }
    }
}
