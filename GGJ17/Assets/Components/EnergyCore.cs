using UnityEngine;
using System.Collections;

public class EnergyCore : MonoBehaviour
{
	public int maxEnergy;
	public int levelUpEnergy;

	int currentEnergy;

	// Use this for initialization
	void Start ()
	{
		currentEnergy = maxEnergy;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public bool UseEnergy(int amount)
	{
		if(currentEnergy - amount >= 0){
			currentEnergy -= amount;
			return true;
		}
		else {
			return false;
		}
			
	}

	public int GetCurrentEnergy() { return currentEnergy; }
	public void LevelUp()
	{
		maxEnergy += levelUpEnergy;
		currentEnergy = maxEnergy;
	}

	public void GetEnergy(int amount)
	{
		currentEnergy = Mathf.Min(currentEnergy + amount, maxEnergy);
	}
}

