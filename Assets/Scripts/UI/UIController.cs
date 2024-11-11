using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject gameOverBG;
    public TextMeshProUGUI curScoreText;
    public TextMeshProUGUI endScoreText;
    public Button retryButton;
    
    private void OnEnable()
    {
        GameManager.Instance.OnGameOver -= SettingGameOverPopup;
        GameManager.Instance.OnGameOver += SettingGameOverPopup;

        DataManager.Instance.OnScoreChanged -= UpdateScoreTxt;
        DataManager.Instance.OnScoreChanged += UpdateScoreTxt;
        
        retryButton.onClick.AddListener((() =>
        {
            GameManager.Instance.GameStart();
        }));
    }

    private void Start()
    {
        gameOverBG.SetActive(false);
    }

    private void SettingGameOverPopup()
    {
        endScoreText.text = curScoreText.text.Substring(5);
        gameOverBG.SetActive(true);
    }
    
    private void UpdateScoreTxt()
    {
        curScoreText.text = $"Row: {DataManager.Instance.RowCount.ToString()}";
    }
}
