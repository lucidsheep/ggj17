using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{
	public Sprite[] asteroidOptions;
	public float[] asteroidScales;
	public int collisionDamage = 1;
	public float minRotation;
	public float maxRotation;
	public bool isMoving;
	public float minSpeed;
	public float maxSpeed;
	public int hitPoints = 5;
	// Use this for initialization
	void Start ()
	{
		var randIndex = Random.Range(0, asteroidOptions.Length);
		GetComponent<SpriteRenderer>().sprite = asteroidOptions[randIndex];
		transform.Rotate(new Vector3(0f,0f, Random.Range(minRotation, maxRotation)));
		GetComponent<Rigidbody2D>().angularVelocity = Random.Range(minRotation, maxRotation);
		if(isMoving)
			GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle * Random.Range(minSpeed, maxSpeed);
		GetComponent<CircleCollider2D>().radius = asteroidScales[randIndex]; 
	}
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.GetComponent<Hull>() != null)
			collision.gameObject.GetComponent<Hull>().TakeDamage(collisionDamage);
		else if(collision.gameObject.GetComponent<Bullet>() != null)
		{
			hitPoints -= collision.gameObject.GetComponent<Bullet>().damage;
			if(hitPoints <= 0)
				Destroy(gameObject);
		}
	}
}

