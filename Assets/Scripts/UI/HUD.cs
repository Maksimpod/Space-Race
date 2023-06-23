using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _fuelValue;

    [SerializeField] private Text _heightText;
    [SerializeField] private Text _totalScoreText;
    [SerializeField] private Text _recordScoreText;

    [SerializeField] private Text _coinsText;

    [SerializeField] private List<GameObject> _boosts;

    [SerializeField] private GameObject _startButton;

    public void SetRecordText(int height)
    {
        _recordScoreText.text = "Record: " + height + "m";
    }

    public void SetHeightText(int height)
    {
        _heightText.text = height + "m";
    }

    public void SetTotalScoreText(int height, int recordHeight)
    {
        if (height > recordHeight)
        {
            _totalScoreText.text = "New record: " + height + "m!";
            _recordScoreText.text = "Record:" + height + "m";
        }
        else
        {
            _totalScoreText.text = "Your score: " + height + "m";
        }
    }

    public void ChangeScoreText()
    {
        _heightText.gameObject.SetActive(true);
        _recordScoreText.gameObject.SetActive(false);
    }

    public void UpdateCoinText(int coins)
    {
        _coinsText.text = Convert.ToString(coins);
    }

    public void DisableBoostButtons ()
    {
        for (int i = 0; i < _boosts.Count; i++)
        {
            _boosts[i].SetActive(false);
        }
    }
    public void UpdateFuelHUD(float currFuel, float maxFuel)
    {
        _slider.value = currFuel;
        _fuelValue.text = Convert.ToString(currFuel > 0 ? currFuel / maxFuel * 100 : 0);
    }
    
    public void DeactivateStartButton()
    {
        _startButton.SetActive(false);
    }
}
