using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
	public TextMesh txt;
	// Use this for initialization
	void Start ()
	{
		txt.text = "Clear Time\n" + FormatTime(GameData.gameTime) + "\n\nCollection %\n" + itemsPercent();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.anyKeyDown)
			SceneManager.LoadScene("main");
	}

	public static string FormatTime(float totalSeconds) {
		bool hasHours = totalSeconds >= 3600f;
		string hours = (hasHours ? Mathf.FloorToInt (totalSeconds / 3600f).ToString() + ":" : "");
		totalSeconds = Mathf.FloorToInt(totalSeconds) % 3600;
		string minutes = Mathf.FloorToInt (totalSeconds / 60f).ToString() + ":";
		minutes = (hasHours && minutes.Length == 2 ? "0" : "") + minutes;
		totalSeconds = Mathf.FloorToInt(totalSeconds) % 60;
		string seconds = (totalSeconds < 10 ? "0" : "") + totalSeconds.ToString();
		return hours + minutes + seconds;
	}

	string itemsPercent()
	{
		return Mathf.FloorToInt(((float)GameData.itemsCollected / (float)GameData.itemsTotal) * 100f) + "%";
	}
}

