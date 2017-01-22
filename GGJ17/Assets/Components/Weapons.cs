using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour
{
	public Bullet bullet;
	public GameObject[] cannons;
	public float cooldown = 1f;
	public int energyPerShot = 100;

	float cooldownRemaining = 0f;
	bool armed = false;
	EnergyCore core;
	// Use this for initialization
	void Start ()
	{
		core = GetComponent<EnergyCore>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(cooldownRemaining > 0f)
			cooldownRemaining -= Time.deltaTime;
	}

	public void ShootWeapons()
	{
		if(armed && cooldownRemaining <= 0f && core.UseEnergy(energyPerShot))
		{
			cooldownRemaining = cooldown;
			foreach(GameObject c in cannons)
			{
				Instantiate(bullet, c.transform.position, transform.rotation);
			}
		}
	}

	public void LevelUp()
	{
		armed = true;
	}
}

