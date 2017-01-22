using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LifeSupport : MonoBehaviour
{
	public float drainPerSecond = 100f;

	EnergyCore core;
	// Use this for initialization
	void Start ()
	{
		core = GetComponent<EnergyCore>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!core.UseEnergy(Mathf.FloorToInt(drainPerSecond * Time.deltaTime)))
			GameOverHandler.SetGameOver(GameOverHandler.GameOverType.energy);
	}
}

