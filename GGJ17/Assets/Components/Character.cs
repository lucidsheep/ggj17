using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
	public enum expressionType {happy, sad };
	public Sprite happy;
	public Sprite sad;
	public Sprite normal;
	public Sprite scared;

	public float expressionTime = 3f;
	public GameObject ship;

	public static Character instance;
	float timeLeft = 0f;
	Hull hull;
	// Use this for initialization
	void Start ()
	{
		instance = this;
		hull = ship.GetComponent<Hull>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(timeLeft > 0f){
			timeLeft -= Time.deltaTime;
		} else {
			GetComponent<SpriteRenderer>().sprite = hull.GetHP() > 2 ? normal : sad;
		}
	}

	public static void SetExpression(expressionType type)
	{
		Sprite expressionSprite;
		switch(type)
		{
			case expressionType.happy: expressionSprite = instance.happy; break;
			case expressionType.sad: expressionSprite = instance.sad; break;
			default: expressionSprite = instance.normal; break;
		}

		instance.timeLeft = instance.expressionTime;
		instance.GetComponent<SpriteRenderer>().sprite = expressionSprite;
	}
}

