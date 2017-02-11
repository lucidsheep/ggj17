using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{
	public float gravityPullDistance = 5f;
	public float gravityStrength = 5f;
	public int collisionDamage = 1;
	public Sprite[] planetOptions;
	public bool useRandomPlanet = true;
	// Use this for initialization
	void Start ()
	{
		if(useRandomPlanet)
			GetComponent<SpriteRenderer>().sprite = planetOptions[Random.Range(0, planetOptions.Length)];
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		var isSunOrBlackHole = collisionDamage > 1;
		var isSun = isSunOrBlackHole && GetComponent<Sun>() != null;
		var damageType = isSun ? Hull.DamageType.SUN : (isSunOrBlackHole ? Hull.DamageType.BLACKHOLE : Hull.DamageType.OTHER);
		if(collision.gameObject.GetComponent<Hull>() != null){
			collision.gameObject.GetComponent<Hull>().TakeDamage(collisionDamage, damageType);
			AudioController.PlaySFX(AudioController.instance.explosion);
		}
	}
}

