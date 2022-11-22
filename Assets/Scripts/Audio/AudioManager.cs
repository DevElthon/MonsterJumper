using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
	public AudioSource fxSource;
	public AudioSource trackSource;

	public static AudioManager Instance = null;

	[Header("Efeitos sonoros")]
	public AudioClip[] sfx;

	[Header("Trilhas Sonoras")]
	public AudioClip[] tracks;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}

		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

    public void Play(AudioClip clip)
	{
		fxSource.clip = clip;
		fxSource.Play();
	}

	public void PlayMusic(AudioClip clip)
	{
		trackSource.clip = clip;
		trackSource.Play();
	}
}