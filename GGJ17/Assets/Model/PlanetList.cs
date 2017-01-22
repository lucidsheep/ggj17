using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetList : MonoBehaviour {

	static PlanetList instance;

	List<Planet> allPlanets;
	List<Planet> allSuns;

	void Awake() {
		instance = this;
		UpdatePlanetList();
	}

	void UpdatePlanetList() {
		allPlanets = new List<Planet>(Object.FindObjectsOfType<Planet>());
		allSuns = new List<Planet>();
		foreach(Planet p in allPlanets)
		{
			if(p.GetComponent<Sun>() != null)
			{
				allSuns.Add(p);
			}
		}
	}

	public static List<Planet> findClosestPlanets(Vector3 pos, int numToFind)
	{
		List<Tuple<float, Planet>> planets = new List<Tuple<float, Planet>>();

		foreach(Planet p in instance.allPlanets)
		{
			planets.Add(new Tuple<float, Planet>(Vector3.Distance(pos, p.transform.position), p));
		}

		planets.Sort(delegate( Tuple<float, Planet> a, Tuple<float, Planet> b) {
			return a.First.CompareTo(b.First);
		});

		List<Planet> ret = new List<Planet>();
		while(numToFind > 0 && planets.Count > 0){
			ret.Add(planets[0].Second);
			planets.RemoveAt(0);
		}
		return ret;
	}	

	public static float findClosetSunDistance(Vector3 pos)
	{
		float closest = 10000f;
		foreach(Planet p in instance.allSuns)
		{
			var distance = Vector3.Distance(p.transform.position, pos);
			if(distance < closest)
				closest = distance;
		}
		return closest;
	}	
}
