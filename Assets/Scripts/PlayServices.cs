// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using GooglePlayGames;
// using GooglePlayGames.BasicApi;
// using UnityEngine.UI;
// using UnityEngine.SocialPlatforms;

// public class PlayServices : MonoBehaviour
// {
//     public void Start()
//     {
//         PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
//         PlayGamesPlatform.Activate();

//         Social.localUser.Authenticate(success => { });
//     }

//     internal void ProcessAuthentication(SignInStatus status)
//     {
//         if (status == SignInStatus.Success)
//         {
//             // Continue with Play Games Services
//         }
//         else
//         {
//             // Disable your integration with Play Games Services or show a login button
//             // to ask users to sign-in. Clicking it should call
//             // PlayGamesPlatform.Instance.ManuallyAuthenticate(ProcessAuthentication).
//         }
//     }

//     public static void UnlockAchievment(string id)
//     {
//         Social.ReportProgress(id, 100, success => { });
//     }

//     public static  void IncrementAchievment(string id, int steps)
//     {
//         PlayGamesPlatform.Instance.IncrementAchievement(id, steps, success => { });
//     }

//     public static void ShowAchievments()
//     {
//         Social.ShowAchievementsUI();
//     }

//     public static void PostScore(long score, string leaderBoard)
//     {
//         Social.ReportScore(score, leaderBoard, (sucess => { }));
//     }

//     public static void ShowLeaderboard(string leaderBoard)
//     {
//         PlayGamesPlatform.Instance.ShowLeaderboardUI(leaderBoard);
//     }

//     public static long GetPlayerScore(string leaderBoard)
//     {
//         long score = 0;
//         PlayGamesPlatform.Instance.LoadScores(leaderBoard, LeaderboardStart.PlayerCentered, 1, LeaderboardCollection.Public,
//             LeaderboardTimeSpan.AllTime, (LeaderboardScoreData data) => { score = data.PlayerScore.value; });
//         return score;
//     }
// }