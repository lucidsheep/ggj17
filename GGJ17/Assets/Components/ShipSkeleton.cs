using UnityEngine;
using System.Collections;

public class ShipSkeleton : MonoBehaviour
{
	public SpriteRenderer body;
	public SpriteRenderer guns;
	public SpriteRenderer core;
	public SpriteRenderer engine;

	// Use this for initialization
	void Start ()
	{
		guns.enabled = core.enabled = engine.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void SetShipDamage(bool damaged)
	{
		//todo - damaged ship sprite
	}

	public void ReceiveUpgrade(Upgrade.UpgradeType upgrade)
	{
		switch(upgrade)
		{
			case Upgrade.UpgradeType.CORE: core.enabled = true; break;
			case Upgrade.UpgradeType.ENGINE: engine.enabled = true; break;
			case Upgrade.UpgradeType.WEAPON: guns.enabled = true; break;
			case Upgrade.UpgradeType.HEALTH: SetShipDamage(false); break;
		}
	}
}

