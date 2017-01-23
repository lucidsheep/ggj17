using UnityEngine;
using System.Collections;
using DG.Tweening;

public class GreenGlow : MonoBehaviour
{
	public Color glow = Color.green;

	SpriteRenderer sprite;
	Tween t;
	bool active = false;
	// Use this for initialization
	void Awake ()
	{
		sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!active)
			sprite.color = Color.white;
	}

	public void StartGlow()
	{
		t = DOTween.To(() => sprite.color, x => sprite.color = x, glow, .25f).SetLoops(-1, LoopType.Yoyo);
		active = true;
	}

	public void StopGlow()
	{
		if(t != null)
			t.Complete();
		sprite.color = Color.white;
		active = false;
	}
}

