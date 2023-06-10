using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightManager : MonoBehaviour
{
    public static Action<int> OnHeightReached;

    [SerializeField] private Text _text;
    [SerializeField] private Text _totalScoreText;
    [SerializeField] private Text _recordScoreText;

    [SerializeField] private List<GameObject> _boosts;

    private int height = 0;
    private static int recordHeight = 0;
    private int triggerIndex = 0;

    private void Start()
    {
        _recordScoreText.text = "Record: " + recordHeight + "m";
        StartCoroutine(Score());
    }

    IEnumerator Score()
    {
        yield return new WaitForSeconds(0.01f);
        while (true)
        {
            height += 1;
            _text.text = height + "m";
            // TODO: запихнуть условия в карутину?
            if(height > 200 && triggerIndex == 0)
            {
                OnHeightReached?.Invoke(0);
                triggerIndex += 1;
            }
            else if (height > 500 && triggerIndex == 1)
            {
                OnHeightReached?.Invoke(1);
                triggerIndex += 1;
            }
            else if (height > 800 && triggerIndex == 2)
            {
                OnHeightReached?.Invoke(2);
                triggerIndex += 1;
            }
            else if (height > 1500 && triggerIndex == 3)
            {
                OnHeightReached?.Invoke(3);
                triggerIndex += 1;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnEnable()
    {
        FuelManager.OnRanOutOfFuel += SetTotalScoreText;
    }

    private void OnDisable()
    {
        FuelManager.OnRanOutOfFuel -= SetTotalScoreText;
    }

    public void SetTotalScoreText()
    {
        if(height > recordHeight)
        {
            _totalScoreText.text = "New record: " + height + "m!";
            recordHeight = height;
            _recordScoreText.text = "Record:" + height + "m";
        }
        else
        {
            _totalScoreText.text = "Your score: " + height + "m";
        } 
    }

    public void BoostOnStart(int multiplier)
    {
        StartCoroutine(ScoreBooster(multiplier));
        DisableBoostButtons();
    }

    public void DisableBoostButtons()
    {
        for (int i = 0; i < _boosts.Count; i++)
        {
            _boosts[i].SetActive(false);
        }
    }

    IEnumerator ScoreBooster(int multiplier)
    {
        yield return new WaitForSeconds(0.01f);
        while (height <= 50 * multiplier)
        {
            height += 1;
            _text.text = height + "m";
            yield return new WaitForSeconds(0.035f/multiplier);
        }
    }
}
