using System.Collections;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
    [SerializeField] private SpriteRenderer _colorBackground;
    [SerializeField] private Renderer _spriteBackground;

    private float transitionTime = 6f;

    public void ChangeBackground(int index)
    {
        if (index <= 2)
        {
            StartCoroutine(ColorChanger(index));
        }
        else
        {
            _spriteBackground.gameObject.SetActive(true);
            _spriteBackground.material.mainTexture.wrapMode = TextureWrapMode.Repeat;
            _colorBackground.gameObject.SetActive(false);
            StartCoroutine(BackgroundScroller());
        }
    }

    private IEnumerator ColorChanger(int index)
    {
        float timeElapsed = 0f;
        float totalTime = transitionTime;

        while (timeElapsed < totalTime)
        {
            timeElapsed += Time.deltaTime;
            _colorBackground.color = Color.Lerp(_colorBackground.color, _colors[index], timeElapsed / totalTime);
            yield return null;
        }
    }

    private IEnumerator BackgroundScroller()
    {
        while (true)
        {
            _spriteBackground.material.mainTextureOffset += new Vector2(0, 0.02f * Time.deltaTime);
            yield return null;
        }
    }
}
