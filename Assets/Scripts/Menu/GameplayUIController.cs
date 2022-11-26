using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameplayUIController : MonoBehaviour
{
    [SerializeField] private Button rewardedButton;

    [Header("Text scores")]
    [SerializeField]
    private TextMeshProUGUI score;
    [SerializeField]
    private TextMeshProUGUI coin;

    [Header("Text scores On GameOver")]
    [SerializeField] Text highscore;
    [SerializeField] Text scoreAmount;
    [SerializeField] Text Coins;

    [Header("Paineis de jogo")]
    [SerializeField]
    private GameObject pausePanel, deathPanel, continuePanel;

    public static bool playerIsDead = false;

    [Header("FeedBack visual de habilidades")]
    [SerializeField] TextMeshProUGUI dubPFeed, dubCFeed;

    public GameObject[] clock;
    [SerializeField] GameObject[] clockHand;

    private void Awake()
    {
        ResetInGameInfo();
    }

    private void Update()
    {
        //text feed
        score.text = GameManager.instance.currentScore.ToString();
        coin.text = GameManager.instance.coins.ToString();

        highscore.text = PlayerPrefs.GetInt("HighScore").ToString();
        Coins.text = GameManager.instance.coins.ToString();
        scoreAmount.text = GameManager.instance.currentScore.ToString();

        //Dub Points
        if(GameManager.instance.pointactive)
        {
            dubPFeed.gameObject.SetActive(true);
            dubPFeed.text = GameManager.instance.dubPoints.ToString() + "X";
        }
        else
        {
            dubPFeed.gameObject.SetActive(false);
        }

        //Dub Coins
        if (GameManager.instance.coinactive)
        {
            dubCFeed.gameObject.SetActive(true);
            dubCFeed.text = GameManager.instance.dubCoins.ToString() + "X";
        }
        else
        {
            dubCFeed.gameObject.SetActive(false);
        }

        //Methods to call
        ActiveHabilitiesFeed();
        RotateClock();
    }

    private void LateUpdate()
    {
        //ContinuePanel control
        if (playerIsDead == true && !continuePanel.activeSelf && !deathPanel.activeSelf && GameManager.instance.lifeCount == 1)
        {
            continuePanel.SetActive(true);
            GameManager.instance.inGame = false;
        }

        else if (playerIsDead == true && !continuePanel.activeSelf && !deathPanel.activeSelf && GameManager.instance.lifeCount == 0)
        {
            deathPanel.SetActive(true);
            GameManager.instance.inGame = false;
        }

        if(deathPanel.activeSelf && (AudioManager.Instance.trackSource.clip != AudioManager.Instance.tracks[1]))
        {
            AudioManager.Instance.Play(AudioManager.Instance.sfx[4]);
            AudioManager.Instance.PlayMusic(AudioManager.Instance.tracks[1]);
        }       
    }

    public void ActiveHabilitiesFeed()
    {
        //Coin Clock
        if(GameManager.instance.dubCTimer > 0)
        {
            clock[0].SetActive(true);
        }
        else
        {
            clock[0].SetActive(false);
        }

        //Points Clock
        if (GameManager.instance.dubPTimer > 0)
        {
            clock[1].SetActive(true);
        }
        else
        {
            clock[1].SetActive(false);
        }

        //Invencible Clock
        if (GameManager.instance.invencible)
        {
            clock[2].SetActive(true);
        }
        else
        {
            clock[2].SetActive(false);
        }
    }

    public void RotateClock()
    {
        //Coin clockhand
        if (clock[0].activeSelf)
        {
            clockHand[0].transform.eulerAngles = new Vector3(0, 0, (- Time.realtimeSinceStartup) * (90f));
        }

        //Points clockhand
        if (clock[1].activeSelf)
        {
            clockHand[1].transform.eulerAngles = new Vector3(0, 0, (- Time.realtimeSinceStartup) * (90f));
        }

        //Invencible clockhand
        if (clock[2].activeSelf)
        {
            clockHand[2].transform.eulerAngles = new Vector3(0, 0, (- Time.realtimeSinceStartup) * (90f));
        }
    }

    public void ResetInGameInfo()
    {
        GameManager.instance.timer = 0;
        GameManager.instance.currentScore = 0;
        GameManager.instance.coins = 0;
        GameManager.instance.lifeCount = 1;
        //buff time control
        GameManager.instance.dubCTimer = 0;
        GameManager.instance.dubPTimer = 0;
        GameManager.instance.dubPoints = 1;
        GameManager.instance.dubCoins = 1;
        GameManager.instance.invTimer = 0;
        GameManager.instance.invencible = false;

        GameManager.instance.coinactive = false;
        GameManager.instance.pointactive = false;
        GameManager.instance.invactive = false;

        dubCFeed.gameObject.SetActive(false);
        dubPFeed.gameObject.SetActive(false);
        clock[0].SetActive(false);
        clock[1].SetActive(false);
        clock[2].SetActive(false);
    }

    public void RestartGame()
    {
        GameManager.instance.SaveInfo();
        ResetInGameInfo();
        AudioManager.Instance.PlayMusic(AudioManager.Instance.tracks[0]);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void HomeButton()
    {
        GameManager.instance.SaveInfo();
        ResetInGameInfo();
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseMenu()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void OnNoClick()
    {
        continuePanel.SetActive(false);
        deathPanel.SetActive(true);
    }

    public void OnAdClick()
    {
        continuePanel.SetActive(false);
        playerIsDead = false;
    }
}
