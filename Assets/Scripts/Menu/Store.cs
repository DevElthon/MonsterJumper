using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
    private GameManager gameManagerInstance;

    [Header("Pagina de personagens na loja")]
    [SerializeField]
    private GameObject[] charPage;
    [SerializeField]
    private GameObject rightCharpage, leftCharpage;
    int pagecount = 0;

    [Header("Coins upgrade check")]
    [SerializeField]
    private GameObject coinlevel2Check, coinlevel3Check, coinlevel4Check;

    [Header("Points upgrade check")]
    [SerializeField]
    private GameObject pointslevel2Check, pointslevel3Check, pointslevel4Check;

    [Header("Invencible upgrade check")]
    [SerializeField]
    private GameObject invlevel2Check, invlevel3Check, invlevel4Check;

    [Header("Explosion upgrade check")]
    [SerializeField]
    private GameObject explosionlevel2Check, explosionlevel3Check, explosionlevel4Check;


    [Header("Characters")]
    [SerializeField]
    private GameObject char1lock, char2lock, char3lock, char4lock, char5lock, characterPanel;
    [SerializeField]
    private Button UpgradePanelBtn;

    [Header("Upgrade buttons")]
    [SerializeField]
    private GameObject upgradeCoinBtn, upgradePointsBtn, upgradeInvBtn, upgradeExplosionBtn, upgradesPanel;
    [SerializeField]
    private Button charactersPanelBtn;

    [Header("UpgradeBtn's price")]
    [SerializeField] TextMeshProUGUI upgrade1, upgrade2, upgrade3, upgrade4;

    [Header("Backgrounds")]
    [SerializeField]
    private Button backgroundsPanelBtn;
    [SerializeField]
    private GameObject backgroundsPanel;

    [Header("Cash Store")]
    [SerializeField]
    GameObject cashStorePanel, adblockBtn, addblockSold, dullapackBTn, dullapacksold, maxupbtn, maxupsold;
    [SerializeField]
    private Button cashStorePanelBtn;
    
    //info
    [SerializeField] GameObject info_panel;
    [SerializeField] TextMeshProUGUI info_text, info_title;

    string[] Descriptions = new string[4]{"When this ability is active, all coins that you collect will be multiplied. When you upgrade this ability, your coins will be multiplied even more.", "When this ability is active, your points earned by jumping will be multiplied. When you upgrade this ability, your points will be multiplied even more.", "When this ability is active, monsters can't hurt you and will die when they touch you. When you upgrade this ability, your become invincible for a longer time.", "When you use this ability, create a great explosion that will kill nearby monsters. When you upgrade this ability, it will reload faster."};

    string[] Abilities_title = new string[4]{"Multiply your coins","Multiply your points","Become invincible", "The great explosion"};

    private void Awake()
    {
        //Colectables
        if (!PlayerPrefs.HasKey("CoinsLevel"))
            PlayerPrefs.SetInt("CoinsLevel", 0);

        if (!PlayerPrefs.HasKey("PointsLevel"))
            PlayerPrefs.SetInt("PointsLevel", 0);

        if (!PlayerPrefs.HasKey("InvLevel"))
            PlayerPrefs.SetInt("InvLevel", 0);

        //Special Power
        if (!PlayerPrefs.HasKey("ExplosionLevel"))
            PlayerPrefs.SetInt("ExplosionLevel", 0);

        //Characters
        if (!PlayerPrefs.HasKey("Char1Unlocked"))
            PlayerPrefs.SetInt("Char1Unlocked", 0);

        if (!PlayerPrefs.HasKey("Char2Unlocked"))
            PlayerPrefs.SetInt("Char2Unlocked", 0);

        if (!PlayerPrefs.HasKey("Char3Unlocked"))
            PlayerPrefs.SetInt("Char3Unlocked", 0);

        if (!PlayerPrefs.HasKey("Char4Unlocked"))
            PlayerPrefs.SetInt("Char4Unlocked", 0);

        if (!PlayerPrefs.HasKey("Char5Unlocked"))
            PlayerPrefs.SetInt("Char5Unlocked", 0);
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
            upgrade1.text = "ATUALIZAR: 2000";
            coinlevel2Check.SetActive(true);
        }
        if (PlayerPrefs.GetInt("CoinsLevel") >= 2 && coinlevel3Check.activeSelf == false)
        {
            upgrade1.text = "ATUALIZAR: 4000";
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
            upgrade2.text = "ATUALIZAR: 2000";
            pointslevel2Check.SetActive(true);
        }
        if (PlayerPrefs.GetInt("PointsLevel") >= 2 && pointslevel3Check.activeSelf == false )
        {
            upgrade2.text = "ATUALIZAR: 4000";
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
            upgrade3.text = "ATUALIZAR: 2000";
            invlevel2Check.SetActive(true);
        }
        if (PlayerPrefs.GetInt("InvLevel") >= 2 && invlevel3Check.activeSelf == false)
        {
            upgrade3.text = "ATUALIZAR: 4000";
            invlevel3Check.SetActive(true);
        }
        if (PlayerPrefs.GetInt("InvLevel") >= 3 && invlevel4Check.activeSelf == false)
        {
            invlevel4Check.SetActive(true);
            upgradeInvBtn.SetActive(false);
        }

        //Explosion Level
        if (PlayerPrefs.GetInt("ExplosionLevel") >= 1 && explosionlevel2Check.activeSelf == false)
        {
            upgrade4.text = "ATUALIZAR: 2000";
            explosionlevel2Check.SetActive(true);
        }
        if (PlayerPrefs.GetInt("ExplosionLevel") >= 2 && explosionlevel3Check.activeSelf == false)
        {
            upgrade4.text = "ATUALIZAR: 4000";
            explosionlevel3Check.SetActive(true);
        }
        if (PlayerPrefs.GetInt("ExplosionLevel") >= 3 && explosionlevel4Check.activeSelf == false)
        {
            explosionlevel4Check.SetActive(true);
            upgradeExplosionBtn.SetActive(false);
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
        if (PlayerPrefs.GetInt("Char4Unlocked") == 1 && char4lock.activeSelf == true)
        {
            char4lock.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Char5Unlocked") == 1 && char5lock.activeSelf == true)
        {
            char5lock.SetActive(false);
        }

        //Pacotes
        if (PlayerPrefs.GetInt("Char4Unlocked") == 1 && PlayerPrefs.GetInt("Background2") == 1 && !dullapacksold.activeSelf)
        {
            dullapackBTn.SetActive(false);
            dullapacksold.SetActive(true);
        }
        if(PlayerPrefs.GetInt("PointsLevel") >= 3 && PlayerPrefs.GetInt("InvLevel") >= 3 && PlayerPrefs.GetInt("CoinsLevel") >= 3 && !maxupsold.activeSelf)
        {
            maxupbtn.SetActive(false);
            maxupsold.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Freead") == 1){
            adblockBtn.SetActive(false);
            addblockSold.SetActive(true);
        }

        //CharPage
        if (pagecount == charPage.Length - 1 && rightCharpage.activeSelf)
        {
            rightCharpage.SetActive(false);
        }
        else if(pagecount < charPage.Length - 1 && !rightCharpage.activeSelf)
        {
            rightCharpage.SetActive(true);
        }

        if (pagecount == 0 && leftCharpage.activeSelf)
        {
            leftCharpage.SetActive(false);
        }

        else if (pagecount > 0 && !leftCharpage.activeSelf)
        {
            leftCharpage.SetActive(true);
        }
    }

    public void onClickRightCharPage()
    {
        pagecount += 1;
        charPage[pagecount - 1].SetActive(false);
        charPage[pagecount].SetActive(true);
    }

    public void onClickLeftCharPage()
    {
        pagecount -= 1;
        charPage[pagecount + 1].SetActive(false);
        charPage[pagecount].SetActive(true);
    }

    public void OnUpgradeCoinClicked()
    {
        if(PlayerPrefs.GetInt("Coins") >= 1000 && PlayerPrefs.GetInt("CoinsLevel") == 0)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 1000 );
            PlayerPrefs.SetInt("CoinsLevel", PlayerPrefs.GetInt("CoinsLevel") + 1);
        }

        if (PlayerPrefs.GetInt("Coins") >= 2000 && PlayerPrefs.GetInt("CoinsLevel") == 1 && coinlevel2Check.activeSelf == true)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 2000);
            PlayerPrefs.SetInt("CoinsLevel", PlayerPrefs.GetInt("CoinsLevel") + 1);
        }

        if (PlayerPrefs.GetInt("Coins") >= 4000 && PlayerPrefs.GetInt("CoinsLevel") == 2 && coinlevel3Check.activeSelf == true)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 4000);
            PlayerPrefs.SetInt("CoinsLevel", PlayerPrefs.GetInt("CoinsLevel") + 1);
        }
    }

    public void OnUpgradePointsClicked()
    {
        if (PlayerPrefs.GetInt("Coins") >= 1000 && PlayerPrefs.GetInt("PointsLevel") == 0)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 1000);
            PlayerPrefs.SetInt("PointsLevel", PlayerPrefs.GetInt("PointsLevel") + 1);
        }

        if (PlayerPrefs.GetInt("Coins") >= 2000 && PlayerPrefs.GetInt("PointsLevel") == 1 && pointslevel2Check.activeSelf == true)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 2000);
            PlayerPrefs.SetInt("PointsLevel", PlayerPrefs.GetInt("PointsLevel") + 1);
        }

        if (PlayerPrefs.GetInt("Coins") >= 4000 && PlayerPrefs.GetInt("PointsLevel") == 2 && pointslevel3Check.activeSelf == true)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 4000);
            PlayerPrefs.SetInt("PointsLevel", PlayerPrefs.GetInt("PointsLevel") + 1);
        }
    }

    public void OnUpgradeInvClicked()
    {
        if (PlayerPrefs.GetInt("Coins") >= 1000 && PlayerPrefs.GetInt("InvLevel") == 0)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 1000);
            PlayerPrefs.SetInt("InvLevel", PlayerPrefs.GetInt("InvLevel") + 1);
        }

        if (PlayerPrefs.GetInt("Coins") >= 2000 && PlayerPrefs.GetInt("InvLevel") == 1 && invlevel2Check.activeSelf == true)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 2000);
            PlayerPrefs.SetInt("InvLevel", PlayerPrefs.GetInt("InvLevel") + 1);
        }

        if (PlayerPrefs.GetInt("Coins") >= 4000 && PlayerPrefs.GetInt("InvLevel") == 2 && invlevel3Check.activeSelf == true)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 4000);
            PlayerPrefs.SetInt("InvLevel", PlayerPrefs.GetInt("InvLevel") + 1);
        }
    }

    public void OnUpgradeExplosionClicked()
    {
        if (PlayerPrefs.GetInt("Coins") >= 1000 && PlayerPrefs.GetInt("ExplosionLevel") == 0)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 1000);
            PlayerPrefs.SetInt("ExplosionLevel", PlayerPrefs.GetInt("ExplosionLevel") + 1);
        }

        if (PlayerPrefs.GetInt("Coins") >= 2000 && PlayerPrefs.GetInt("ExplosionLevel") == 1 && explosionlevel2Check.activeSelf == true)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 2000);
            PlayerPrefs.SetInt("ExplosionLevel", PlayerPrefs.GetInt("ExplosionLevel") + 1);
        }

        if (PlayerPrefs.GetInt("Coins") >= 4000 && PlayerPrefs.GetInt("ExplosionLevel") == 2 && explosionlevel3Check.activeSelf == true)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 4000);
            PlayerPrefs.SetInt("ExplosionLevel", PlayerPrefs.GetInt("ExplosionLevel") + 1);
        }
    }

    public void OnBuyChar1Clicked()
    {
        if (PlayerPrefs.GetInt("Coins") >= 1000 && PlayerPrefs.GetInt("Char1Unlocked") == 0)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 1000);
            PlayerPrefs.SetInt("Char1Unlocked", 1);
        }
    }

    public void OnBuyChar2Clicked()
    {
        if (PlayerPrefs.GetInt("Coins") >= 2000 && PlayerPrefs.GetInt("Char2Unlocked") == 0)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 2000);
            PlayerPrefs.SetInt("Char2Unlocked", 1);
        }
    }

    public void OnBuyChar3Clicked()
    {
        if (PlayerPrefs.GetInt("Coins") >= 4000 && PlayerPrefs.GetInt("Char3Unlocked") == 0)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 4000);
            PlayerPrefs.SetInt("Char3Unlocked", 1);
        }
    }

    public void OnBuyChar4Clicked()
    {
        if (PlayerPrefs.GetInt("Coins") >= 6000 && PlayerPrefs.GetInt("Char4Unlocked") == 0)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 6000);
            PlayerPrefs.SetInt("Char4Unlocked", 1);
        }
    }

    public void OnBuyChar5Clicked()
    {
        if (PlayerPrefs.GetInt("Coins") >= 8000 && PlayerPrefs.GetInt("Char5Unlocked") == 0)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 8000);
            PlayerPrefs.SetInt("Char5Unlocked", 1);
        }
    }

    public void CharactersClicked()
    {
        if(characterPanel.activeSelf == false)
        {
            upgradesPanel.SetActive(false);
            characterPanel.SetActive(true);
            backgroundsPanel.SetActive(false);
            charactersPanelBtn.interactable = false;
            UpgradePanelBtn.interactable = true;
            backgroundsPanelBtn.interactable = true;
            cashStorePanel.SetActive(false);
            cashStorePanelBtn.interactable = true;
        }
    }

    public void UpgradesClicked()
    {
        if(upgradesPanel.activeSelf == false)
        {
            upgradesPanel.SetActive(true);
            characterPanel.SetActive(false);
            backgroundsPanel.SetActive(false);
            charactersPanelBtn.interactable = true;
            UpgradePanelBtn.interactable = false;
            backgroundsPanelBtn.interactable = true;
            cashStorePanel.SetActive(false);
            cashStorePanelBtn.interactable = true;
        }
    }

    public void BackgroundsClicked()
    {
        if (backgroundsPanel.activeSelf == false)
        {
            upgradesPanel.SetActive(false);
            characterPanel.SetActive(false);
            backgroundsPanel.SetActive(true);
            charactersPanelBtn.interactable = true;
            UpgradePanelBtn.interactable = true;
            backgroundsPanelBtn.interactable = false;
            cashStorePanel.SetActive(false);
            cashStorePanelBtn.interactable = true;
        }
    }

    public void PackClicked()
    {
        if (cashStorePanel.activeSelf == false)
        {
            upgradesPanel.SetActive(false);
            characterPanel.SetActive(false);
            backgroundsPanel.SetActive(false);
            charactersPanelBtn.interactable = true;
            UpgradePanelBtn.interactable = true;
            backgroundsPanelBtn.interactable = true;
            cashStorePanel.SetActive(true);
            cashStorePanelBtn.interactable = false;
        }
    }

    //Abilities Info
    public void OpenInfo(int ability_index){
        info_panel.SetActive(true);
        info_text.text = Descriptions[ability_index];
        info_title.text = Abilities_title[ability_index];
    }

    public void ExitInfo(){
        info_panel.SetActive(false);
    }
}
