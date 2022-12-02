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

    public static float RightTimer = 0;
    public static float LeftTimer = 0;

    private void Awake()
    {
        //PlayerPrefs.SetInt("Tutorial", 0 );
        if(PlayerPrefs.GetInt("Tutorial") == 2)
        {
            rightTutorial.SetActive(false);
            leftTutorial.SetActive(false);
            this.gameObject.GetComponent<TutorialController>().enabled = false;
        }
    }

    public void CheckTutorialRight()
    {
        if(rightTutorial.activeSelf && !leftTutorial.activeSelf)
        {
            if(RightTimer >= 3)
            {
                rightTutorial.SetActive(false);
                PlayerPrefs.SetInt("Tutorial", PlayerPrefs.GetInt("Tutorial") + 1);
                leftTutorial.SetActive(true);
            }
        }
    }

    public void CheckTutorialLeft()
    {
        if(!rightTutorial.activeSelf && leftTutorial.activeSelf)
        {
            if (LeftTimer >= 3)
            {
                PlayerPrefs.SetInt("Tutorial", PlayerPrefs.GetInt("Tutorial") + 1);
                leftTutorial.SetActive(false);
            }
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