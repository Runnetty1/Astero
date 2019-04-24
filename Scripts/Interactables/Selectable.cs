using UnityEngine;
using System.Collections;

public class Selectable : MonoBehaviour {

	private Transform selectedObject;
	public bool isSelected;
    public GameObject selectionObjVisual;

	[SerializeField]
	public Transform selectedTransform
	{
		get {return this.selectedObject; }
		set {this.selectedObject = value; }
	}

	[SerializeField]
	public bool isSelectedObject
	{
		get {return this.isSelected; }
		set {this.isSelected = value;
            if (selectionObjVisual != null)
            {
                selectionObjVisual.SetActive(value);
            }
        }
	}
		



}
