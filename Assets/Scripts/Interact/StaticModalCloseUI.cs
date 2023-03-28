using Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Interact
{
    public class StaticModalCloseUI : ModalCloseUI
    {
        [SerializeField]
        private GameObject ContainerUI;

        public override void OnDeselect(BaseEventData eventData)
        {
            base.OnDeselect(eventData);

            if (!mouseOver && !PauseManager.Instance.IsPauseMenuOpen)
            {
                ContainerUI.SetActive(false);
            }
        }
    }
}
