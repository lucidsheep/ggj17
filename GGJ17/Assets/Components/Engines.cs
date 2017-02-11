using UnityEngine;
using System.Collections;

public class Engines : MonoBehaviour
{
	public float maxSpeed = 10f;
	public float acceleration = 2f;
	public float turning = 20f;

	public float levelUpMaxSpeed = 100f;
	public float levelUpAcceleration = 100f;
	public float levelUpTurning = 10f;

	public int turnEnergyCost = 1;
	public int boostEnergyCost = 1;

	public GameObject[] engineTrails;

	Rigidbody2D body;
	EnergyCore core;
	// Use this for initialization
	void Start ()
	{
		body = GetComponent<Rigidbody2D>();
		core = GetComponent<EnergyCore>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		body.velocity = Vector2.ClampMagnitude(body.velocity, maxSpeed);
	}

	public void LevelUp()
	{
		maxSpeed += levelUpMaxSpeed;
		acceleration += levelUpAcceleration;
		turning += levelUpTurning;
        Dialog.SetTxt("Engines upgraded!\nShip speed and acceleration improved.");
	}

	public void TurnShip(bool turnRight)
	{
		if(!core.UseEnergy(turnEnergyCost))
			return;

		transform.Rotate(new Vector3(0f, 0f, turning * Time.deltaTime * (turnRight ? -1f : 1f)));

	}

	public void EngageEngines()
	{
		if(!core.UseEnergy(boostEnergyCost))
			return;
		float angle = transform.eulerAngles.magnitude * Mathf.Deg2Rad;
		float accelerationDelta = acceleration * Time.deltaTime;
		Vector2 force = new Vector2(accelerationDelta * Mathf.Cos (angle), accelerationDelta * Mathf.Sin (angle));
		transform.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Force);
		foreach(GameObject g in engineTrails)
		{
			g.GetComponent<ParticleSystem>().Play();// = true;
		}
	}

	public void StopEngines()
	{
		foreach(GameObject g in engineTrails)
		{
			g.GetComponent<ParticleSystem>().Stop();
		}
	}
}

