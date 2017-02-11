using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour
{
	public static float gameTime = 0f;
	public static int itemsCollected = 0;
	public static int itemsTotal = 15;
	// Use this for initialization
	void Start ()
	{
        itemsCollected = 0;
        gameTime = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		gameTime += Time.deltaTime;
	}
}

