using UnityEngine;
using System.Collections;

public class EnergyCore : MonoBehaviour
{
	public int maxEnergy;
	public int levelUpEnergy;

	int currentEnergy;
	float rechargeSFXCooldown = 0f;
	bool isEnergyCritical = false;

	// Use this for initialization
	void Start ()
	{
		currentEnergy = maxEnergy;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(rechargeSFXCooldown > 0f)
			rechargeSFXCooldown -= Time.deltaTime;
	}

	public bool UseEnergy(int amount)
	{
		if(currentEnergy - amount >= 0){
			currentEnergy -= amount;
			if(!isEnergyCritical && CheckIsEnergyCritical()){
				isEnergyCritical = true;
				AudioController.PlaySFX(AudioController.instance.alarm);
				Dialog.SetTxt("Energy reserves are low!\nGet close to a sun to\nrestore energy");
			}
			return true;
		}
		else {
			return false;
		}
			
	}

	public bool CheckIsEnergyCritical()
	{
		return ((float)currentEnergy / (float)maxEnergy) < .2f;
	}
	public int GetCurrentEnergy() { return currentEnergy; }
	public void LevelUp()
	{
		maxEnergy += levelUpEnergy;
		currentEnergy = maxEnergy;
		Dialog.SetTxt("Energy core upgraded!\nThe ship can hold more\nenergy now.");
	}

	public void GetEnergy(int amount)
	{
		currentEnergy = Mathf.Min(currentEnergy + amount, maxEnergy);
		if(rechargeSFXCooldown <= 0f) {
			AudioController.PlaySFX(AudioController.instance.restore);
			rechargeSFXCooldown = 1f;
		}
		if(isEnergyCritical && !CheckIsEnergyCritical())
			isEnergyCritical = false;
	}
}

