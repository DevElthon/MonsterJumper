using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject characterPanel, backgroundsPanel, arrowRight, arrowLeft;

    [SerializeField]
    private GameObject[] lore_info;
    [SerializeField]
    private GameObject lore_panel;
    private string[] Lores = new string[6]{"Place Holder lore one.","Place Holder lore two.","Place Holder lore three.","Place Holder lore four.","Place Holder lore five.","Place Holder lore six."
    };
    private string[] Lores_Background = new string[3]{"Place Holder background lore one.","Place Holder background lore two.","Place Holder background lore three."
    };
    [SerializeField]
    TextMeshProUGUI lore_text;

    [SerializeField]
    private Button charactersPanelBtn, backgroundsPanelBtn;

    [SerializeField]
    private GameObject[] SelectedCharacter, locks, equipsBTN;

    private int characterIndex;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("CharacterActive"))
            PlayerPrefs.SetInt("CharacterActive", 0);
    }

    private void Start()
    {
        characterIndex = PlayerPrefs.GetInt("CharacterActive");
    }

    private void Update()
    {
        updateCharacter();
        UpdateArrow();
        updateButtons();
        updateLocks();
    }

    private void updateCharacter()
    {
        if (!SelectedCharacter[characterIndex].activeSelf)
        {
            for (int i = 0; i < SelectedCharacter.Length; i++)
            {
                if (i == characterIndex)
                {
                    SelectedCharacter[i].SetActive(true);
                }
                else
                {
                    SelectedCharacter[i].SetActive(false);
                }
            }
        }
    }

    private void UpdateArrow()
    {
        //Right Arrow
        if (!arrowRight.activeSelf && !SelectedCharacter[SelectedCharacter.Length - 1].activeSelf)
        {
            arrowRight.SetActive(true);
        }
        else if (arrowRight.activeSelf && SelectedCharacter[SelectedCharacter.Length - 1].activeSelf)
        {
            arrowRight.SetActive(false);
        }

        //Left Arrow
        if (!arrowLeft.activeSelf && !SelectedCharacter[0].activeSelf)
        {
            arrowLeft.SetActive(true);
        }
        else if (arrowLeft.activeSelf && SelectedCharacter[0].activeSelf)
        {
            arrowLeft.SetActive(false);
        }
    }

    private void updateButtons()
    {
        for (int i = 0; i < equipsBTN.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("CharacterActive"))
            {
                equipsBTN[i].SetActive(false);
            }
            else
            {
                equipsBTN[i].SetActive(true);
            }
        }
    }

    private void updateLocks()
    {
        if (PlayerPrefs.GetInt("Char1Unlocked") == 1 && locks[1].activeSelf)
        {
            lore_info[1].SetActive(true);
            locks[1].SetActive(false);
        }

        if (PlayerPrefs.GetInt("Char2Unlocked") == 1 && locks[2].activeSelf)
        {
            lore_info[2].SetActive(true);
            locks[2].SetActive(false);
        }

        if (PlayerPrefs.GetInt("Char3Unlocked") == 1 && locks[3].activeSelf)
        {
            lore_info[3].SetActive(true);
            locks[3].SetActive(false);
        }

        if (PlayerPrefs.GetInt("Char4Unlocked") == 1 && locks[4].activeSelf)
        {
            lore_info[4].SetActive(true);
            locks[4].SetActive(false);
        }

        if (PlayerPrefs.GetInt("Char5Unlocked") == 1 && locks[5].activeSelf)
        {
            lore_info[5].SetActive(true);
            locks[5].SetActive(false);
        }
    }

    public void CharactersClicked()
    {
        if (characterPanel.activeSelf == false)
        {
            characterPanel.SetActive(true);
            backgroundsPanel.SetActive(false);
            charactersPanelBtn.interactable = false;
            backgroundsPanelBtn.interactable = true;
        }
    }

    public void BackgroundsClicked()
    {
        if (backgroundsPanel.activeSelf == false)
        {
            characterPanel.SetActive(false);
            backgroundsPanel.SetActive(true);
            charactersPanelBtn.interactable = true;
            backgroundsPanelBtn.interactable = false;
        }
    }

    public void chooseCharacterPlus()
    {
        characterIndex += 1;
        for (int i = 0; i < SelectedCharacter.Length; i++)
        {
            if (i == characterIndex)
            {
                SelectedCharacter[i].SetActive(true);
            }
            else
            {
                SelectedCharacter[i].SetActive(false);
            }
        }
    }

    public void chooseCharacterMinus()
    {
        characterIndex -= 1;
        for (int i = 0; i < SelectedCharacter.Length; i++)
        {
            if (i == characterIndex)
            {
                SelectedCharacter[i].SetActive(true);
            }
            else
            {
                SelectedCharacter[i].SetActive(false);
            }
        }
    }

    public void SelectCharacter()
    {
        if (!locks[characterIndex].activeSelf)
        {
            PlayerPrefs.SetInt("CharacterActive", characterIndex);

            for (int i = 0; i < equipsBTN.Length; i++)
            {
                if (i == characterIndex)
                {
                    equipsBTN[i].SetActive(false);
                }
                else
                {
                    equipsBTN[i].SetActive(true);
                }
            }

            GameManager.instance.CharIndex = PlayerPrefs.GetInt("CharacterActive");
            Debug.Log(GameManager.instance.CharIndex);
        }
    }

    public void Show_Lore(int index){
        lore_panel.SetActive(true);
        lore_text.text = Lores[index];
    }

    public void Show_Lore_Background(int index){
        lore_panel.SetActive(true);
        lore_text.text = Lores_Background[index];
    }

    public void Exit_Lore(){
        lore_panel.SetActive(false);
    }
}