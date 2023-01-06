using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
	private float trackvolume, fxvolume;

	private AudioManager audiomanagerInstance;

	[SerializeField]
	private GameObject desactivedsfx, desactivedtrack;

	private void Start()
	{
		audiomanagerInstance = AudioManager.Instance;
		if(PlayerPrefs.GetFloat("fxVolume") != 0f && PlayerPrefs.GetFloat("trackVolume") != 0)
        {
			PlayerPrefs.SetFloat("fxVolume", 0.7f);
			PlayerPrefs.SetFloat("trackVolume", 0.5f);
		}

		if (!PlayerPrefs.HasKey("trackVolume"))
		{
			PlayerPrefs.SetFloat("trackVolume", 0.5f);
			LoadTrack();
		}
		else
		{
			LoadTrack();
		}

		if (!PlayerPrefs.HasKey("fxVolume"))
		{
			PlayerPrefs.SetFloat("fxVolume", 0.7f);
			LoadFx();
		}
		else
		{
			LoadFx();
		}
	}

    private void Update()
    {
        if(fxvolume == 0 && desactivedsfx.activeSelf == false)
			desactivedsfx.SetActive(true);

		else if(fxvolume == 0.7f && desactivedsfx.activeSelf == true)
			desactivedsfx.SetActive(false);

		if(trackvolume == 0 && desactivedtrack.activeSelf == false)
			desactivedtrack.SetActive(true);

		else if(trackvolume == 0.5f && desactivedtrack.activeSelf == true)
			desactivedtrack.SetActive(false);
	}

	//track section
    public void ChangeTrackVolume()
	{
		if (trackvolume == 0.5f)
		{
			trackvolume = 0;
			audiomanagerInstance.trackSource.volume = trackvolume;
		}
		else if (trackvolume == 0)
		{
			trackvolume = 0.5f;
			audiomanagerInstance.trackSource.volume = trackvolume;
		}
		SaveTrack();
	}

	private void LoadTrack()
	{
		trackvolume = PlayerPrefs.GetFloat("trackVolume");
		audiomanagerInstance.trackSource.volume = trackvolume;
	}

	private void SaveTrack()
	{
		PlayerPrefs.SetFloat("trackVolume", trackvolume);
	}

	//Fx section
	public void ChangeFxVolume()
	{
		if (fxvolume == 0.7f)
		{
			fxvolume = 0;
			
			audiomanagerInstance.fxSource.volume = fxvolume;
		}
		else if (fxvolume == 0)
		{
			fxvolume = 0.7f;
			audiomanagerInstance.fxSource.volume = fxvolume;
		}
		SaveFx();
	}
	private void LoadFx()
	{
		fxvolume = PlayerPrefs.GetFloat("fxVolume");
		audiomanagerInstance.fxSource.volume = fxvolume;
	}

	private void SaveFx()
	{
		PlayerPrefs.SetFloat("fxVolume", fxvolume);
	}
}
