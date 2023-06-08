using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private float currentFuel = 100f;

    private void Start()
    {
        StartCoroutine(Fuel());
    }
    public void DecreaseFuel()
    {
        currentFuel -= 20f;
        _slider.value = currentFuel;
        Debug.Log("fuel decreased");
    }

    IEnumerator Fuel()
    {
        while (currentFuel > 0f)
        {
            currentFuel -= 1f;
            _slider.value = currentFuel;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
