using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RockDestroy : MonoBehaviour
{
    public int Score;
    public int bestScore;
    public TextMeshProUGUI bestscoreText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GameScoreText;

    public GameObject GameOverUI;
    private const string MiniGame2BestScore = "MiniGame2";
    public static RockDestroy Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // 이미 존재하면 삭제
        }
    }
    private void Start()
    {
        Time.timeScale = 1f;
        Score = 0;
        GameOverUI.SetActive(false);
        bestScore = PlayerPrefs.GetInt(MiniGame2BestScore);
    }
    
    public void GamveOver()
    {
        EndScore();
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rock"))
        {
            Score++;
            UpdateScore();
            Destroy(other.gameObject);
        }
    }

    private void UpdateScore()
    {
        GameScoreText.text = Score.ToString();
    }
    private void EndScore()
    {
        if(bestScore<Score)
        {
            bestScore = Score;
        }
        scoreText.text = Score.ToString();
        bestscoreText.text = bestScore.ToString();
        PlayerPrefs.SetInt(MiniGame2BestScore, bestScore);
        PlayerPrefs.Save();
    }
}
