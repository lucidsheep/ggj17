using UnityEngine;
using System.Collections;

public class Hull : MonoBehaviour
{
	public int maxHP;
	public float invincibilityTime = 5f;

	public int levelUpHP;

	int currentHP;
	float invincibleTimeLeft;
	// Use this for initialization
	void Start ()
	{
		currentHP = maxHP;
	}
	
	// Update is called once per frame
	void Update()
	{
		if(invincibleTimeLeft > 0f)
			invincibleTimeLeft -= Time.deltaTime;
	}
	public void TakeDamage(int damage)
	{
		if(invincibleTimeLeft > 0f)
			return;
		currentHP -= damage;
		invincibleTimeLeft = invincibilityTime;
		if(currentHP <= 0){
			//todo - end of game stuff
		}
	}

	public void Repair(int repairAmount)
	{
		currentHP = Mathf.Min(currentHP + repairAmount, maxHP);
	}

	public int GetHP()
	{
		return currentHP;
	}

	public void LevelUp()
	{
		maxHP += levelUpHP;
		currentHP = maxHP;
	}
}

