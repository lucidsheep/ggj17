using UnityEngine;
using System.Collections;

public class Flashy : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		GetComponent<SpriteRenderer>().material.SetColor("Tint", Color.white);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

