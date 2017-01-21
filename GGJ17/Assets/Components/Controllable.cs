using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllable : MonoBehaviour {

	Engines engine;
	void Start () {
		engine = GetComponent<Engines>();
	}
	
	void Update () {
		GetComponent<Rigidbody2D>().angularVelocity = 0f;
		var leftHeld = Input.GetKey(KeyCode.LeftArrow);
		var rightHeld = Input.GetKey(KeyCode.RightArrow);
		if(leftHeld && !rightHeld)
			transform.Rotate(new Vector3(0f, 0f, engine.turning * Time.deltaTime));
		else if(!leftHeld && rightHeld)
			transform.Rotate(new Vector3(0f, 0f, -engine.turning * Time.deltaTime));

		if(Input.GetKey(KeyCode.Space)) {
			float angle = transform.eulerAngles.magnitude * Mathf.Deg2Rad;
			float acceleration = engine.acceleration * Time.deltaTime;
			Vector2 force = new Vector2(acceleration * Mathf.Cos (angle), acceleration * Mathf.Sin (angle));
			transform.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Force);
		}
	}
}
