using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameplayUIController : MonoBehaviour
{
    [Header("Explosion")]
    [SerializeField]
    private GameObject explosion_button;
    [SerializeField] Button explosion_ref;
    [SerializeField] Image loading_button_fill;


    [SerializeField] private Button rewardedButton;

    [Header("Text scores")]
    [SerializeField]
    private TextMeshProUGUI score;
    [SerializeField]
    private TextMeshProUGUI coin;
    [SerializeField]
    private GameObject NewScore;

    [Header("Text scores On GameOver")]
    [SerializeField] Text highscore;
    [SerializeField] Text scoreAmount;
    [SerializeField] Text Coins;

    [Header("Paineis de jogo")]
    [SerializeField]
    private GameObject pausePanel, deathPanel, continuePanel;

    public static bool playerIsDead = false, player_may_die = false;

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
        if(GameManager.instance.currentScore > PlayerPrefs.GetInt("HighScore"))
        {
            NewScore.SetActive(true);
            PlayerPrefs.SetInt("HighScore", GameManager.instance.currentScore);
        }

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

        if (GameManager.instance.inGame)
        {
            continuePanel.SetActive(false);
            if(PlayerPrefs.GetInt("Tutorial") == 3 && !explosion_button.activeSelf){
                explosion_button.SetActive(true);
            }
        }

        //Methods to call
        ActiveHabilitiesFeed();
        Explosion_Ready();
        RotateClock();
    }

    private void LateUpdate()
    {
        //ContinuePanel control
        if (PlayerPrefs.GetInt("Tutorial") == 3 && player_may_die == true && !continuePanel.activeSelf && !deathPanel.activeSelf && GameManager.instance.lifeCount == 1)
        {
            continuePanel.SetActive(true);
            GameManager.instance.inGame = false;
        }

        else if (playerIsDead == true && !continuePanel.activeSelf && !deathPanel.activeSelf && GameManager.instance.lifeCount == 0 && Time.timeScale == 0)
        {
            deathPanel.SetActive(true);
            GameManager.instance.inGame = false;
        }

        if(deathPanel.activeSelf && (AudioManager.Instance.trackSource.clip != AudioManager.Instance.tracks[1]))
        {
            AudioManager.Instance.Play(AudioManager.Instance.sfx[4]);
            AudioManager.Instance.PlayMusic(AudioManager.Instance.tracks[1]);
        }   

        if(PlayerPrefs.GetInt("Tutorial") < 3 && playerIsDead == true && !deathPanel.activeSelf)
        {
            deathPanel.SetActive(true);
            GameManager.instance.inGame = false;
        }
    }

    private void Explosion_Ready(){
        if(GameManager.instance.loading_explosion <= GameManager.instance.max_loading_explosion){
            GameManager.instance.loading_explosion += Time.deltaTime;
            loading_button_fill.fillAmount = GameManager.instance.loading_explosion/GameManager.instance.max_loading_explosion;
        }
    
        if(GameManager.instance.loading_explosion >= GameManager.instance.max_loading_explosion){
            explosion_ref.interactable = true;
        }
        else{
           explosion_ref.interactable = false;
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
        player_may_die = false;
        playerIsDead = false;
        GameManager.instance.loading_explosion = 0;
        GameManager.instance.timer = 0;
        GameManager.instance.currentScore = 0;
        GameManager.instance.coins = 0;
        GameManager.instance.lifeCount = 1;
        //buff time control
        GameManager.instance.dubCTimer = 0;
        GameManager.instance.dubPTimer = 0;
        GameManager.instance.dubPoints = 1;
        GameManager.instance.dubCoins = 1;
        GameManager.instance.timer = 0;
        GameManager.instance.invTimer = 0;
        GameManager.instance.invencible = false;

        GameManager.instance.coinactive = false;
        GameManager.instance.pointactive = false;
        GameManager.instance.invactive = false;
        GameManager.instance.doubledCoins = false;
        GameManager.instance.maxTimer = 15f;

        dubCFeed.gameObject.SetActive(false);
        dubPFeed.gameObject.SetActive(false);
        clock[0].SetActive(false);
        clock[1].SetActive(false);
        clock[2].SetActive(false);

        //ADSManager.ADSinstance.InitializeAds();
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
