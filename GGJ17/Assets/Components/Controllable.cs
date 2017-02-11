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
		var leftHeld = Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < -.9;
		var rightHeld = Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > .9f;
		if(leftHeld && !rightHeld)
			engine.TurnShip(false);
		else if(!leftHeld && rightHeld)
			engine.TurnShip(true);

		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Joystick1Button16)) {
			engine.EngageEngines();
		} else if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Joystick1Button16))
		{
			engine.StopEngines();
		}

		if(Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Joystick1Button17))
		{
			GetComponent<Weapons>().ShootWeapons();
		}
	}
}
