using System.Collections;
using UnityEngine;

public class FuelController 
{
    private FuelModel _fuelModel;

    public FuelController(FuelModel fuelModel)
    {
        _fuelModel = fuelModel;
    }

    public void InitializeUpgradeButton()
    {
        _fuelModel.FuelUpgradeButton.onClick.AddListener(UpgradeFuel);
        _fuelModel.GetShopMenu.UpdateFuelText(_fuelModel._fuelLevel);
    }

    public void DecreaseFuel()
    {
        _fuelModel.CurrentFuel -= _fuelModel._maxFuel / 5;
    }

    public void IncreaseFuel()
    {
        _fuelModel.CurrentFuel = _fuelModel._maxFuel;
    }

    public IEnumerator Fuel()
    {
        yield return new WaitForSeconds(0.01f);

        while (_fuelModel.CurrentFuel > 0f)
        {
            _fuelModel.CurrentFuel -= 0.5f;
            yield return new WaitForSeconds(0.2f);
        }
        _fuelModel.GameOverMenu.EnableGameOverMenu();
        _fuelModel.GetHeightModel.GetHeightController.UpdateTotalScore();
    }

    public void UpgradeFuel()
    {
        if (_fuelModel.GetCoinModel.Coins >= _fuelModel._fuelLevel)
        {
            _fuelModel.GetCoinModel.Coins -= _fuelModel._fuelLevel;
            _fuelModel._maxFuel += 50;
            _fuelModel._fuelLevel += 1;
            _fuelModel.GetShopMenu.UpdateFuelText(_fuelModel._fuelLevel);
        }
    }
}
