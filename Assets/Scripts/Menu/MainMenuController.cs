using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject charOptionsPanel, optionsPanel, storePanel, cashStorePanel, loadingScreen, inventoryPanel, creditsPanel;
    [SerializeField] TextMeshProUGUI highscore;
    [SerializeField] TextMeshProUGUI Coins;
    [SerializeField] Image loadingBArFill;

    public static int adCount = 0;

    [SerializeField] Image loadingScreenImage;
    [SerializeField] Sprite[] loadimagesopt;

    private void Start()
    {
        //PlayerPrefs.SetInt("Coins", 999999);
        UpgradeData();
    }

    public void UpgradeData()
    {
        highscore.text = PlayerPrefs.GetInt("HighScore").ToString();
        Coins.text = PlayerPrefs.GetInt("Coins").ToString();

        if (PlayerPrefs.GetInt("HighScore") > PlayServices.GetPlayerScore(MonsterJumperServices.leaderboard_ranking))
        {
            PlayServices.PostScore((long)PlayerPrefs.GetInt("HighScore"), MonsterJumperServices.leaderboard_ranking);
        }
    }

    public void ShowAchievmentsUI()
    {
        PlayServices.ShowAchievments();
    }

    public void ShowLeaderBoardUI()
    {
        PlayServices.ShowLeaderboard(MonsterJumperServices.leaderboard_ranking);
    }

    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
        int rand = Random.Range(0, 2);
        loadingScreenImage.sprite = loadimagesopt[rand];
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        operation.allowSceneActivation = false;

        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBArFill.fillAmount = progressValue;
            if (Mathf.Approximately(operation.progress, 0.9f))
            {
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    public void OnClickOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void OnExitOptionsclicked()
    {
        optionsPanel.SetActive(false);
    }

    public void OnClickCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void OnExitCredits()
    {
        creditsPanel.SetActive(false);
    }

    public void OnClickStore()
    {
        storePanel.SetActive(true);
    }

    public void OnExitStoreclicked()
    {
        storePanel.SetActive(false);
        BackgroundStore.backgroundIndex = 0;
    }

    public void OnClickCashStore()
    {
        cashStorePanel.SetActive(true);
    }

    public void OnExitCashStoreclicked()
    {
        cashStorePanel.SetActive(false);
    }

    public void OnInventoryClicked()
    {
        inventoryPanel.SetActive(true);
    }

    public void OnExitInventoryclicked()
    {
        inventoryPanel.SetActive(false);
    }

    public void MenuPlusAd()
    {
        adCount += 1;
        Debug.Log(adCount);
    }

    public void ResetALLData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void HackTheGame()
    {
        PlayerPrefs.SetInt("Coins", 999999);
        PlayerPrefs.SetInt("HighScore", 999999);
        SceneManager.LoadScene("MainMenu");
    }
} 