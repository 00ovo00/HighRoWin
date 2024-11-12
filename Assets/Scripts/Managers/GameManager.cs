using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBase<GameManager>
{
    public Action OnGameOver;
    private bool isPlaying = false;
    
    private void Start()
    {
        SoundManager.Instance.PlayStartBGM();
    }

    public void GameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isPlaying = true;
        Time.timeScale = 1.0f;
    }
    
    public void GameOver()
    {
        isPlaying = false;
        OnGameOver?.Invoke();
    }
}
