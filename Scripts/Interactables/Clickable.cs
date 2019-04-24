using UnityEngine;
using System.Collections;

public class Clickable : Selectable {
	public bool isClickable;

	[SerializeField]
	public bool isClickableObject
	{
		get {return isClickable; }
		set {isClickable = value; }
	}
}
