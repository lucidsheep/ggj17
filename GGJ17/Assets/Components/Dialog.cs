using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Dialog : MonoBehaviour
{
	public TextMesh txt;
	public float visiblePos;
	public float hiddenPos;
	public float txtDisplayTime;

	public static Dialog instance;
	// Use this for initialization
	void Awake ()
	{
		instance = this;
	}

	void Start()
	{
		SetTxt("I need to stay close to the sun\nto keep the ship fueled.\nLet's try to get home...");
	}
	// Update is called once per frame
	void Update ()
	{
	
	}

	public static void SetTxt(string text)
	{
		instance.txt.text = text;
		DOTween.Sequence()
		.Append(instance.transform.DOLocalMoveY(instance.visiblePos, 1f).SetEase(Ease.OutBack))
		.AppendInterval(instance.txtDisplayTime)
		.Append(instance.transform.DOLocalMoveY(instance.hiddenPos, 1f).SetEase(Ease.InBack));
	}


}

