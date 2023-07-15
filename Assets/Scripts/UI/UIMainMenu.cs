using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainCanvas;
    [SerializeField] private GameObject _gameMenuCanvas;
    public void StartGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        _gameMenuCanvas.SetActive(false);
        _mainCanvas.SetActive(true);
        // After reload, main menu is also being reload. Probably this should be fixed;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
