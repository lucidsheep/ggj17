using UnityEngine;
using System.Collections;

public class Darkness : MonoBehaviour
{
	public GameObject ship;
	public float distanceToFullDarkness = 50f;
	public float fullDarkness = 75f;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		float darkness = Mathf.Min(1f, PlanetList.findClosetSunDistance(ship.transform.position) / distanceToFullDarkness) * fullDarkness;
		Color shade = new Color(0f,0f,0f, (darkness / 100f));
		GetComponent<SpriteRenderer>().color = shade;
	}
}

