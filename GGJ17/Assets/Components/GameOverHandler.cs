using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
	public enum GameOverType { sun, crash, energy, misc, blackhole }

	public static GameOverHandler instance;

	bool isGameOver = false;
	GameOverType type;
	// Use this for initialization
	void Start ()
	{
		instance = this;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public static void SetGameOver(GameOverType type)
	{
		if(instance.isGameOver)
			return;
		instance.isGameOver = true;
		instance.type = type;
		DOTween.To( () => instance.GetComponent<SpriteRenderer>().color, x => instance.GetComponent<SpriteRenderer>().color = x, new Color(0f, 0f, 0f, 1f), 3f)
		.OnComplete( () => FinishFade());
	}

	public static void FinishFade()
	{
		switch(instance.type)
		{
			case GameOverType.crash: SceneManager.LoadScene("GameOver_Crash"); break;
			case GameOverType.energy: SceneManager.LoadScene("GameOver_Generic"); break;
			case GameOverType.misc: SceneManager.LoadScene("GameOver_Generic"); break;
			case GameOverType.sun: SceneManager.LoadScene("GameOver_Sun"); break;
			case GameOverType.blackhole: SceneManager.LoadScene("GameOver_BlackHole"); break;
		}
	}
}

