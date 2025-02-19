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
    public UIManager UIManager {  get { return uiManager; } } //혹시나 외부에서 UIManager를 써야할 수 도 있기 때문에 만들어 둠.
    
    private const string BestScoreKey = "BestScore";
    int bestScore = 0; //게임 중 최대 점수

    private void Start()
    {
        uiManager.UpdateScore(currentScore);
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0); //최대 스코어를 넘겨받고 없다면 디폴트 값으로 0
    }
    private void Awake()
    {
        gameManager = this; 
        uiManager = FindAnyObjectByType<UIManager>(); // 게임 전체에서 해당 오브젝트에 부착된 UIManager 스크립트 자체 가 uiManager 변수에 저장됩니다.
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//현재 열려있는 씬의 이름으로 출력을 함.
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
            Debug.Log("최고 점수 갱신");
            bestScore = currentScore;           
            PlayerPrefs.SetInt(BestScoreKey, bestScore); //딕셔너리 키 값주고 벨류값을 저장
           
        }

    }
}
