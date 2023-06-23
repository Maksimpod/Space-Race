using UnityEngine;

public class CoinModel : MonoBehaviour
{
    [SerializeField] private HUD _hud;

    private CoinController _coinController;

    public HUD GetHUD => _hud;
    public CoinController GetCoinController => _coinController;
    public int coins { get; set; } = 0;

    private void Start()
    {
        _coinController = new CoinController(this);

        coins = PlayerPrefs.GetInt("Coins");
        _coinController.UpdateCoins();
    }
}
