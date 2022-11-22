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

		if (!PlayerPrefs.HasKey("trackVolume"))
		{
			PlayerPrefs.SetFloat("trackVolume", 1);
			LoadTrack();
		}
		else
		{
			LoadTrack();
		}

		if (!PlayerPrefs.HasKey("fxVolume"))
		{
			PlayerPrefs.SetFloat("fxVolume", 1);
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

		else if(fxvolume == 1 && desactivedsfx.activeSelf == true)
			desactivedsfx.SetActive(false);

		if(trackvolume == 0 && desactivedtrack.activeSelf == false)
			desactivedtrack.SetActive(true);

		else if(trackvolume == 1 && desactivedtrack.activeSelf == true)
			desactivedtrack.SetActive(false);
	}

	//track section
    public void ChangeTrackVolume()
	{
		if (trackvolume == 1)
		{
			trackvolume = 0;
			audiomanagerInstance.trackSource.volume = trackvolume;
		}
		else if (trackvolume == 0)
		{
			trackvolume = 1;
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
		if (fxvolume == 1)
		{
			fxvolume = 0;
			
			audiomanagerInstance.fxSource.volume = fxvolume;
		}
		else if (fxvolume == 0)
		{
			fxvolume = 1;
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
