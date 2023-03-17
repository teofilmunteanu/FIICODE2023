using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Interact
{
    public class AnimatedModalCloseUI : ModalCloseUI
    {
        [SerializeField]
        Animator modalAnimator;

        public override void OnDeselect(BaseEventData eventData)
        {
            base.OnDeselect(eventData);

            if (!mouseOver)
            {
                modalAnimator.SetTrigger("Open");
            }
        }
    }
}
