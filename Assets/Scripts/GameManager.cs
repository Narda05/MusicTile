using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.Services.Leaderboards.Models;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen = null;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private Slider timerSlider; // Referencia al Slider en la UI
    [SerializeField] private TMP_Text scoreText;

    //Leaderboards UI update
    [Header("Leaderboard UI")]
    [SerializeField]
    private GameObject leaderboardUI;
    [SerializeField]
    private TMP_Text[] namesText;
    [SerializeField]
    private TMP_Text[] scoresText;

    private bool gameOver = false;
    private int score = -1;
    private float timeRemaining;
    private const float gameTime = 20f;

    public static GameManager Instance { get; private set; }
    public bool GameOver { get { return gameOver; } }

    void Awake()
    {
        // Aseguramos que haya una sola instancia del GameManager
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        
        gameOver = false;
        score = 0;
        gameOverScreen.SetActive(false); 
        timeRemaining = gameTime;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
    }

    void Update()
    {
        if (!gameOver)
        {
            timeRemaining -= Time.deltaTime;
            timerSlider.value = timeRemaining;
            timerText.text = " " + Mathf.CeilToInt(timeRemaining);

            if (timeRemaining <= 0)
            {
                EndGame();
            }
        }
    }

    public void EndGame()
    {
        gameOver = true;
        SendScoreToLeaderboard(); //Score to Leaderboard
        gameOverScreen.SetActive(true); 
        scoreText.text = "Final score: " + score;
    }
    public void IncScore()
    {
        score++; // Aumenta la puntuación
        scoreText.text = "Points: " + score;
    }

    public void RestartGame()
    {
        gameOver = false;
        score = 0;
        timeRemaining = gameTime;
        gameOverScreen.SetActive(false); // Desactiva el Game Over Screen
        scoreText.text = "Points: " + score;
        timerSlider.value = gameTime;
    }

    private void SendScoreToLeaderboard()
    {
        //name in the leaderboard
        UGSManager.Instance.AddScore("HighestScore", score);
    }

    public void LoadLeaderboard()
    { 
        UGSManager.Instance.GetScores("HighestScore");
    }

    public void ShowLeaderboardUI(List<LeaderboardEntry> entries)
    {
        leaderboardUI.SetActive(true);

        for (int i = 0; i < scoresText.Length; i++)
        {
            if (entries.Count <= i)
            {
               scoresText[i].text = "";
               namesText[i].text = "";
            }
            else
            {
               scoresText[i].text = entries[i].Score.ToString();
                namesText[i].text = entries[i].PlayerName.ToString().Split('#')[0];
            }
        }
    }
       

    //
    //public void Conintue()
    //{
    //    gameOver = false;
    //    gameOverScreen.SetActive(false);
    //    tree.Initialize();
    //}

}
