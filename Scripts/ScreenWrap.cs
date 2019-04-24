using UnityEngine;
using System.Collections;

public class ScreenWrap : MonoBehaviour {

	bool isWrappingX = false;
	bool isWrappingY = false;
	Renderer renderers;
	public bool wrapped;
	void Start()
	{
		renderers = this.GetComponent<Renderer>();
		
	}
	// Update is called once per frame
	void Update () {
		ScreenWraper ();
	}

	void ScreenWraper()
	{
		bool isVisible = CheckRenderers();
		
		if(isVisible)
		{
			isWrappingX = false;
			isWrappingY = false;
			return;
		}
		
		if(isWrappingX && isWrappingY) {
			return;
		}
		
		Camera cam = Camera.main.GetComponent<Camera>();
		Vector3 viewportPosition = cam.WorldToViewportPoint(this.transform.position);
		Vector3 newPosition = this.transform.position;
		
		if (!isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0))
		{
			newPosition.x = -newPosition.x;
			
			isWrappingX = true;
		}
		
		if (!isWrappingY && (viewportPosition.y > 1 || viewportPosition.y < 0))
		{
			newPosition.y = -newPosition.y;
			
			isWrappingY = true;
		}
		
		this.transform.position = newPosition;
	}

	
	bool CheckRenderers()
	{
		
		// If at least one render is visible, return true
		if(renderers.isVisible)
		{
			//Debug.Log("visible!");
			return true;
		}else{
			if (this.tag == "ai") {
				this.GetComponent<AIControl>().SetState(AIControl.State.manuvering);
			}
			if (this.tag == "player") {
				this.transform.position = new Vector3(0,0,0);
			}
		}
		
		
		// Otherwise, the object is invisible
		return false;
	}
	

}
