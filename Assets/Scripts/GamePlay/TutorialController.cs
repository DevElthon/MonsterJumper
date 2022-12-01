using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    // player prefs para indicar que é tutorial 
    // principal: mostrar como se movimentar
    // Indicar que não é para encostar nos monstros
    [SerializeField]
    private GameObject rightTutorial, leftTutorial;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Tutorial"))
            PlayerPrefs.SetInt("Tutorial", 0);
    }

    public void CheckTutorialRight()
    {
        rightTutorial.SetActive(false);
        PlayerPrefs.SetInt("Tutorial", PlayerPrefs.GetInt("Tutorial") + 1);
        leftTutorial.SetActive(true);
    }

    public void CheckTutorialLeft()
    {
        if(!rightTutorial.activeSelf && leftTutorial.activeSelf)
        {
            PlayerPrefs.SetInt("Tutorial", PlayerPrefs.GetInt("Tutorial") + 1);
            leftTutorial.SetActive(false);
        }
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("Tutorial") == 2 && rightTutorial.activeSelf)
        {
            rightTutorial.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Tutorial") == 2 && leftTutorial.activeSelf)
        {
            leftTutorial.SetActive(false);
        }
    }
}