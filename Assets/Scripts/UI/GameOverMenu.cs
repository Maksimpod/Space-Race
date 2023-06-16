using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverMenu;
    public void EnableGameOverMenu()
    {
        _gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
