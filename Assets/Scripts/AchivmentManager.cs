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

    void CreateConquests()
    {
        if (!PlayerPrefs.HasKey("Conquista1"))
            PlayerPrefs.SetInt("Conquista1", 0);

        if (!PlayerPrefs.HasKey("Conquista2"))
            PlayerPrefs.SetInt("Conquista2", 0);

        if (!PlayerPrefs.HasKey("Conquista3"))
            PlayerPrefs.SetInt("Conquista3", 0);

        if (!PlayerPrefs.HasKey("Conquista4"))
            PlayerPrefs.SetInt("Conquista4", 0);

        if (!PlayerPrefs.HasKey("Conquista5"))
            PlayerPrefs.SetInt("Conquista5", 0);

        if (!PlayerPrefs.HasKey("Conquista6"))
            PlayerPrefs.SetInt("Conquista6", 0);

        if (!PlayerPrefs.HasKey("Conquista7"))
            PlayerPrefs.SetInt("Conquista7", 0);

        if (!PlayerPrefs.HasKey("Conquista8"))
            PlayerPrefs.SetInt("Conquista8", 0);

        if (!PlayerPrefs.HasKey("Conquista9"))
            PlayerPrefs.SetInt("Conquista9", 0);

        if (!PlayerPrefs.HasKey("Conquista10"))
            PlayerPrefs.SetInt("Conquista10", 0);

        if (!PlayerPrefs.HasKey("Conquista11"))
            PlayerPrefs.SetInt("Conquista11", 0);

        if (!PlayerPrefs.HasKey("Conquista12"))
            PlayerPrefs.SetInt("Conquista12", 0);

        if (!PlayerPrefs.HasKey("Conquista13"))
            PlayerPrefs.SetInt("Conquista13", 0);

        if (!PlayerPrefs.HasKey("Conquista14"))
            PlayerPrefs.SetInt("Conquista14", 0);

        if (!PlayerPrefs.HasKey("Conquista15"))
            PlayerPrefs.SetInt("Conquista15", 0);
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

        if(PlayerPrefs.GetInt("Char1Unlocked") == 1)
        {
            PlayServices.UnlockAchievment(MonsterJumperServices.achievement_first_purchase);
            PlayServices.UnlockAchievment(MonsterJumperServices.achievement_jaime_unlocked);
        }

        if (PlayerPrefs.GetInt("Char2Unlocked") == 1)
        {
            PlayServices.UnlockAchievment(MonsterJumperServices.achievement_first_purchase);
            PlayServices.UnlockAchievment(MonsterJumperServices.achievement_billy_unlocked);
        }

        if (PlayerPrefs.GetInt("Char3Unlocked") == 1)
        {
            PlayServices.UnlockAchievment(MonsterJumperServices.achievement_first_purchase);
            PlayServices.UnlockAchievment(MonsterJumperServices.achievement_chester_unlocked);
        }

        if (PlayerPrefs.GetInt("Char4Unlocked") == 1)
        {
            PlayServices.UnlockAchievment(MonsterJumperServices.achievement_first_purchase);
            PlayServices.UnlockAchievment(MonsterJumperServices.achievement_dullahan_unlocked);
        }

        if (PlayerPrefs.GetInt("Char5Unlocked") == 1)
        {
            PlayServices.UnlockAchievment(MonsterJumperServices.achievement_first_purchase);
            PlayServices.UnlockAchievment(MonsterJumperServices.achievement_gerard_unlocked);
        }

        if (PlayerPrefs.GetInt("Background1") == 1)
        {
            PlayServices.UnlockAchievment(MonsterJumperServices.achievement_first_purchase);
            PlayServices.UnlockAchievment(MonsterJumperServices.achievement_christmas_map_unlocked);
        }

        if (PlayerPrefs.GetInt("Background2") == 1)
        {
            PlayServices.UnlockAchievment(MonsterJumperServices.achievement_first_purchase);
            PlayServices.UnlockAchievment(MonsterJumperServices.achievement_castle_dungeon_unlocked);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 100000)
        {
            PlayServices.UnlockAchievment(MonsterJumperServices.achievement_apprentice_jumper);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 200000)
        {
            PlayServices.UnlockAchievment(MonsterJumperServices.achievement_adept_jumper);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 300000)
        {
            PlayServices.UnlockAchievment(MonsterJumperServices.achievement_expert_jumper);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 400000)
        {
            PlayServices.UnlockAchievment(MonsterJumperServices.achievement_master_jumper);
        }

        if (PlayerPrefs.GetInt("HighScore") >= 500000)
        {
            PlayServices.UnlockAchievment(MonsterJumperServices.achievement_legendary_jumper);
        }

        if(PlayerPrefs.GetInt("CoinsLevel") == 3 && PlayerPrefs.GetInt("PointsLevel") == 3 && PlayerPrefs.GetInt("InvLevel") == 3)
        {
            PlayServices.UnlockAchievment(MonsterJumperServices.achievement_max_upgrade);
        }
        
        //cash knight ao comprar qualquer pacote
    }
}
