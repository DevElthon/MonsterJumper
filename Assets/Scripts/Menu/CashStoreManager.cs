using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class CashStoreManager : MonoBehaviour
{
    public void onPurchaseComplete(Product product)
    {
        if (product.definition.id.Equals("coinspack1"))
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 10000);
        }

        else if (product.definition.id.Equals("coinspack2"))
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 30000);
        }

        else if (product.definition.id.Equals("coinspack3"))
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 60000);
        }

        else if (product.definition.id.Equals("dullahanpack"))
        {
            PlayerPrefs.SetInt("Char4Unlocked", 1);
            PlayerPrefs.SetInt("Background2", 1);
            PlayerPrefs.Save();
        }

        else if (product.definition.id.Equals("maxupgrade"))
        {
            PlayerPrefs.SetInt("PointsLevel", 3);
            PlayerPrefs.SetInt("CoinsLevel", 3);
            PlayerPrefs.SetInt("InvLevel", 3);
            PlayerPrefs.Save();
        }

        PlayServices.UnlockAchievment(MonsterJumperServices.achievement_cash_knight);
    }
}