using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private Text _coinsText;

    public static int coins = 0;

    private void Start()
    {
        _coinsText.text = Convert.ToString(coins);
    }

    private void OnEnable()
    {
        CoinController.OnCoinCollect += UpdateCoins;
    }

    private void OnDisable()
    {
        CoinController.OnCoinCollect -= UpdateCoins;
    }

    private void UpdateCoins()
    {
        coins += 1;
        _coinsText.text = Convert.ToString(coins);
    }
}
