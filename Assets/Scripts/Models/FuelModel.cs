using UnityEngine;
using UnityEngine.UI;

public class FuelModel : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private HUD _hud;
    [SerializeField] private UIShop _shopMenu;
    [SerializeField] private HeightModel _heightModel;
    [SerializeField] private Button _fuelUpgradeButton;
    [SerializeField] private CoinModel _coinModel;
    [SerializeField] private GameManager _gameManager;

    private FuelController _fuelController;

    private float _currentFuel = 100f;

    public HUD GetHud => _hud;
    public UIShop GetShopMenu => _shopMenu;
    public HeightModel GetHeightModel => _heightModel;
    public FuelController GetFuelController => _fuelController;
    public Button FuelUpgradeButton => _fuelUpgradeButton;

    public CoinModel GetCoinModel => _coinModel;
    public GameManager GetGameManager => _gameManager;

    public float CurrentFuel { 
        get { return _currentFuel; }
        set
        {
            _currentFuel = value > _maxFuel ? _maxFuel + 0.01f : value;
            _hud.UpdateFuelSlider(_currentFuel, _maxFuel);
        }
    }
    public float FuelLeak { get; set; } = 0f;
    public float _maxFuel { get; set; } = 100f;
    public int _fuelLevel { get; set; } = 1;


    private void Start()
    {
        _fuelController = new FuelController(this);

        _maxFuel = PlayerPrefs.GetFloat("MaxFuel", _maxFuel);
        _fuelLevel = PlayerPrefs.GetInt("FuelLevel", _fuelLevel);

        _currentFuel = _maxFuel;

        _fuelController.InitializeUpgradeButton();

        StartCoroutine(_fuelController.Fuel());
    }
}
