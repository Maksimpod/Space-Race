using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static event Action GameStart;

    [SerializeField] private GameObject _startButton;
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private GameObject _heightText;
    [SerializeField] private GameObject _recordScoreText;

    private bool gameStarted = false;
    void Start()
    {
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        FuelManager.OnRanOutOfFuel += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        FuelManager.OnRanOutOfFuel -= EnableGameOverMenu;
    }

    public void StartGame()
    {
        if (!gameStarted)
        {
            gameStarted = true;
            Time.timeScale = 1;
            _startButton.SetActive(false);
            ChangeScoreText();
        }
    }

    public void EnableGameOverMenu()
    {
        _gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ChangeScoreText()
    {
        _heightText.SetActive(true);
        _recordScoreText.SetActive(false);
    }
}
