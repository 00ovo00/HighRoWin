using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GameManager : SingletonBase<GameManager>
{
    public Action OnGameOver;

    public void GameOver()
    {
        Time.timeScale = 0;
        OnGameOver?.Invoke();
    }
}
