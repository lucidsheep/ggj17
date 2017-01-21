using UnityEngine;
using System.Collections;

public class MCamera : MonoBehaviour
{
	public GameObject thingToTrack;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = new Vector3(thingToTrack.transform.position.x, thingToTrack.transform.position.y, transform.position.z);
	}
}

