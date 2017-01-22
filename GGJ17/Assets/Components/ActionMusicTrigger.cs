using UnityEngine;
using System.Collections;

public class ActionMusicTrigger : MonoBehaviour
{
	public GameObject ship;

	bool hasTriggered = false;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!hasTriggered && ship.transform.position.x > 250f && ship.transform.position.y > 250f){
			hasTriggered = true;
			AudioController.SwitchToActionTrack();
		}
	}
}

