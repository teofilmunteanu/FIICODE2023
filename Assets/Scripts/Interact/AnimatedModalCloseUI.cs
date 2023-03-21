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
            PauseManager.Resume();
        }

        public override void OnDeselect(BaseEventData eventData)
        {
            base.OnDeselect(eventData);

            if (!mouseOver && !PauseManager.IsPauseMenuOpen)
            {
                modalAnimator.SetTrigger("Open");
            }
        }
    }
}
