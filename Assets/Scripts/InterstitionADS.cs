using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class InterstitionADS : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private Button m_LoadInterstitialAdButton;
    public Button LoadInterstitialAdButton => m_LoadInterstitialAdButton;

    [SerializeField] private Button m_ShowInterstitialAdButton;
    public Button ShowInterstitialAdButton => m_ShowInterstitialAdButton;

    [SerializeField] string m_AndroidAdUnitId = "Interstitial_Android";
    public string AndroidAdUnitId => m_AndroidAdUnitId;

    [SerializeField] string m_iOSAdUnitId = "Interstitial_iOS";
    public string iOSAdUnitId => m_iOSAdUnitId;
    string m_AdUnitId;

    private void Awake()
    {
        m_AdUnitId = m_AndroidAdUnitId;
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            m_AdUnitId = m_iOSAdUnitId;
        }

        m_LoadInterstitialAdButton.interactable = false;
        m_ShowInterstitialAdButton.interactable = false;
    }

    public void Initialize()
    {
        m_LoadInterstitialAdButton.onClick.AddListener(LoadAd);
        m_ShowInterstitialAdButton.onClick.AddListener(ShowAd);

        m_LoadInterstitialAdButton.interactable = true;
    }

    private void OnDestroy()
    {
        m_LoadInterstitialAdButton.onClick.RemoveListener(LoadAd);
        m_ShowInterstitialAdButton.onClick.RemoveListener(ShowAd);
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
        // Optionally execute code if the Ad Unit successfully loads content.
        m_LoadInterstitialAdButton.interactable = false;
        m_ShowInterstitialAdButton.interactable = true;
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
        Debug.Log("Showing Ad: " + m_AdUnitId);
        Advertisement.Show(m_AdUnitId, this);
    }
    #region IUnityAdsShowListener

    /// <param name="adUnitId"></param>
    /// <param name="showCompletionState"></param>
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState) 
    {
        LoadAd();
        GameManager.instance.InstantiatePlayer();
        GameManager.instance.invencible = true;
        GameManager.instance.invTimer = 0;
        GameManager.instance.invactive = true;
        GameManager.instance.lifeCount -= 1;
        GameManager.instance.inGame = true;
        Time.timeScale = 1f;
    }

    /// <param name="adUnitId">The ad unit ID for the ad</param>
    /// <param name="error">The error that prevented the ad from loading</param>
    /// <param name="message">The message accompanying the error</param>
    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        LoadAd();
        Debug.LogError($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    /// <param name="adUnitId"></param>
    public void OnUnityAdsShowStart(string adUnitId) { }

    /// <param name="adUnitId"></param>
    public void OnUnityAdsShowClick(string adUnitId) { }

    #endregion
}