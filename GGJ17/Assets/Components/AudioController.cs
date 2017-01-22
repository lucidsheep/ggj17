using UnityEngine;
using System.Collections;
using DG.Tweening;

public class AudioController : MonoBehaviour
{

	public AudioClip chillMusic;
	public AudioClip actionMusic;

	public AudioClip explosion;
	public AudioClip laser;
	public AudioClip upgradeBeep;
	public AudioClip restore;
	public AudioClip alarm;

	public AudioSource[] sfxChannels;
	public AudioSource musicChannel;

	public static AudioController instance;

	int nextSfxChannel = 0;

	// Use this for initialization
	void Start ()
	{
		instance = this;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public static void PlaySFX(AudioClip sfx)
	{
		AudioSource sfxChannel = instance.sfxChannels[instance.nextSfxChannel];
		sfxChannel.clip = sfx;
		sfxChannel.Play();

		instance.nextSfxChannel++;
		if(instance.nextSfxChannel >= instance.sfxChannels.Length)
			instance.nextSfxChannel = 0;
	}

	public static void SwitchToActionTrack()
	{
		DOTween.Sequence().
			Append(DOTween.To(() => instance.musicChannel.volume, x => instance.musicChannel.volume = x, 0f, 3f))
			.AppendCallback( () => { instance.musicChannel.Stop(); instance.musicChannel.clip = instance.actionMusic; FadeIn(); });
	}

	static void FadeIn()
	{
		instance.musicChannel.Play();
		DOTween.To(() => instance.musicChannel.volume, x => instance.musicChannel.volume = x, 100f, 3f);
	}
}

