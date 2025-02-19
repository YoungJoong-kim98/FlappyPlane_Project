using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    

    private int currentScore = 0;
    public static GameManager Instance { get { return gameManager; } }

    UIManager uiManager;
    public UIManager UIManager {  get { return uiManager; } } //Ȥ�ó� �ܺο��� UIManager�� ����� �� �� �ֱ� ������ ����� ��.
    
    private const string BestScoreKey = "BestScore";
    int bestScore = 0; //���� �� �ִ� ����

    private void Start()
    {
        uiManager.UpdateScore(currentScore);
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0); //�ִ� ���ھ �Ѱܹް� ���ٸ� ����Ʈ ������ 0
    }
    private void Awake()
    {
        gameManager = this; 
        uiManager = FindAnyObjectByType<UIManager>(); // ���� ��ü���� �ش� ������Ʈ�� ������ UIManager ��ũ��Ʈ ��ü �� uiManager ������ ����˴ϴ�.
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
        UpdateScore();
        uiManager.GameOverScore(currentScore, bestScore);
        uiManager.SetRestart();


    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//���� �����ִ� ���� �̸����� ����� ��.
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);
    }
    void UpdateScore()
    {
        if (bestScore < currentScore)
        {
            Debug.Log("�ְ� ���� ����");
            bestScore = currentScore;           
            PlayerPrefs.SetInt(BestScoreKey, bestScore); //��ųʸ� Ű ���ְ� �������� ����
           
        }

    }
}
