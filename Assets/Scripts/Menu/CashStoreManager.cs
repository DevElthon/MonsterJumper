using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class CashStoreManager : MonoBehaviour
{
    public void onPurchaseComplete(Product product)
    {
        if (product.definition.id.Equals("dullahanpack"))
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

        else if(product.definition.id.Equals("freead")){
            PlayerPrefs.SetInt("Freead", 1);
        }

        // PlayServices.UnlockAchievment(MonsterJumperServices.achievement_cash_knight);
    }
}