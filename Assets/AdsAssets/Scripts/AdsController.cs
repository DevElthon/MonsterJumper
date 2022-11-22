using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
/// <summary>
/// The Ads Controller applies the game ids to the project to ensure that ads can be used within the project. It initializes
/// the Advertisement SDK as well as sets up the various ads to be used withing the project.
/// </summary>
public class AdsController : MonoBehaviour, IUnityAdsInitializationListener
{
    public string AndroidGameId;
    public string IosGameId;
    [HideInInspector] 
    public bool TestMode;
    
    [Header("Rewarded Ads")]
    [SerializeField] private RewardedAdExample m_RewardedAdExample;
    public RewardedAdExample RewardedAdExample => m_RewardedAdExample;
    
    private void Awake()
    {
        InitializeAds();
    }

    private void InitializeAds()
    {
        // Android Ad Unit Ids are the default. If the platform is iOS, then apply the corresponding Ad Unit Id.
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
    }
 
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}