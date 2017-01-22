using UnityEngine;
using System.Collections;

public class MCamera : MonoBehaviour
{
	public GameObject thingToTrack;

	public float zoomedInMax = 5f;
	public float zoomedOutMax = 20f;
	public float velocityForMaxZoom = 20f;
	public float velocityPanMultiplier = .1f;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 pos = new Vector3(thingToTrack.transform.position.x, thingToTrack.transform.position.y, transform.position.z);
		pos += new Vector3(thingToTrack.GetComponent<Rigidbody2D>().velocity.x * velocityPanMultiplier, thingToTrack.GetComponent<Rigidbody2D>().velocity.y * velocityPanMultiplier, 0f);
		transform.position = pos;
		//transform.position = new Vector3(thingToTrack.transform.position.x, thingToTrack.transform.position.y, transform.position.z);
		var velocity = thingToTrack.GetComponent<Rigidbody2D>().velocity.magnitude;
		var targetZoom = zoomedInMax + ((velocity / velocityForMaxZoom) * (zoomedOutMax - zoomedInMax));
		var diff = Camera.main.orthographicSize - targetZoom;

		if(diff < 0f)
			Camera.main.orthographicSize += (Mathf.Min(.1f, Mathf.Abs(diff) * Time.deltaTime));
		else
			Camera.main.orthographicSize -= (Mathf.Min(.1f, Mathf.Abs(diff) * Time.deltaTime));
		
	}
}

