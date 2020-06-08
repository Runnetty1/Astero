using UnityEngine;

namespace Assets.Scripts.Interactables
{
    public class Clickable : Selectable
    {
        public bool isClickable;

        [SerializeField]
        public bool IsClickableObject
        {
            get { return isClickable; }
            set { isClickable = value; }
        }

        private void OnMouseDown()
        {
            if (!isClickable)
            {
                return;
            }
        }
    }
}