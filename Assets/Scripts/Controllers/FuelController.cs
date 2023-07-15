using System.Collections;
using UnityEngine;

namespace RS2023.Scripts.Controllers
{
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
            if (_fuelModel.FuelLeak == 0)
            {
                _fuelModel.GetHud.ActivateLeakText(true);
            }
            _fuelModel.FuelLeak += 0.3f;
        }

        public void IncreaseFuel()
        {
            _fuelModel.StartCoroutine(RefillFuel());
        }

        public void RepairLeak()
        {
            _fuelModel.FuelLeak -= 0.3f;
            if (_fuelModel.FuelLeak == 0)
            {
                _fuelModel.GetHud.ActivateLeakText(false);
            }
        }

        public IEnumerator Fuel()
        {
            yield return new WaitForSeconds(0.01f);

            while (_fuelModel.CurrentFuel > 0f)
            {
                _fuelModel.CurrentFuel -= 0.5f + _fuelModel.FuelLeak;
                yield return new WaitForSeconds(0.2f);
            }
            _fuelModel.GetGameManager.StopGame();
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

        private IEnumerator RefillFuel()
        {
            while (_fuelModel.CurrentFuel < _fuelModel._maxFuel)
            {
                _fuelModel.CurrentFuel += _fuelModel._maxFuel / 50f;
                yield return new WaitForSeconds(0.02f);
            }
        }

        private IEnumerator ReduceFuel()
        {
            double FuelReduced = 0;
            while (FuelReduced < _fuelModel._maxFuel / 5 - 0.1f)
            {
                _fuelModel.CurrentFuel -= _fuelModel._maxFuel / 250f;
                FuelReduced += _fuelModel._maxFuel / 250;
                yield return new WaitForSeconds(0.02f);
            }
        }
    }

}