using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PauseInterface _pauseInterface;
    [SerializeField] private HUD _hud;
    [SerializeField] private HeightModel _heightModel;

    private bool gameStarted = false;
    private bool paused = false;

    private void Start()
    {
        Time.timeScale = 0;
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
