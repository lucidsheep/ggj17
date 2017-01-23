﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
		bool wasCritical = currentHP < 3;
		currentHP -= damage;
		bool isCritical = currentHP < 3;
		if(damage > 0){
			invincibleTimeLeft = invincibilityTime;
			Character.SetExpression(Character.expressionType.scared);
			if(!wasCritical && isCritical)
				Dialog.SetTxt("Hull integrity critical!\nI need to find a repair module...");
		}
		if(currentHP <= 0){
			if(damage > 200)
				GameOverHandler.SetGameOver(GameOverHandler.GameOverType.blackhole);
			else if(damage > 10)
				GameOverHandler.SetGameOver(GameOverHandler.GameOverType.sun);
			else
				GameOverHandler.SetGameOver(GameOverHandler.GameOverType.crash);
		}
	}

	public void Repair(int repairAmount)
	{
		currentHP = Mathf.Min(currentHP + repairAmount, maxHP);
		Dialog.SetTxt("Repair drones deployed!\nShip is fully operational.");
	}

	public int GetHP()
	{
		return currentHP;
	}

	public void LevelUp()
	{
		maxHP += levelUpHP;
		currentHP = maxHP;
		Dialog.SetTxt("Armor upgraded!\nThe ship can take more\nhits now.");
	}
}

