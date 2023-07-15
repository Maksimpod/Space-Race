using RS2023.Scripts.Controllers;
using UnityEngine;

public class CoinModel : MonoBehaviour
{
    [SerializeField] private HUD _hud;
    [SerializeField] private HeightModel _heightModel;
    [SerializeField] private int _rockCoinScale;

    private CoinController _coinController;

    private int _coins = 0;

    public CoinController GetCoinController => _coinController;
    public HeightModel GetHeightModel => _heightModel;

    public int RokCoinScale => _rockCoinScale;

    public int Coins { 
        get { return _coins;} 
        set {
            _coins = value;
            _hud.UpdateCoinText(_coins);
        }
    }

    private void Start()
    {
        _coinController = new CoinController(this);

        Coins = PlayerPrefs.GetInt("Coins", Coins);
    }
}
