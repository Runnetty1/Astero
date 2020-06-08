using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class SelectionLine : MonoBehaviour {
	public Color c1 = Color.green;
	public Color c2 = Color.green;
	public float radius;
    public float rotOffset;
	public float lenghtAround;
	public int lengthOfLineRenderer = 50;
	public bool run;
    public Transform Parent;
    void Start() {
		this.run = true;
        Parent=transform.parent;
        radius = transform.localPosition.x;
    }
	void Update() {
		if (run) {
			LineRenderer lineRenderer = GetComponent<LineRenderer> ();
			Vector3[] points = new Vector3[lengthOfLineRenderer];
			//float t = Time.time;
			int i = 0;
			while (i < lengthOfLineRenderer) {
                float angle = (((i * Mathf.PI) * 2) / lengthOfLineRenderer)+((Parent.localRotation.eulerAngles.z) / lengthOfLineRenderer);

                points [i] = new Vector3 (Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0) + this.Parent.transform.localPosition;
				i++;
			}
            lineRenderer.widthMultiplier = Camera.main.orthographicSize/200;
			lineRenderer.SetPositions (points);
		}
	}
}
