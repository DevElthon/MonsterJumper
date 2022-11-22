using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
    private GameManager gameManagerInstance;

    [Header("Coins upgrade check")]
    [SerializeField]
    private GameObject coinlevel2Check, coinlevel3Check, coinlevel4Check;

    [Header("Points upgrade check")]
    [SerializeField]
    private GameObject pointslevel2Check, pointslevel3Check, pointslevel4Check;

    [Header("Invencible upgrade check")]
    [SerializeField]
    private GameObject invlevel2Check, invlevel3Check, invlevel4Check;

    [Header("Characters")]
    [SerializeField]
    private GameObject char1lock, char2lock, char3lock, characterPanel;
    [SerializeField]
    private Button UpgradePanelBtn;

    [Header("Upgrade buttons")]
    [SerializeField]
    private GameObject upgradeCoinBtn, upgradePointsBtn, upgradeInvBtn, upgradesPanel;
    [SerializeField]
    private Button charactersPanelBtn;

    [Header("UpgradeBtn's price")]
    [SerializeField] TextMeshProUGUI upgrade1, upgrade2, upgrade3;

    private void Awake()
    {
        //Colectables
        if (!PlayerPrefs.HasKey("CoinsLevel"))
            PlayerPrefs.SetInt("CoinsLevel", 0);

        if (!PlayerPrefs.HasKey("PointsLevel"))
            PlayerPrefs.SetInt("PointsLevel", 0);

        if (!PlayerPrefs.HasKey("InvLevel"))
            PlayerPrefs.SetInt("InvLevel", 0);

        //Characters
        if (!PlayerPrefs.HasKey("Char1Unlocked"))
            PlayerPrefs.SetInt("Char1Unlocked", 0);

        if (!PlayerPrefs.HasKey("Char2Unlocked"))
            PlayerPrefs.SetInt("Char2Unlocked", 0);

        if (!PlayerPrefs.HasKey("Char3Unlocked"))
            PlayerPrefs.SetInt("Char3Unlocked", 0);
    }

    private void Start()
    {
        gameManagerInstance = GameManager.instance;
    }

    private void LateUpdate()
    {
        //Colectables
        //Coins Level
        if (PlayerPrefs.GetInt("CoinsLevel") >= 1 && coinlevel2Check.activeSelf == false)
        {
            upgrade1.text = "Upgrade: \n1000";
            coinlevel2Check.SetActive(true);
        }
        if (PlayerPrefs.GetInt("CoinsLevel") >= 2 && coinlevel3Check.activeSelf == false)
        {
            upgrade1.text = "Upgrade: \n2000";
            coinlevel2Check.SetActive(true);
            coinlevel3Check.SetActive(true);
        }
        if (PlayerPrefs.GetInt("CoinsLevel") >= 3 && coinlevel4Check.activeSelf == false)
        {
            coinlevel2Check.SetActive(true);
            coinlevel4Check.SetActive(true);
            upgradeCoinBtn.SetActive(false);
        }

        //Points Level
        if (PlayerPrefs.GetInt("PointsLevel") >= 1 && pointslevel2Check.activeSelf == false)
        {
            upgrade2.text = "Upgrade: \n1000";
            pointslevel2Check.SetActive(true);
        }
        if (PlayerPrefs.GetInt("PointsLevel") >= 2 && pointslevel3Check.activeSelf == false )
        {
            upgrade2.text = "Upgrade: \n2000";
            pointslevel3Check.SetActive(true);
        }
        if (PlayerPrefs.GetInt("PointsLevel") >= 3 && pointslevel4Check.activeSelf == false)
        {
            pointslevel4Check.SetActive(true);
            upgradePointsBtn.SetActive(false);
        }

        //Invencible Level
        if (PlayerPrefs.GetInt("InvLevel") >= 1 && invlevel2Check.activeSelf == false)
        {
            upgrade3.text = "Upgrade: \n1000";
            invlevel2Check.SetActive(true);
        }
        if (PlayerPrefs.GetInt("InvLevel") >= 2 && invlevel3Check.activeSelf == false)
        {
            upgrade3.text = "Upgrade: \n2000";
            invlevel3Check.SetActive(true);
        }
        if (PlayerPrefs.GetInt("InvLevel") >= 3 && invlevel4Check.activeSelf == false)
        {
            invlevel4Check.SetActive(true);
            upgradeInvBtn.SetActive(false);
        }

        //Characters
        //Char1
        if (PlayerPrefs.GetInt("Char1Unlocked") == 1 && char1lock.activeSelf == true)
        {
            char1lock.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Char2Unlocked") == 1 && char2lock.activeSelf == true)
        {
            char2lock.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Char3Unlocked") == 1 && char3lock.activeSelf == true)
        {
            char3lock.SetActive(false);
        }
    }

    public void OnUpgradeCoinClicked()
    {
        if(PlayerPrefs.GetInt("Coins") >= 500 && PlayerPrefs.GetInt("CoinsLevel") == 0)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 500 );
            PlayerPrefs.SetInt("CoinsLevel", PlayerPrefs.GetInt("CoinsLevel") + 1);
        }

        if (PlayerPrefs.GetInt("Coins") >= 1000 && PlayerPrefs.GetInt("CoinsLevel") == 1 && coinlevel2Check.activeSelf == true)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 1000);
            PlayerPrefs.SetInt("CoinsLevel", PlayerPrefs.GetInt("CoinsLevel") + 1);
        }

        if (PlayerPrefs.GetInt("Coins") >= 2000 && PlayerPrefs.GetInt("CoinsLevel") == 2 && coinlevel3Check.activeSelf == true)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 2000);
            PlayerPrefs.SetInt("CoinsLevel", PlayerPrefs.GetInt("CoinsLevel") + 1);
        }
    }

    public void OnUpgradePointsClicked()
    {
        if (PlayerPrefs.GetInt("Coins") >= 500 && PlayerPrefs.GetInt("PointsLevel") == 0)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 500);
            PlayerPrefs.SetInt("PointsLevel", PlayerPrefs.GetInt("PointsLevel") + 1);
        }

        if (PlayerPrefs.GetInt("Coins") >= 1000 && PlayerPrefs.GetInt("PointsLevel") == 1 && pointslevel2Check.activeSelf == true)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 1000);
            PlayerPrefs.SetInt("PointsLevel", PlayerPrefs.GetInt("PointsLevel") + 1);
        }

        if (PlayerPrefs.GetInt("Coins") >= 2000 && PlayerPrefs.GetInt("PointsLevel") == 2 && pointslevel3Check.activeSelf == true)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 2000);
            PlayerPrefs.SetInt("PointsLevel", PlayerPrefs.GetInt("PointsLevel") + 1);
        }
    }

    public void OnUpgradeInvClicked()
    {
        if (PlayerPrefs.GetInt("Coins") >= 500 && PlayerPrefs.GetInt("InvLevel") == 0)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 500);
            PlayerPrefs.SetInt("InvLevel", PlayerPrefs.GetInt("InvLevel") + 1);
        }

        if (PlayerPrefs.GetInt("Coins") >= 1000 && PlayerPrefs.GetInt("InvLevel") == 1 && invlevel2Check.activeSelf == true)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 1000);
            PlayerPrefs.SetInt("InvLevel", PlayerPrefs.GetInt("InvLevel") + 1);
        }

        if (PlayerPrefs.GetInt("Coins") >= 2000 && PlayerPrefs.GetInt("InvLevel") == 2 && invlevel3Check.activeSelf == true)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 2000);
            PlayerPrefs.SetInt("InvLevel", PlayerPrefs.GetInt("InvLevel") + 1);
        }
    }

    public void OnBuyChar1Clicked()
    {
        if (PlayerPrefs.GetInt("Coins") >= 500 && PlayerPrefs.GetInt("Char1Unlocked") == 0)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 500);
            PlayerPrefs.SetInt("Char1Unlocked", 1);
        }
    }

    public void OnBuyChar2Clicked()
    {
        if (PlayerPrefs.GetInt("Coins") >= 1000 && PlayerPrefs.GetInt("Char2Unlocked") == 0)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 1000);
            PlayerPrefs.SetInt("Char2Unlocked", 1);
        }
    }

    public void OnBuyChar3Clicked()
    {
        if (PlayerPrefs.GetInt("Coins") >= 2000 && PlayerPrefs.GetInt("Char3Unlocked") == 0)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 2000);
            PlayerPrefs.SetInt("Char3Unlocked", 1);
        }
    }

    public void CharactersClicked()
    {
        if(characterPanel.activeSelf == false)
        {
            upgradesPanel.SetActive(false);
            characterPanel.SetActive(true);
            charactersPanelBtn.interactable = false;
            UpgradePanelBtn.interactable = true;
        }
    }

    public void UpgradesClicked()
    {
        if(upgradesPanel.activeSelf == false)
        {
            upgradesPanel.SetActive(true);
            characterPanel.SetActive(false);
            charactersPanelBtn.interactable = true;
            UpgradePanelBtn.interactable = false;
        }
    }
}
