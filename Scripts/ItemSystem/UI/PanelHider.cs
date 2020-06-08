
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.ItemSystem.UI
{
    public class PanelHider : MonoBehaviour, IPointerExitHandler
    {
        public Transform[] subHiders;
        public void OnPointerExit(PointerEventData eventData)
        {
            foreach (Transform hider in subHiders)
            {
                hider.gameObject.SetActive(false);
            }
            gameObject.SetActive(false);
        }
    }
}