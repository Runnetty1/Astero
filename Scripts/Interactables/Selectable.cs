using UnityEngine;

namespace Assets.Scripts.Interactables
{
    public class Selectable : MonoBehaviour
    {

        public bool isSelected;
        public GameObject selectionObjVisual;

        [SerializeField]
        public Transform SelectedTransform
        {
            get { return this.transform; }
        }

        [SerializeField]
        public bool IsSelectedObject
        {
            get { return this.isSelected; }
            set
            {
                this.isSelected = value;
                if (selectionObjVisual != null)
                {
                    selectionObjVisual.SetActive(value);
                }
            }
        }
    }
}