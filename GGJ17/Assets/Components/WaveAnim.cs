using UnityEngine;
using System.Collections;
using DG.Tweening;

public class WaveAnim : MonoBehaviour
{
	public Color color;
	SpriteRenderer sr;

	// Use this for initialization
	void Start ()
	{
		sr = GetComponent<SpriteRenderer>();
		doAnim();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void doAnim()
	{
		float animTime = 5f;
		transform.DOScale(10f, animTime).SetEase(Ease.OutQuad);
		DOTween.To(() => sr.color, x => sr.color = x, new Color(color.r, color.g, color.b, 0f), animTime);
		StartCoroutine("resetAnim");
	}

	public IEnumerator resetAnim()
	{
		yield return new WaitForSeconds(5f);

		transform.localScale = Vector3.one;
		sr.color = color;
		doAnim();
	}
}

