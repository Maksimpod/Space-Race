using System.Collections;
using UnityEngine;

public class FuelController 
{
    private FuelModel _fuelModel;

    public FuelController(FuelModel fuelModel)
    {
        _fuelModel = fuelModel;
    }
    public void DecreaseFuel()
    {
        _fuelModel._currentFuel -= 20f;
        _fuelModel.GetHUD.UpdateFuelHUD(_fuelModel._currentFuel, _fuelModel.MaxFuel);
    }

    public void IncreaseFuel()
    {
        _fuelModel._currentFuel = _fuelModel.MaxFuel;
        _fuelModel.GetHUD.UpdateFuelHUD(_fuelModel._currentFuel, _fuelModel.MaxFuel);
    }

    public IEnumerator Fuel()
    {
        yield return new WaitForSeconds(0.01f);

        while (_fuelModel._currentFuel > 0f)
        {
            _fuelModel._currentFuel -= 0.5f;
            _fuelModel.GetHUD.UpdateFuelHUD(_fuelModel._currentFuel, _fuelModel.MaxFuel);
            yield return new WaitForSeconds(0.2f);
        }
        _fuelModel.GameOverMenu.EnableGameOverMenu();
        _fuelModel.GetHeightModel.GetHeightController.UpdateTotalScore();
    }
}
