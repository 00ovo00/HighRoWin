using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class GameManager : SingletonBase<GameManager>
{
    public Action OnGameOver;
    private bool isPlaying = false;

    public void GameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isPlaying = true;
        Time.timeScale = 1.0f;
    }
    
    public void GameOver()
    {
        isPlaying = false;
        //Time.timeScale = 0.0f;
        OnGameOver?.Invoke();
    }
}
