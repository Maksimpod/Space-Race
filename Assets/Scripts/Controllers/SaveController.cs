using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        PlayerPrefs.SetInt("Coins", coinModel.coins);
        PlayerPrefs.SetFloat("MaxFuel", fuelModel.MaxFuel);
    }
}
