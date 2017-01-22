using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public float speed = 5f;
	public int damage = 1;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		GetComponent<Rigidbody2D>().angularVelocity = 0f;
		float angle = transform.eulerAngles.magnitude * Mathf.Deg2Rad;
		Vector2 force = new Vector2(speed * Mathf.Cos (angle), speed * Mathf.Sin (angle));
		//transform.TransformDirection(Vector3.forward);
		GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
		
		if(GetComponent<Rigidbody2D>().velocity.magnitude > speed) {
			GetComponent<Rigidbody2D>().velocity = Vector2.ClampMagnitude(GetComponent<Rigidbody2D>().velocity, speed);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.GetComponent<ShipSkeleton>() == null)
		{
			Destroy(this.gameObject);
		}
	}
}

