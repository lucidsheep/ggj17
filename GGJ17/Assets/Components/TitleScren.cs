using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TitleScren : MonoBehaviour
{
	public GameObject selector;
	public SpriteRenderer credits;

	public float startPos;
	public float creditsPos;

	bool creditsSelected = false;
	bool creditsActive = false;


	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	 if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)){
	 	creditsSelected = !creditsSelected;
	 	selector.transform.DOMoveY(creditsSelected ? creditsPos : startPos, .25f).SetEase(Ease.OutBack);
	 }
	 if(Input.GetKeyDown(KeyCode.Space))
	 {
	 	if(creditsActive)
	 		ToggleCreditsActive();
	 	else if(creditsSelected)
	 		ToggleCreditsActive();
	 	else
	 		SceneManager.LoadScene("main");
	 }
	}

	void ToggleCreditsActive()
	{
		creditsActive = !creditsActive;
		DOTween.To(() => credits.color, x => credits.color = x, new Color(1f,1f,1f, creditsActive ? 1f : 0f), 1f);
	}
}

