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
}
