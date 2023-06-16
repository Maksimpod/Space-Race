using UnityEngine;
using UnityEngine.UI;

public class PauseInterface : MonoBehaviour
{
    [SerializeField] private GameObject _pausedText;
    [SerializeField] private Image _pauseImage;

    private Sprite[] pauseButtonSprites;
    private void Start()
    {
        pauseButtonSprites = Resources.LoadAll<Sprite>("pause");
    }

    public void Pause(bool state)
    {
        _pausedText.SetActive(state);
        _pauseImage.sprite = state ? pauseButtonSprites[1] : pauseButtonSprites[0];
    }
}
