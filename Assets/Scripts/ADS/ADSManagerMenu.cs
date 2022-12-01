using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ADSManagerMenu : MonoBehaviour, IUnityAdsInitializationListener
{
    public string AndroidGameId;
    public string IosGameId;
    public bool TestMode;


    [Header("Interstitial Ads")]
    [SerializeField] private InterstitialAd interstitialAd;

    [HideInInspector]
    public static ADSManagerMenu ADSMenuinstance;

    private void Start()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
        var gameId = AndroidGameId;
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            gameId = IosGameId;
        }

        if (string.IsNullOrEmpty(gameId))
        {
            throw new InvalidDataException(
                "There is no Game Id currently set. Please ensure that Services are linked to a valid project and that Ads have been enabled in Project Settings.");
        }
        Advertisement.Initialize(gameId, TestMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");

        interstitialAd.Initialize();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}