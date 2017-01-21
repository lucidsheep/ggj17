using UnityEngine;
using System.Collections;

public class Engines : MonoBehaviour
{
	public float maxSpeed = 10f;
	public float acceleration = 2f;
	public float turning = 20f;

	Rigidbody2D body;
	// Use this for initialization
	void Start ()
	{
		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		body.velocity = Vector2.ClampMagnitude(body.velocity, maxSpeed);
	}
}

