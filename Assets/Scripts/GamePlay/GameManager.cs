using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    float scoreMath;
    [HideInInspector]
    public static GameManager instance;
    public int lifeCount = 1;

    [Header("Flux Timer")]
    public float timer;
    [HideInInspector]
    public float maxTimer = 15f;

    [SerializeField]
    private GameObject[] characters;

    [HideInInspector]
    public int CharIndex;

    [HideInInspector]
    public int currentScore = 0;
    [HideInInspector]
    public int coins = 0;

    [HideInInspector]
    public bool inGame = false;

    //Double points
    [HideInInspector]
    public int dubPoints = 1;
    [HideInInspector]
    public float dubPTimer = 0;
    [HideInInspector]
    public float maxDubTime = 4;

    //Double coins
    [HideInInspector]
    public int dubCoins = 1;
    [HideInInspector]
    public float dubCTimer = 0;
    [HideInInspector]
    public float maxDubCTime = 4;

    //Invencible
    [HideInInspector]
    public bool invencible = false;
    [HideInInspector]
    public float invTimer = 0;
    [HideInInspector]
    public float maxInvTimer = 6;

    [HideInInspector]
    public bool coinactive, pointactive, invactive;

    private Transform mainCam;

    [HideInInspector]
    public bool doubledCoins = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (!PlayerPrefs.HasKey("Tutorial"))
            PlayerPrefs.SetInt("Tutorial", 0);

        CharIndex = PlayerPrefs.GetInt("CharacterActive");
    }

    private void LateUpdate()
    {
        if (inGame && PlayerPrefs.GetInt("Tutorial") == 3)
        {
            timer += Time.deltaTime;
            if (Time.timeScale == 1)
            {
                scoreMath = (1000 * Time.deltaTime) * dubPoints;
                currentScore += 1 + (int)scoreMath;
            }
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        AudioManager.Instance.trackSource.volume = PlayerPrefs.GetFloat("trackVolume");
        if (scene.name == "Gameplay")
        {
            InstantiatePlayer();
            GameplayUIController.playerIsDead = false;
            Time.timeScale = 1f;
            inGame = true;
            AudioManager.Instance.PlayMusic(AudioManager.Instance.tracks[0]);
        }
        else if(scene.name == "MainMenu")
        {
            inGame = false;
            Time.timeScale = 1f;
            AudioManager.Instance.PlayMusic(AudioManager.Instance.tracks[2]);
        }
    }

    public void InstantiatePlayer()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        Instantiate(characters[CharIndex], new Vector3(mainCam.position.x, 0f, 0f), Quaternion.identity);
        mainCam.gameObject.GetComponent<CameraFollow>().PlayerActive();
    }

    public void OnPlayerDeath()
    {
        Time.timeScale = 0f;
    }

    public void SaveInfo()
    {
        if (PlayerPrefs.GetInt("HighScore") < GameManager.instance.currentScore)
            PlayerPrefs.SetInt("HighScore", GameManager.instance.currentScore);

        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + coins);
    }

    public void CoinstimeEffects()
    {
        //Double coins upgrade
        if (PlayerPrefs.GetInt("CoinsLevel") == 0)
        {
            instance.dubCoins = 2;
            instance.maxDubCTime = 6;
        }
        //level 2
        if (PlayerPrefs.GetInt("CoinsLevel") == 1)
        {
            instance.dubCoins = 3;
            instance.maxDubCTime = 8;
        }

        //level 3
        if (PlayerPrefs.GetInt("CoinsLevel") == 2)
        {
            instance.dubCoins = 4;
            instance.maxDubCTime = 10;
        }

        //level 4
        if (PlayerPrefs.GetInt("CoinsLevel") == 3)
        {
            instance.dubCoins = 5;
            instance.maxDubCTime = 12;
        }
    }

    public void PointstimeEffects()
    {
        //Double points upgrade
        if (PlayerPrefs.GetInt("PointsLevel") == 0)
        {
            instance.dubPoints = 2;
            instance.maxDubTime = 6;
        }
        //level 2
        if (PlayerPrefs.GetInt("PointsLevel") == 1)
        {
            instance.dubPoints = 3;
            instance.maxDubTime = 8;
        }

        //level 3
        if (PlayerPrefs.GetInt("PointsLevel") == 2)
        {
            instance.dubPoints = 4;
            instance.maxDubTime = 10;
        }

        //level 4
        if (PlayerPrefs.GetInt("PointsLevel") == 3)
        {
            instance.dubPoints = 5;
            instance.maxDubTime = 12;
        }
    }

    public void InvtimeEffects()
    {
        //Invencible upgrade
        if (PlayerPrefs.GetInt("InvLevel") == 1)
        {
            instance.maxInvTimer = 6;
        }
        //level 2
        if (PlayerPrefs.GetInt("InvLevel") == 1)
        {
            instance.maxInvTimer = 8;
        }

        //level 3
        if (PlayerPrefs.GetInt("InvLevel") == 2)
        {
            instance.maxInvTimer = 10;
        }

        //level 4
        if (PlayerPrefs.GetInt("InvLevel") == 3)
        {
            instance.maxInvTimer = 12;
        }
    }
}