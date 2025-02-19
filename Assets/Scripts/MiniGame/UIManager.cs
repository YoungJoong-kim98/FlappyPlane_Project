using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI bestscoreText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GameOverScoreText;
    public GameObject gameoverUI;
    void Start()
    {
        if (bestscoreText == null)
            Debug.Log("bestScore text is null");

        if (scoreText == null)
            Debug.Log("score text is null");
        if (GameOverScoreText == null)
            Debug.Log("GameOverScore text is null");
        gameoverUI.SetActive(false);
    }


    public void SetRestart()
    {
        //restartText.gameObject.SetActive(true);
        gameoverUI.SetActive(true);
    }
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void GameOverScore(int score, int bestscore)
    {
        bestscoreText.text = bestscore.ToString();
        GameOverScoreText.text = score.ToString();
    }
}
