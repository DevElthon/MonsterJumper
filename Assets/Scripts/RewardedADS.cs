using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/// <summary>
/// Provides methods to load and show rewarded ads as well as
/// linking these functions to UI controls
/// </summary>
public class RewardedADS : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] Button _loadAdButton;
    public Button LoadAdButton => _loadAdButton;

    [SerializeField] Button m_ShowAdButton;
    public Button ShowAdButton => m_ShowAdButton;

    [SerializeField]
    GameObject adsPanel;

    [SerializeField] string m_AndroidAdUnitId = "Rewarded_Android";
    public string AndroidAdUnitId => m_AndroidAdUnitId;

    [SerializeField] string m_iOSAdUnitId = "Rewarded_iOS";
    public string iOSAdUnitId => m_iOSAdUnitId;

    private string m_AdUnitId;

    private void Awake()
    {
        m_AdUnitId = m_AndroidAdUnitId;
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            m_AdUnitId = m_iOSAdUnitId;
        }

        m_ShowAdButton.interactable = false;
        _loadAdButton.interactable = false;
        adsPanel.SetActive(true);
    }

    public void Initialize()
    {
        _loadAdButton.onClick.AddListener(LoadAd);
        m_ShowAdButton.onClick.AddListener(ShowAd);

        _loadAdButton.interactable = true;
    }

    void OnDestroy()
    {
        m_ShowAdButton.onClick.RemoveAllListeners();
        _loadAdButton.onClick.RemoveAllListeners();
    }

    private void LoadAd()
    {
        Debug.Log("Loading Ad: " + m_AdUnitId);
        Advertisement.Load(m_AdUnitId, this);
    }

    #region IUnityAdsLoadListener

    /// <param name="adUnitId">The ad unit ID for the loaded ad</param>
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        _loadAdButton.interactable = false;
        m_ShowAdButton.interactable = true;
    }

    /// <param name="adUnitId">The ad unit ID for the ad</param>
    /// <param name="error">The error that prevented the ad from loading</param>
    /// <param name="message">The message accompanying the error</param>
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.LogError($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    #endregion

    private void ShowAd()
    {
        m_ShowAdButton.interactable = false;
        Advertisement.Show(m_AdUnitId, this);
    }

    #region IUnityAdsShowListener

    /// <param name="adUnitId"></param>
    /// <param name="showCompletionState"></param>
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(m_AdUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            GameManager.instance.coins *= 2;
            Advertisement.Load(m_AdUnitId, this);
            adsPanel.SetActive(false);
        }
        LoadAd();
    }

    /// <param name="adUnitId">The ad unit ID for the ad</param>
    /// <param name="error">The error that prevented the ad from loading</param>
    /// <param name="message">The message accompanying the error</param>
    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        LoadAd();
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    /// <param name="adUnitId"></param>
    public void OnUnityAdsShowStart(string adUnitId) { }

    /// <param name="adUnitId"></param>
    public void OnUnityAdsShowClick(string adUnitId) { }

    #endregion
}