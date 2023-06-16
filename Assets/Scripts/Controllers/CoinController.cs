public class CoinController
{
    private CoinModel _coinModel;

    public CoinController(CoinModel coinModel)
    {
        _coinModel = coinModel;
    }

    public void UpdateCoins()
    {
        _coinModel.coins += 1;
        _coinModel.GetHUD.UpdateCoinText(_coinModel.coins);
    }
}
