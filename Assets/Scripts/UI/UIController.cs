using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject gameOverBG;

    private void OnEnable()
    {
        GameManager.Instance.OnGameOver -= SettingGameOverPopup;
        GameManager.Instance.OnGameOver += SettingGameOverPopup;
    }

    private void Start()
    {
        gameOverBG.SetActive(false);
    }

    private void SettingGameOverPopup()
    {
        gameOverBG.SetActive(true);
    }
}
