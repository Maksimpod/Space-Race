using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private float currentFuel = 100f;
    public static event Action OnRanOutOfFuel;

    private void Start()
    {
        StartCoroutine(Fuel());
    }
    public void DecreaseFuel()
    {
        currentFuel -= 20f;
        _slider.value = currentFuel;
    }

    public void IncreaseFuel()
    {
        currentFuel = 100f;
        _slider.value = currentFuel;
    }

    private void OnEnable()
    {
        FuelController.OnFuelCollect += IncreaseFuel;
    }

    private void OnDisable()
    {
        FuelController.OnFuelCollect -= IncreaseFuel;
    }

    IEnumerator Fuel()
    {
        yield return new WaitForSeconds(0.01f);
        while (currentFuel > 0f)
        {
            currentFuel -= 0.5f;
            _slider.value = currentFuel;
            yield return new WaitForSeconds(0.2f);
        }
        OnRanOutOfFuel?.Invoke();
    }
}
