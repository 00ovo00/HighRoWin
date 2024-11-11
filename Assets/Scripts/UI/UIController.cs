using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject gameOverBG;
    public TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        GameManager.Instance.OnGameOver -= SettingGameOverPopup;
        GameManager.Instance.OnGameOver += SettingGameOverPopup;

        DataManager.Instance.OnScoreChanged -= UpdateScoreTxt;
        DataManager.Instance.OnScoreChanged += UpdateScoreTxt;
    }

    private void Start()
    {
        gameOverBG.SetActive(false);
    }

    private void SettingGameOverPopup()
    {
        gameOverBG.SetActive(true);
    }
    
    private void UpdateScoreTxt()
    {
        scoreText.text = $"Score: {DataManager.Instance.RowCount.ToString()}";
    }
}
