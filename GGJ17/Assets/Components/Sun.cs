using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour
{

	public float solarRadius = 10f;
	public float solarEnergy = 10f;
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
		var distance = Vector3.Distance(transform.position, ship.transform.position);
		if(distance < solarRadius)
		{
			core.GetEnergy(Mathf.FloorToInt((1f - (distance / solarRadius)) * solarEnergy));
		}
	}
}

