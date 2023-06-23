using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public void EnableGameOverMenu()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
