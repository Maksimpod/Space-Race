public class CoinController
{
    private CoinModel _coinModel;

    public CoinController(CoinModel coinModel)
    {
        _coinModel = coinModel;
    }

    public void UpdateCoins()
    {
        _coinModel.Coins += 1;
    }

    public void CalculateCoins()
    {
        _coinModel.Coins += _coinModel.GetHeightModel.Height / _coinModel.GetHeightModel.RokValue / _coinModel.RokCoinScale;
    }
}
