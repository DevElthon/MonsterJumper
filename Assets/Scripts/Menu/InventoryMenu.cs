using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject characterPanel, backgroundsPanel, arrowRight, arrowLeft;

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
            locks[1].SetActive(false);
        }

        if (PlayerPrefs.GetInt("Char2Unlocked") == 1 && locks[2].activeSelf)
        {
            locks[2].SetActive(false);
        }

        if (PlayerPrefs.GetInt("Char3Unlocked") == 1 && locks[3].activeSelf)
        {
            locks[3].SetActive(false);
        }

        if (PlayerPrefs.GetInt("Char5Unlocked") == 1 && locks[4].activeSelf)
        {
            locks[4].SetActive(false);
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
}