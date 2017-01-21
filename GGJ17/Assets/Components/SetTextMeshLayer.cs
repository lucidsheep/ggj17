using UnityEngine;
using System.Collections;

public class SetTextMeshLayer : MonoBehaviour {

	public string layerName;

	// Use this for initialization
	void Start () {
		if(GetComponent<MeshRenderer>() != null)
			GetComponent<MeshRenderer>().sortingLayerName = layerName;
		else if(GetComponentInChildren<MeshRenderer>() != null)
			GetComponentInChildren<MeshRenderer>().sortingLayerName = layerName;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
