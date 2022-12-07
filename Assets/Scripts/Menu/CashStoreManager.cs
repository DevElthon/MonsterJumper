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

        if (product.definition.id.Equals("coinspack2"))
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 30000);
        }

        if (product.definition.id.Equals("coinspack3"))
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 60000);
        }
    }
}
