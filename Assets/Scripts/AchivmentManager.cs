using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivmentManager : MonoBehaviour
{
    private GameManager gameManagerInstance;

    void Awake()
    {
        gameManagerInstance = GameManager.instance;
    }

    void Update()
    {
        if (gameManagerInstance.inGame)
        {
            PlayServices.UnlockAchievment(MonsterJumperServices.achievement_first_jump);
        }

        if(gameManagerInstance.coins >= 200)
        {
            PlayServices.UnlockAchievment(MonsterJumperServices.achievement_collect_200_coins);
        }
    }
}
