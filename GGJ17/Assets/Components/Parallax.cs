using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{
	GameObject ship;

	public float multiplier = .98f;

	float xBound = 500f;
	float yBound = 500f;

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
		Vector3 pos = ship.transform.position;
		//todo - math is hard
		//goal is to stop bg from moving after reaching bounds
//		if(pos.x < 0)
//			pos.x = startPos + pos.x;
//		else if(pos.x * multiplier > xBound) {
//			var unscaledX = xBound * multiplier + startPos; 
//			pos.x = unscaledX
//		}
		transform.position = ship.transform.position * multiplier + startPos;
	}
}

