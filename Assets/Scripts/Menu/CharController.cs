using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharController : MonoBehaviour
{
    [SerializeField]
    GameObject buychar1, buychar2, buychar3, buychar4, buychar5;
    private void Update()
    {
        if(PlayerPrefs.GetInt("Char1Unlocked") == 1 && buychar1.activeSelf)
        {
            buychar1.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Char2Unlocked") == 1 && buychar2.activeSelf)
        {
            buychar2.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Char3Unlocked") == 1 && buychar3.activeSelf)
        {
            buychar3.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Char4Unlocked") == 1 && buychar4.activeSelf)
        {
            buychar4.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Char5Unlocked") == 1 && buychar5.activeSelf)
        {
            buychar5.SetActive(false);
        }
    }
}
