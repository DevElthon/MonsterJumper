using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject charOptionsPanel, optionsPanel, storePanel, loadingScreen;
    [SerializeField] TextMeshProUGUI highscore;
    [SerializeField] TextMeshProUGUI Coins;
    [SerializeField] Image loadingBArFill;

    private void Start()
    {
        UpgradeData();
    }

    public void UpgradeData()
    {
        highscore.text = PlayerPrefs.GetInt("HighScore").ToString();
        Coins.text = PlayerPrefs.GetInt("Coins").ToString();
    }


    public void LoadScene(int sceneId)
    {
        int selectedCharacter = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        GameManager.instance.CharIndex = selectedCharacter;

        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        operation.allowSceneActivation = false;

        loadingScreen.SetActive(true);


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

    public void OnClickPlay()
    {
        charOptionsPanel.SetActive(true);
    }
    public void OnClickExitPlay()
    {
        charOptionsPanel.SetActive(false);
    }

    public void OnClickOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void OnExitOptionsclicked()
    {
        optionsPanel.SetActive(false);
    }

    public void OnClickStore()
    {
        storePanel.SetActive(true);
    }

    public void OnExitStoreclicked()
    {
        storePanel.SetActive(false);
    }
} 