using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour
{
	public static float gameTime = 0f;
	public static int itemsCollected = 0;
	public static int itemsTotal = 10;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		gameTime += Time.deltaTime;
	}
}

