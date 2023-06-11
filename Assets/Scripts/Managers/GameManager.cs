using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action GameStart;

    [SerializeField] private GameObject _startButton;
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private GameObject _heightText;
    [SerializeField] private GameObject _recordScoreText;
    [SerializeField] private GameObject _pausedText;
    [SerializeField] private Image _pauseImage;

    private bool gameStarted = false;
    private bool paused = false;
    private Sprite[] pauseButtonSprites;
    void Start()
    {
        Time.timeScale = 0;
        pauseButtonSprites = Resources.LoadAll<Sprite>("pause");
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

    public void PauseResumeGame()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            paused = true;
            _pausedText.SetActive(true);
            _pauseImage.sprite = pauseButtonSprites[1];
        }
        else
        {
            Time.timeScale = 1;
            paused = false;
            _pausedText.SetActive(false);
            _pauseImage.sprite = pauseButtonSprites[0];
        }
    }
}
