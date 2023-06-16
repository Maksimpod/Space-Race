using UnityEngine;

public class HeightModel : MonoBehaviour
{
    [Header("HUD")]
    [SerializeField] private HUD _hud;

    [Header("Height Breakpoints")]
    [SerializeField] private int[] _heightFlags;

    [Header("Background Controller")]
    [SerializeField] private BackgroundController _backgroundController;

    private HeightController _heightController;

    public int[] heightFlags => _heightFlags;
    public HUD GetHUD => _hud;
    public HeightController GetHeightController => _heightController;
    public BackgroundController GetBackgroundController => _backgroundController;

    public int height { get; set; } = 0;
    public int recordHeight { get; set; } = 0;
    public int triggerIndex { get; set; } = 0;
    public int multiplier { get; set; }

    private void Start()
    {
        _heightController = new HeightController(this);

        _hud.SetRecordText(recordHeight);

        StartCoroutine(_heightController.Score());
        StartCoroutine(_heightController.CheckHeightFlags());
    }
    
}
