using UnityEngine;
using System.Collections;
using DG.Tweening;

public class WaveAnim : MonoBehaviour
{
	public Color color;
	SpriteRenderer sr;
    public float startScale = 1f;
    public float size = 10f;

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
		transform.DOScale(size, animTime).SetEase(Ease.OutQuad);
		DOTween.To(() => sr.color, x => sr.color = x, new Color(color.r, color.g, color.b, 0f), animTime);
		StartCoroutine("resetAnim");
	}

	public IEnumerator resetAnim()
	{
		yield return new WaitForSeconds(5f);

        transform.localScale = new Vector3(startScale, startScale, startScale);
		sr.color = color;
		doAnim();
	}
}

