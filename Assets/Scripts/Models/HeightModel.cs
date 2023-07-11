using UnityEngine;
using UnityEngine.UI;

public class HeightModel : MonoBehaviour
{
    [Header("HUD")]
    [SerializeField] private HUD _hud;
    [SerializeField] private UIShop _shopMenu;

    [Header("Height Breakpoints")]
    [SerializeField] private int[] _heightFlags;

    [Header("Background Controller")]
    [SerializeField] private BackgroundController _backgroundController;

    [Header("Shop Buttons")]
    [SerializeField] private Button _engineUpgradeButton;

    [SerializeField] private CoinModel _coinModel;

    [SerializeField] private int _rokValue = 15;

    private HeightController _heightController;

    private int _height = 0;

    public int[] heightFlags => _heightFlags;
    public HUD GetHUD => _hud;
    public UIShop GetShopMenu => _shopMenu;
    public HeightController GetHeightController => _heightController;
    public BackgroundController GetBackgroundController => _backgroundController;
    public Button EngineUpgradeButton => _engineUpgradeButton;
    public CoinModel GetCoinModel => _coinModel;
    public int RokValue => _rokValue;

    public int Height { 
        get {
            return _height;
        } 
        set {
            _height = value;
            _hud.SetHeightText(_height / _rokValue);
        } 
    }
    public int recordHeight { get; set; } = 0;
    public int triggerIndex { get; set; } = 0;
    public int multiplier { get; set; }
    public int engineMultiplier { get; set; } = 1;

    private void Start()
    {
        _heightController = new HeightController(this);

        recordHeight = PlayerPrefs.GetInt("RecordHeight", recordHeight);
        engineMultiplier = PlayerPrefs.GetInt("EngineMultiplier", engineMultiplier);

        _hud.SetRecordText(recordHeight / _rokValue);

        _heightController.InitializeUpgradeButton();

        StartCoroutine(_heightController.Score());
        StartCoroutine(_heightController.CheckHeightFlags());
    }
    
}
