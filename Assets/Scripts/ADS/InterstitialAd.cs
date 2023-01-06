using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class InterstitialAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string m_AndroidAdUnitId = "Interstitial_Android";
    public string AndroidAdUnitId => m_AndroidAdUnitId;

    [SerializeField] string m_iOSAdUnitId = "Interstitial_iOS";
    public string iOSAdUnitId => m_iOSAdUnitId;
    string m_AdUnitId;

    bool adLoaded;

    private void Awake()
    {
        m_AdUnitId = m_AndroidAdUnitId;
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            m_AdUnitId = m_iOSAdUnitId;
        }
    }

    private void Update()
    {
        if (!adLoaded)
        {
            LoadAd();
        }

        if(MainMenuController.adCount == 4)
        {
            ShowAd();
        }
    }

    public void Initialize()
    {
        LoadAd();
    }

    private void LoadAd()
    {
        Debug.Log("Loading Ad: " + m_AdUnitId);
        Advertisement.Load(m_AdUnitId, this);
        adLoaded = true;
    }

    #region IUnityAdsLoadListener

    /// <param name="adUnitId">The ad unit ID for the loaded ad</param>
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        // Optionally execute code if the Ad Unit successfully loads content.
    }

    /// <param name="adUnitId">The ad unit ID for the ad</param>
    /// <param name="error">The error that prevented the ad from loading</param>
    /// <param name="message">The message accompanying the error</param>
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to load, such as attempting to try again.
    }

    #endregion

    private void ShowAd()
    {
        MainMenuController.adCount = 0;
        Debug.Log("Showing Ad: " + m_AdUnitId);
        Advertisement.Show(m_AdUnitId, this);
        adLoaded = false;
    }
    #region IUnityAdsShowListener

    /// <param name="adUnitId"></param>
    /// <param name="showCompletionState"></param>
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState) { }

    /// <param name="adUnitId">The ad unit ID for the ad</param>
    /// <param name="error">The error that prevented the ad from loading</param>
    /// <param name="message">The message accompanying the error</param>
    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.LogError($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    /// <param name="adUnitId"></param>
    public void OnUnityAdsShowStart(string adUnitId) { }

    /// <param name="adUnitId"></param>
    public void OnUnityAdsShowClick(string adUnitId) { }

    #endregion
}