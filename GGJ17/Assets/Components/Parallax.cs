using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{
	GameObject ship;

	public float multiplier = .98f;

	Vector3 startPos;
	// Use this for initialization
	void Start ()
	{
		startPos = transform.position;
		ship = Object.FindObjectOfType<ShipSkeleton>().gameObject;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = ship.transform.position * multiplier + startPos;
	}
}

