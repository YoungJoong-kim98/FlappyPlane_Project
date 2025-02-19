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


    private void Start()
    {
        uiManager.UpdateScore(currentScore);
    }
    private void Awake()
    {
        gameManager = this; 
        uiManager = FindAnyObjectByType<UIManager>(); // 게임 전체에서 해당 오브젝트에 부착된 UIManager 스크립트 자체 가 uiManager 변수에 저장됩니다.
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
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

}
