using UnityEngine;
using System.Collections;

public class Upgrade : MonoBehaviour
{
	public enum UpgradeType { ENGINE, CORE, WEAPON, HEALTH }

	public UpgradeType type;
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
		if(collision.gameObject.GetComponent<ShipSkeleton>() == null)
			return;

		collision.gameObject.GetComponent<ShipSkeleton>().ReceiveUpgrade(type);
		switch(type)
		{
			case UpgradeType.CORE: collision.gameObject.GetComponent<EnergyCore>().LevelUp(); break;
			case UpgradeType.ENGINE: collision.gameObject.GetComponent<Engines>().LevelUp(); break;
			case UpgradeType.HEALTH: collision.gameObject.GetComponent<Hull>().Repair(9999); break;
			case UpgradeType.WEAPON: break; //todo
		}

		Destroy(this.gameObject);
	}
}

