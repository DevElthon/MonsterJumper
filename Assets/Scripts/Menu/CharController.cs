using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharController : MonoBehaviour
{
    [SerializeField]
    GameObject lock1, lock2, lock3;
    [SerializeField]
    Button char1, char2, char3;

    [SerializeField]
    GameObject buychar1, buychar2, buychar3;
    private void Update()
    {
        if(PlayerPrefs.GetInt("Char1Unlocked") == 1 && lock1.activeSelf)
        {
            lock1.SetActive(false);
            char1.enabled = true;
            buychar1.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Char2Unlocked") == 1 && lock2.activeSelf)
        {
            lock2.SetActive(false);
            char2.enabled = true;
            buychar2.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Char3Unlocked") == 1 && lock3.activeSelf)
        {
            lock3.SetActive(false);
            char3.enabled = true;
            buychar3.SetActive(false);
        }
    }
}
