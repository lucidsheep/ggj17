using UnityEngine;
using System.Collections;

public class Compass : MonoBehaviour
{
	public GameObject player;
	public GameObject home;
	public TextMesh distanceTxt;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 diff = home.transform.position - player.transform.position;
		float dist = diff.magnitude;
		diff.Normalize();
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
		distanceTxt.text = Mathf.FloorToInt(dist) + "m";
	}
}

