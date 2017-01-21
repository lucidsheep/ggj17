using UnityEngine;
using System.Collections;

public class ShipUI : MonoBehaviour
{
	public TextMesh debugUI;
	public GameObject ship;

	EnergyCore core;
	// Use this for initialization
	void Start ()
	{
		core = ship.GetComponent<EnergyCore>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		debugUI.text = "Energy: " + core.GetCurrentEnergy() + " / " + core.maxEnergy;
	}
}

