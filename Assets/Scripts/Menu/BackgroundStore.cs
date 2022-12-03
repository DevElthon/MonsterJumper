using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundStore : MonoBehaviour
{
    [SerializeField]
    private GameObject buy1, buy2, buy3, buy4, arrowRight, arrowLeft;

    public static int backgroundIndex;

    [SerializeField]
    private GameObject[] selectedbackground, locks, equipsBTN;
    void Awake()
    {
        if (!PlayerPrefs.HasKey("BackgroundActive"))
            PlayerPrefs.SetInt("BackgroundActive", 0);

        if (!PlayerPrefs.HasKey("Background1"))
            PlayerPrefs.SetInt("Background1", 0);

        if (!PlayerPrefs.HasKey("Background2"))
            PlayerPrefs.SetInt("Background2", 0);

        /*
        if (!PlayerPrefs.HasKey("Background3"))
            PlayerPrefs.SetInt("Background3", 0);

        if (!PlayerPrefs.HasKey("Background4"))
            PlayerPrefs.SetInt("Background4", 0);
        */
    }

    private void Start()
    {
        backgroundIndex = PlayerPrefs.GetInt("BackgroundActive");
    }

    private void Update()
    {
        updateButtons();
        UpdateArrow();
        updateLocks();
        updateBackground();
    }

    private void updateBackground()
    {
        if (!selectedbackground[backgroundIndex].activeSelf)
        {
            for(int i = 0; i < selectedbackground.Length; i++)
            {
                if(i == backgroundIndex)
                {
                    selectedbackground[i].SetActive(true);
                }
                else
                {
                    selectedbackground[i].SetActive(false);
                }
            }
        }
    }

    private void UpdateArrow()
    {
        //Right Arrow
        if(!arrowRight.activeSelf && !selectedbackground[selectedbackground.Length - 1].activeSelf)
        {
            arrowRight.SetActive(true);
        }
        else if(arrowRight.activeSelf && selectedbackground[selectedbackground.Length - 1].activeSelf)
        {
            arrowRight.SetActive(false);
        }

        //Left Arrow
        if (!arrowLeft.activeSelf && !selectedbackground[0].activeSelf)
        {
            arrowLeft.SetActive(true);
        }
        else if (arrowLeft.activeSelf && selectedbackground[0].activeSelf)
        {
            arrowLeft.SetActive(false);
        }
    }

    private void updateButtons()
    {
        if (PlayerPrefs.GetInt("Background1") == 1 && buy1.activeSelf)
            buy1.SetActive(false);

        if (PlayerPrefs.GetInt("Background2") == 1 && buy2.activeSelf)
            buy2.SetActive(false);

        if (PlayerPrefs.GetInt("Background3") == 1 && buy3.activeSelf)
            buy3.SetActive(false);

        if (PlayerPrefs.GetInt("Background4") == 1 && buy4.activeSelf)
            buy4.SetActive(false);

        for (int i = 0; i < equipsBTN.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("BackgroundActive"))
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
        if (PlayerPrefs.GetInt("Background1") == 1 && locks[1].activeSelf)
        {
            locks[1].SetActive(false);
        }

        if (PlayerPrefs.GetInt("Background2") == 1 && locks[2].activeSelf)
        {
            locks[2].SetActive(false);
        }
    }

    public void BuyBackground(int background)
    {
        if(background == 1)
        {
            if(PlayerPrefs.GetInt("Coins") >= 5000 && PlayerPrefs.GetInt("Background1") == 0)
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 5000);
                PlayerPrefs.SetInt("Background1", 1);
            }
        }
        if (background == 2)
        {
            if (PlayerPrefs.GetInt("Coins") >= 10000 && PlayerPrefs.GetInt("Background2") == 0)
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 10000);
                PlayerPrefs.SetInt("Background2", 1);
            }
        }
        /*
        if (background == 3)
        {
            if (PlayerPrefs.GetInt("Coins") >= 1500 && PlayerPrefs.GetInt("Background3") == 0)
            {
                PlayerPrefs.SetInt("Background3", 1);
            }
        }
        if (background == 4)
        {
            if (PlayerPrefs.GetInt("Coins") >= 2000 && PlayerPrefs.GetInt("Background4") == 0)
            {
                PlayerPrefs.SetInt("Background4", 1);
            }
        }
        */
    }


    //Deveria estar no invetoryMenu, mas sem tempo irmão
    public void chooseBackgroundPlus()
    {
        backgroundIndex += 1;
        for(int i = 0; i < selectedbackground.Length; i++)
        {
            if(i == backgroundIndex)
            {
                selectedbackground[i].SetActive(true);
            }
            else
            {
                selectedbackground[i].SetActive(false);
            }
        }
    }

    public void chooseBackgroundMinus()
    {
        backgroundIndex -= 1;
        for (int i = 0; i < selectedbackground.Length; i++)
        {
            if (i == backgroundIndex)
            {
                selectedbackground[i].SetActive(true);
            }
            else
            {
                selectedbackground[i].SetActive(false);
            }
        }
    }

    public void SelectBackground()
    {
        if (!locks[backgroundIndex].activeSelf)
        {
            PlayerPrefs.SetInt("BackgroundActive", backgroundIndex);

            for(int i = 0; i < equipsBTN.Length; i++)
            {
                if(i == backgroundIndex)
                {
                    equipsBTN[i].SetActive(false);
                }
                else
                {
                    equipsBTN[i].SetActive(true);
                }
            }
        }
    }
}
