using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject charOptionsPanel, optionsPanel, storePanel;
    [SerializeField] TextMeshProUGUI highscore;
    [SerializeField] TextMeshProUGUI Coins;

    private void Start()
    {
        UpgradeData();
    }

    public void UpgradeData()
    {
        highscore.text = PlayerPrefs.GetInt("HighScore").ToString();
        Coins.text = PlayerPrefs.GetInt("Coins").ToString();
    }

    public void PlayGame() 
    {
        int selectedCharacter = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        GameManager.instance.CharIndex = selectedCharacter;

        SceneManager.LoadScene("Gameplay");
        //charOptionsPanel.SetActive(false);
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