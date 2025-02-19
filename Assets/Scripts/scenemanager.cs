using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scenemanager : MonoBehaviour
{
    public void MiniGameScene()
    {
        SceneManager.LoadScene("GameScene");  
    }
    public void MainScene()
    {
        SceneManager.LoadScene("MainScene");

    }
}
