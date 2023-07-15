using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RS2023.Scripts.Controllers
{
    public class SaveController
    {
        private HeightModel heightModel;
        private CoinModel coinModel;
        private FuelModel fuelModel;
        public SaveController(HeightModel _h, CoinModel _c, FuelModel _f)
        {
            heightModel = _h;
            coinModel = _c;
            fuelModel = _f;
        }
        public void SaveOnReload()
        {
            PlayerPrefs.SetInt("RecordHeight", heightModel.recordHeight);
            PlayerPrefs.SetInt("EngineMultiplier", heightModel.engineMultiplier);

            PlayerPrefs.SetInt("Coins", coinModel.Coins);

            PlayerPrefs.SetInt("FuelLevel", fuelModel._fuelLevel);
            PlayerPrefs.SetFloat("MaxFuel", fuelModel._maxFuel);
        }
    }
}
