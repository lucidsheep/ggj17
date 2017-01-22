using UnityEngine;
using System.Collections;

public class EdgeAnchor : MonoBehaviour {

	public int horAnchor = 0; //0 = left edge, 1 = right edge, 2 = up edge, 3 = down edge
	public int vertAnchor = 0;
	public float horOffset = 0f;
	public float vertOffset = 0f;
	// Use this for initialization
	void Update () {
		Vector3 newPos = transform.localPosition;
		if(horAnchor >= 0) {
			float size = ((Camera.main.orthographicSize * 2) * Camera.main.aspect) / 2;
			newPos.x = horAnchor == 0 ? -size + horOffset : size - horOffset;
		} 
		if(vertAnchor >= 0) {
			float size = Camera.main.orthographicSize;
			newPos.y = vertAnchor == 0 ? size - vertOffset : -size + vertOffset;
		}
		transform.localPosition = newPos;
	}

}
