using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    // player prefs para indicar que é tutorial 
    // principal: mostrar como se movimentar
    // Indicar que não é para encostar nos monstros
    [SerializeField]
    private GameObject rightTutorial, leftTutorial, zombiePrefab, skeletonPrefab, message;

    [SerializeField]
    Transform spawnLefttransform, spawnRightTransform;

    private GameObject spawnZombie, spawnSkeleton;
    bool zombieActive = false;

    public static float RightTimer = 0;
    public static float LeftTimer = 0;

    private void Awake()
    {
        //PlayerPrefs.SetInt("Tutorial", 0 );
        if(PlayerPrefs.GetInt("Tutorial") == 3)
        {
            rightTutorial.SetActive(false);
            leftTutorial.SetActive(false);
            this.gameObject.GetComponent<TutorialController>().enabled = false;
        }

        else
        {
            PlayerPrefs.SetInt("Tutorial", 0);
            zombieActive = false;
        }
    }

    public void CheckTutorialRight()
    {
        if(rightTutorial.activeSelf && !leftTutorial.activeSelf)
        {
            if(RightTimer >= 2)
            {
                rightTutorial.SetActive(false);
                PlayerPrefs.SetInt("Tutorial", 1);
                leftTutorial.SetActive(true);
            }
        }
    }

    public void CheckTutorialLeft()
    {
        if(!rightTutorial.activeSelf && leftTutorial.activeSelf)
        {
            if (LeftTimer >= 2)
            {
                PlayerPrefs.SetInt("Tutorial", 2);
                leftTutorial.SetActive(false);
            }
        }
    }

    private void LateUpdate()
    {
        if(RightTimer >= 2 && rightTutorial.activeSelf)
        {
            rightTutorial.SetActive(false);
            PlayerPrefs.SetInt("Tutorial", 1);
            leftTutorial.SetActive(true);
        }

        if(LeftTimer >= 2 && leftTutorial.activeSelf)
        {
            PlayerPrefs.SetInt("Tutorial", 2);
            leftTutorial.SetActive(false);
        }

        if(PlayerPrefs.GetInt("Tutorial") == 2 && !zombieActive && !rightTutorial.activeSelf && !leftTutorial.activeSelf)
        {
            zombieActive = true;
            spawnZombie = Instantiate(zombiePrefab);
            spawnZombie.transform.position = new Vector3(spawnLefttransform.position.x + 4, spawnZombie.transform.position.y, spawnZombie.transform.position.z);
            spawnZombie.GetComponent<Monster>().speed = 3;

            spawnSkeleton = Instantiate(skeletonPrefab);
            spawnSkeleton.transform.position = new Vector3(spawnRightTransform.position.x, spawnSkeleton.transform.position.y, spawnSkeleton.transform.position.z);
            spawnSkeleton.transform.localScale = new Vector3(spawnSkeleton.transform.localScale.x * -1, spawnSkeleton.transform.localScale.y, spawnSkeleton.transform.localScale.z);
            spawnSkeleton.GetComponent<Monster>().speed = -3;
            message.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("Tutorial") != 3 && PlayerPrefs.GetInt("Tutorial") != 0)
        {
            RightTimer = 0;
            PlayerPrefs.SetInt("Tutorial", 0);
            LeftTimer = 0;
        }

        if(PlayerPrefs.GetInt("Tutorial") == 1 && rightTutorial.activeSelf)
        {
            rightTutorial.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Tutorial") == 2 && leftTutorial.activeSelf)
        {
            leftTutorial.SetActive(false);
        }

        if(PlayerPrefs.GetInt("Tutorial") == 3 && zombieActive)
        {
            Destroy(spawnZombie);
            Destroy(spawnSkeleton);
            zombieActive = false;
        }
    }

    public void ExitMessage()
    {
        message.SetActive(false);
        Time.timeScale = 1;
    }
}