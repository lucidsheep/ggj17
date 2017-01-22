using UnityEngine;
using System.Collections;

public class ShipUI : MonoBehaviour
{
	public TextMesh debugUI;
	public GameObject ship;

	EnergyCore core;
	Hull hull;
	float startingZoom;
	// Use this for initialization
	void Start ()
	{
		core = ship.GetComponent<EnergyCore>();
		hull = ship.GetComponent<Hull>();
		startingZoom = Camera.main.orthographicSize;
	}
	
	// Update is called once per frame
	void Update ()
	{
		debugUI.text = "Energy: "  +  "\n" +
						"Hull: ";
		var zoom = .2f * (Camera.main.orthographicSize / startingZoom);
		debugUI.transform.localScale = new Vector3(zoom, zoom, 1f);
	}
}

