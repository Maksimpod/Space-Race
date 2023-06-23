using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PauseInterface _pauseInterface;
    [SerializeField] private HUD _hud;
    
    private HeightModel _heightModel;
    private CoinModel _coinModel;
    private FuelModel _fuelModel;

    private SaveController _saveController;

    private bool gameStarted = false;
    private bool paused = false;

    private void Start()
    {
        Time.timeScale = 0;

        _heightModel = GetComponent<HeightModel>();
        _coinModel = GetComponent<CoinModel>();
        _fuelModel = GetComponent<FuelModel>();

        _saveController = new SaveController(_heightModel, _coinModel, _fuelModel);
    }

    public void StartGame()
    {
        if (!gameStarted)
        {
            gameStarted = true;
            Time.timeScale = 1;
            _hud.DeactivateStartButton();
            _hud.ChangeScoreText();

            _heightModel.GetHeightController.BoostOnStart();
        }
    }
    
    public void Restart()
    {
        _saveController.SaveOnReload();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseResumeGame()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            paused = true;
            _pauseInterface.Pause(paused);
        }
        else
        {
            Time.timeScale = 1;
            paused = false;
            _pauseInterface.Pause(paused);
        }
    }
}
