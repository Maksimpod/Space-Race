using UnityEngine;

public class FuelModel : MonoBehaviour
{
    [Header("Fuel data")]
    [SerializeField] private float _maxFuel = 100f;

    [Header("Links")]
    [SerializeField] GameOverMenu _gameOverMenu;
    [SerializeField] private HUD _hud;
    [SerializeField] private HeightModel _heightModel;

    private FuelController _fuelController;

    public float MaxFuel => _maxFuel;
    public GameOverMenu GameOverMenu => _gameOverMenu;
    public HUD GetHUD => _hud;
    public HeightModel GetHeightModel => _heightModel;
    public FuelController GetFuelController => _fuelController;

    public float _currentFuel { get; set; } = 100f;

    private void Start()
    {
        _fuelController = new FuelController(this);

        _maxFuel = PlayerPrefs.GetFloat("MaxFuel");

        _currentFuel = _maxFuel;

        StartCoroutine(_fuelController.Fuel());
    }
}
