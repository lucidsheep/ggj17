using UnityEngine;
using System.Collections;

public class EnergyMeter : MonoBehaviour
{
	public GameObject leftCap;
	public GameObject rightCap;
	public GameObject stretch;
	public GameObject ship;

	EnergyCore core;
	// Use this for initialization
	void Start ()
	{
		core = ship.GetComponent<EnergyCore>();
		leftCap.transform.localPosition = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update ()
	{
		var meterSize = Mathf.Max(.1f, core.GetCurrentEnergy() / 2000f);
		rightCap.transform.localPosition = new Vector3(meterSize, 0f, 0f);
		stretch.transform.localScale = new Vector3(meterSize * 2f, 1f, 1f);
		stretch.transform.localPosition = new Vector3(meterSize / 2.02f, 0f, 0f);
	}
}

