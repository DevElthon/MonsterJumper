// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class AchivmentManager : MonoBehaviour
// {
//     private GameManager gameManagerInstance;

//     void Start()
//     {
//         gameManagerInstance = GameManager.instance;
//         if (gameManagerInstance == null)
//             return;
//     }


//     void Update()
//     {
//         if (gameManagerInstance.inGame)
//         {
//             PlayServices.UnlockAchievment(MonsterJumperServices.achievement_first_jump);
//         }

//         else if(gameManagerInstance.coins >= 200)
//         {
//             PlayServices.UnlockAchievment(MonsterJumperServices.achievement_collect_200_coins);
//         }

//         else if(PlayerPrefs.GetInt("Char1Unlocked") == 1)
//         {
//             PlayServices.UnlockAchievment(MonsterJumperServices.achievement_first_purchase);
//             PlayServices.UnlockAchievment(MonsterJumperServices.achievement_jaime_unlocked);
//         }

//         else if (PlayerPrefs.GetInt("Char2Unlocked") == 1)
//         {
//             PlayServices.UnlockAchievment(MonsterJumperServices.achievement_first_purchase);
//             PlayServices.UnlockAchievment(MonsterJumperServices.achievement_billy_unlocked);
//         }

//         else if (PlayerPrefs.GetInt("Char3Unlocked") == 1)
//         {
//             PlayServices.UnlockAchievment(MonsterJumperServices.achievement_first_purchase);
//             PlayServices.UnlockAchievment(MonsterJumperServices.achievement_chester_unlocked);
//         }

//         else if (PlayerPrefs.GetInt("Char4Unlocked") == 1)
//         {
//             PlayServices.UnlockAchievment(MonsterJumperServices.achievement_first_purchase);
//             PlayServices.UnlockAchievment(MonsterJumperServices.achievement_dullahan_unlocked);
//         }

//         else if (PlayerPrefs.GetInt("Char5Unlocked") == 1)
//         {
//             PlayServices.UnlockAchievment(MonsterJumperServices.achievement_first_purchase);
//             PlayServices.UnlockAchievment(MonsterJumperServices.achievement_gerard_unlocked);
//         }

//         else if (PlayerPrefs.GetInt("Background1") == 1)
//         {
//             PlayServices.UnlockAchievment(MonsterJumperServices.achievement_first_purchase);
//             PlayServices.UnlockAchievment(MonsterJumperServices.achievement_christmas_map_unlocked);
//         }

//         else if (PlayerPrefs.GetInt("Background2") == 1)
//         {
//             PlayServices.UnlockAchievment(MonsterJumperServices.achievement_first_purchase);
//             PlayServices.UnlockAchievment(MonsterJumperServices.achievement_castle_dungeon_unlocked);
//         }

//         else if (PlayerPrefs.GetInt("HighScore") >= 100000)
//         {
//             PlayServices.UnlockAchievment(MonsterJumperServices.achievement_apprentice_jumper);
//         }

//         else if (PlayerPrefs.GetInt("HighScore") >= 200000)
//         {
//             PlayServices.UnlockAchievment(MonsterJumperServices.achievement_adept_jumper);
//         }

//         else if (PlayerPrefs.GetInt("HighScore") >= 300000)
//         {
//             PlayServices.UnlockAchievment(MonsterJumperServices.achievement_expert_jumper);
//         }

//         else if (PlayerPrefs.GetInt("HighScore") >= 400000)
//         {
//             PlayServices.UnlockAchievment(MonsterJumperServices.achievement_master_jumper);
//         }

//         else if (PlayerPrefs.GetInt("HighScore") >= 500000)
//         {
//             PlayServices.UnlockAchievment(MonsterJumperServices.achievement_legendary_jumper);
//         }

//         else if(PlayerPrefs.GetInt("CoinsLevel") == 3 && PlayerPrefs.GetInt("PointsLevel") == 3 && PlayerPrefs.GetInt("InvLevel") == 3)
//         {
//             PlayServices.UnlockAchievment(MonsterJumperServices.achievement_max_upgrade);
//         }
        
//         //cash knight ao comprar qualquer pacote
//     }
// }
