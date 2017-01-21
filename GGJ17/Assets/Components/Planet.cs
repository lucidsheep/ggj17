using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{
	public float gravityPullDistance = 5f;
	public float gravityStrength = 5f;
	public int collisionDamage = 1;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.GetComponent<Hull>() != null)
			collision.gameObject.GetComponent<Hull>().TakeDamage(collisionDamage);
	}
}

