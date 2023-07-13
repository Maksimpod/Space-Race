using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private Camera _cam;

    [SerializeField]  private RawImage _screenShootImage;

    [SerializeField] private BackgroundController _backgroundController;

    public void EnableGameOverMenu()
    {
        gameObject.SetActive(true);
        _backgroundController.SetBackgroundDistance(0f);
        CaptureScreen();
    }

    private void CaptureScreen()
    {
        RenderTexture screenTexture = new RenderTexture(Screen.width, Screen.height, 16);
        _cam.targetTexture = screenTexture;
        RenderTexture.active = screenTexture;
        _cam.Render();

        Texture2D renderedTexture = new Texture2D(Screen.width, Screen.height);
        renderedTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        renderedTexture.Apply();
        RenderTexture.active = null;

        _screenShootImage.texture = renderedTexture;
        _backgroundController.SetBackgroundDistance(100f);
    }
}
