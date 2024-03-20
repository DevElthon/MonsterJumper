using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SecondRewardedADS : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
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
        adsPanel.SetActive(true);
    }

    private void Update()
    {
        if (adsPanel.activeSelf)
        {
            if (!GameManager.instance.inGame && m_ShowAdButton.interactable == false)
            {
                LoadAd();
            }
            if (!GameManager.instance.inGame && !m_ShowAdButton.interactable == false)
            {
                m_ShowAdButton.onClick.AddListener(ShowAd);
            }
        }
    }

    public void Initialize()
    {
        m_ShowAdButton.onClick.AddListener(ShowAd);
    }

    void OnDestroy()
    {
        m_ShowAdButton.onClick.RemoveAllListeners();
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
        if(PlayerPrefs.GetInt("Freead") == 0){
            m_ShowAdButton.interactable = false;
            Advertisement.Show(m_AdUnitId, this);
        }
        else if(PlayerPrefs.GetInt("Freead") == 1){
            if(GameManager.instance.lifeCount == 1)
            {
                GameManager.instance.invencible = true;
                GameManager.instance.invTimer = 0;
                GameManager.instance.invactive = true;
                GameManager.instance.lifeCount -= 1;
                GameManager.instance.inGame = true;
                Time.timeScale = 1f;
            }
        }
    }

    #region IUnityAdsShowListener

    /// <param name="adUnitId"></param>
    /// <param name="showCompletionState"></param>
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(m_AdUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            if(GameManager.instance.lifeCount == 1)
            {
                GameManager.instance.invencible = true;
                GameManager.instance.invTimer = 0;
                GameManager.instance.invactive = true;
                GameManager.instance.lifeCount -= 1;
                GameManager.instance.inGame = true;
                Time.timeScale = 1f;
                Advertisement.Load(m_AdUnitId, this);
            }

            if (adsPanel != null)
                adsPanel.SetActive(false);
        }
    }

    /// <param name="adUnitId">The ad unit ID for the ad</param>
    /// <param name="error">The error that prevented the ad from loading</param>
    /// <param name="message">The message accompanying the error</param>
    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    /// <param name="adUnitId"></param>
    public void OnUnityAdsShowStart(string adUnitId) { }

    /// <param name="adUnitId"></param>
    public void OnUnityAdsShowClick(string adUnitId) { }

    #endregion
}