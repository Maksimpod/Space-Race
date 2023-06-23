using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIShop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _engineUpgradeText;
    [SerializeField] private TextMeshProUGUI _fuelUpgradeText;

    public void UpdateEngineText(int level)
    {
        _engineUpgradeText.text = "Engine Lv. " + level;
    }

    public void UpdateFuelText(int level)
    {
        _fuelUpgradeText.text = "Fuel Lv. " + level;
    }
}
