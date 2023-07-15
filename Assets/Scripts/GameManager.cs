using RS2023.Scripts.Controllers;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RS2023.GameManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PauseInterface _pauseInterface;
        [SerializeField] private HUD _hud;
        [SerializeField] private BoostController _boostController;
        [SerializeField] private GameOverMenu _gameOverMenu;

        [SerializeField] private AlienController _alienController;

        private HeightModel _heightModel;
        private CoinModel _coinModel;
        private FuelModel _fuelModel;

        private SaveController _saveController;

        private bool paused = false;

        private void Awake()
        {
            Time.timeScale = 0;
        }

        private void Start()
        {
            _heightModel = GetComponent<HeightModel>();
            _coinModel = GetComponent<CoinModel>();
            _fuelModel = GetComponent<FuelModel>();

            _saveController = new SaveController(_heightModel, _coinModel, _fuelModel);
        }

        public void StartGame()
        {
            Time.timeScale = 1;
            _hud.StartGameGUI();

            _heightModel.GetHeightController.BoostOnStart(_boostController.GetCurrentBoost());
        }

        public void StopGame()
        {
            //_alienController.PushAlien();
            StartCoroutine(StopGameCoroutine());
        }
        private IEnumerator StopGameCoroutine()
        {
            yield return new WaitForSeconds(0.1f);
            _gameOverMenu.EnableGameOverMenu();
            _heightModel.GetHeightController.UpdateTotalScore();
            _coinModel.GetCoinController.CalculateCoins();
            Time.timeScale = 0;
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
            }
            else
            {
                Time.timeScale = 1;
                paused = false;
            }
            _pauseInterface.Pause(paused);
        }
    }

}