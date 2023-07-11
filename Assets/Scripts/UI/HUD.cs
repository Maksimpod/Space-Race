using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _leakText;
    [SerializeField] private ParticleSystem _leakParticles;

    [SerializeField] private Text _heightText;
    [SerializeField] private Text _totalScoreText;
    [SerializeField] private Text _recordScoreText;

    [SerializeField] private Text _coinsText;

    [SerializeField] private List<GameObject> _boostRoulette;

    [SerializeField] private GameObject _startButton;

    [SerializeField] private GameObject _pauseButton;

    public void SetRecordText(int height)
    {
        _recordScoreText.text = "Record: " + height + " Rok";
    }

    public void SetHeightText(int height)
    {
        _heightText.text = height + " Rok";
    }

    public void SetTotalScoreText(int height, int recordHeight)
    {
        if (height > recordHeight)
        {
            _totalScoreText.text = "New record: " + height + " Rok!";
            _recordScoreText.text = "Record:" + height + " Rok";
        }
        else
        {
            _totalScoreText.text = "Your score: " + height + " Rok";
        }
    }
    public void ChangeScoreText()
    {
        _heightText.gameObject.SetActive(true);
        _recordScoreText.gameObject.SetActive(false);
    }

    public void StartGameGUI()
    {
        DeactivateStartButton();
        ChangeScoreText();
        ActivatePauseButton();
    }

    public void UpdateCoinText(int coins)
    {
        _coinsText.text = Convert.ToString(coins);
    }

    public void DisableBoostRoulette()
    {
        _boostRoulette[0].SetActive(false);
        _boostRoulette[1].SetActive(false);
    }
    public void UpdateFuelSlider(float currFuel, float maxFuel)
    {
        _slider.value = currFuel / maxFuel * 100;
    }
    
    private void DeactivateStartButton()
    {
        _startButton.SetActive(false);
    }

    private void ActivatePauseButton()
    {
        _pauseButton.SetActive(true);
    }

    public void ActivateLeakText(bool state)
    {
        _leakText.SetActive(state);
        if (state)
            _leakParticles.Play();
        else
            _leakParticles.Stop();
    }
}
