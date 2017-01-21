using UnityEngine;
using System.Collections;

public class ShipUI : MonoBehaviour
{
	public TextMesh debugUI;
	public GameObject ship;

	EnergyCore core;
	Hull hull;
	// Use this for initialization
	void Start ()
	{
		core = ship.GetComponent<EnergyCore>();
		hull = ship.GetComponent<Hull>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		debugUI.text = "Energy: " + core.GetCurrentEnergy() + " / " + core.maxEnergy + "\n" +
						"Hull: " + hull.GetHP() + " / " + hull.maxHP;
	}
}

