using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GravityInfluence : MonoBehaviour
{
	public float timeToUpdatePlanets = 2f;

	List<Planet> closestPlanets;
	Rigidbody2D body;

	float nextUpdate;
	// Use this for initialization
	void Start ()
	{
		nextUpdate = timeToUpdatePlanets;
		body = GetComponent<Rigidbody2D>();
		closestPlanets = new List<Planet>();
		UpdatePlanets();
	}
	
	// Update is called once per frame
	void Update ()
	{
		nextUpdate -= Time.deltaTime;
		if(nextUpdate <= 0f) {
			nextUpdate += timeToUpdatePlanets;
			UpdatePlanets();
		}

		foreach(Planet p in closestPlanets)
		{
			var vec = p.transform.position - transform.position; // - p.transform.position;
			var strength = (1f / vec.magnitude) * (p.GetComponent<Rigidbody2D>().mass / 500f);
			vec.Normalize();
			body.AddForce(vec * strength, ForceMode2D.Force);
		}
	}

	void UpdatePlanets()
	{
		closestPlanets = PlanetList.findClosestPlanets(transform.position, 3);
	}
}

