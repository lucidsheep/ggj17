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
			engine.TurnShip(false);
		else if(!leftHeld && rightHeld)
			engine.TurnShip(true);

		if(Input.GetKey(KeyCode.Space)) {
			engine.EngageEngines();
		}
	}
}
