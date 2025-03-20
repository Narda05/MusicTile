using UnityEngine;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using System.Threading.Tasks;
using Unity.Services.Leaderboards;
using Newtonsoft.Json;
using NUnit.Framework;
using Unity.Services.Leaderboards.Models;
using System.Collections.Generic;



public class UGSManager : MonoBehaviour
{
    public static UGSManager Instance;

    private async void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            Debug.Log("¨Production environment loading...");
            var options = new InitializationOptions();
            options.SetEnvironmentName("production");
            await UnityServices.InitializeAsync(options);
            Debug.Log("¨Production environment loaded!");

            await SingUpAnonymouslyAsync();

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    async Task SingUpAnonymouslyAsync()
    {
        //Clearing session allows multiple scores submitted on the same computer (after a restart)
        AuthenticationService.Instance.ClearSessionToken();
        

        // Create a profile for the player to quickly start playing. 
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
        Debug.Log("Signed in as guest!");

        string randomName = "Guest" + Random.Range(1, 9999);

        //Change the name of the player
        await AuthenticationService.Instance.UpdatePlayerNameAsync(randomName);
        Debug.Log($"Player Name: {AuthenticationService.Instance.PlayerName}");

    }

    public async void AddScore(string leaderboardId, int score)
    {
        Debug.Log("Adding score to UGS Leaderboard...");
        var playerEntry = await LeaderboardsService.Instance.AddPlayerScoreAsync(leaderboardId, score);
        Debug.Log(JsonConvert.SerializeObject(playerEntry));
    }
    public async void GetScores(string leaderboardId)
    {
        Debug.Log("Loading player scores...");
        var scoreResponse = await LeaderboardsService.Instance.GetScoresAsync(leaderboardId);
        Debug.Log(JsonConvert.SerializeObject(scoreResponse));

        List<LeaderboardEntry> entries = scoreResponse.Results;

        foreach (var entry in entries)
        {
            Debug.Log($"Name: {entry.PlayerName},{entry.Score}");
        }

        GameObject g = GameObject.FindGameObjectWithTag("GameController");
        g.GetComponent<GameManager>().ShowLeaderboardUI(entries);

    }

}
