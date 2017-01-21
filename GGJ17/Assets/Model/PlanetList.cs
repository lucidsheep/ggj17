using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetList : MonoBehaviour {

	static PlanetList instance;

	List<Planet> allPlanets;

	void Awake() {
		instance = this;
		UpdatePlanetList();
	}

	void UpdatePlanetList() {
		allPlanets = new List<Planet>(Object.FindObjectsOfType<Planet>());
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
}
