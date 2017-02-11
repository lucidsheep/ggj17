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
		var leftHeld = Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < -0.25f;
		var rightHeld = Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > .25f;
		if(leftHeld && !rightHeld)
			engine.TurnShip(false);
		else if(!leftHeld && rightHeld)
			engine.TurnShip(true);

		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Joystick1Button0)) {
			engine.EngageEngines();
		} else if(Input.GetKeyUp(KeyCode.UpArrow))
		{
			engine.StopEngines();
		}

		if(Input.GetKeyDown(KeyCode.Space))
		{
			GetComponent<Weapons>().ShootWeapons();
		}
	}
}
