using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ADSManager : MonoBehaviour, IUnityAdsInitializationListener
{
    public string AndroidGameId;
    public string IosGameId;
    public bool TestMode;

    [Header("Rewarded Ads")]
    [SerializeField] private RewardedADS m_RewardedAdExample;
    public RewardedADS RewardedAdExample => m_RewardedAdExample;

    [Header("Interstitial Ads")]
    [SerializeField] private InterstitionADS m_InterstitialAdExample;

    public InterstitionADS InterstitialAdExample => m_InterstitialAdExample;

    private void Awake()
    {
        InitializeAds();
    }

    private void InitializeAds()
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

        m_RewardedAdExample.Initialize();
        m_InterstitialAdExample.Initialize();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}