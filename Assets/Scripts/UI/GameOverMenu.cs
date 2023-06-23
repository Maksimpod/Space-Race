using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    private GameObject _gameOverMenu;

    private void Start()
    {
        _gameOverMenu = GetComponent<GameObject>();
    }
    public void EnableGameOverMenu()
    {
        _gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
