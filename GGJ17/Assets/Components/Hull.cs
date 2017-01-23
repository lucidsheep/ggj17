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
		currentHP -= damage;
		if(damage > 0){
			invincibleTimeLeft = invincibilityTime;
			Character.SetExpression(Character.expressionType.scared);
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

