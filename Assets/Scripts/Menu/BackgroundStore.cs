using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundStore : MonoBehaviour
{
    [SerializeField]
    private GameObject buy1, buy2, buy3, buy4;
    void Awake()
    {
        if (!PlayerPrefs.HasKey("Background1"))
            PlayerPrefs.SetInt("Background1", 0);

        if (!PlayerPrefs.HasKey("Background2"))
            PlayerPrefs.SetInt("Background2", 0);

        if (!PlayerPrefs.HasKey("Background3"))
            PlayerPrefs.SetInt("Background3", 0);

        if (!PlayerPrefs.HasKey("Background4"))
            PlayerPrefs.SetInt("Background4", 0);
    }

    private void Update()
    {
        updateButtons();
    }

    public void updateButtons()
    {
        if (PlayerPrefs.GetInt("Background1") == 1 && buy1.activeSelf)
            buy1.SetActive(false);

        if (PlayerPrefs.GetInt("Background2") == 1 && buy2.activeSelf)
            buy2.SetActive(false);

        if (PlayerPrefs.GetInt("Background3") == 1 && buy3.activeSelf)
            buy3.SetActive(false);

        if (PlayerPrefs.GetInt("Background4") == 1 && buy4.activeSelf)
            buy4.SetActive(false);
    }

    public void BuyBackground(int background)
    {
        if(background == 1)
        {
            if(PlayerPrefs.GetInt("Coins") >= 500 && PlayerPrefs.GetInt("Background1") == 0)
            {
                PlayerPrefs.SetInt("Background1", 1);
            }
        }
        if (background == 2)
        {
            if (PlayerPrefs.GetInt("Coins") >= 1000 && PlayerPrefs.GetInt("Background2") == 0)
            {
                PlayerPrefs.SetInt("Background2", 1);
            }
        }
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
    }

    public void chooseBackground(int backgroundindex)
    {
        BuyBackground(backgroundindex);
    }
}
