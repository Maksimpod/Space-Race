using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
    [SerializeField] private SpriteRenderer _obj;
    [SerializeField] private Renderer _obj2;

    private float transitionTime = 3f;

    private void OnEnable()
    {
        HeightManager.OnHeightReached += ChangeBackground;
    }
    private void OnDisable()
    {
        HeightManager.OnHeightReached -= ChangeBackground;
    }

    public void ChangeBackground(int index)
    {
        if (index <= 2)
        {
            StartCoroutine(ColorChanger(index));
        }
        else
        {
            _obj2.gameObject.SetActive(true);
            _obj2.material.mainTexture.wrapMode = TextureWrapMode.Repeat;
            _obj.gameObject.SetActive(false);
            StartCoroutine(BackgroundScroller());
        }
    }

    IEnumerator ColorChanger(int index)
    {
        float timeElapsed = 0f;
        float totalTime = transitionTime;

        while (timeElapsed < totalTime)
        {
            timeElapsed += Time.deltaTime;
            _obj.color = Color.Lerp(_obj.color, _colors[index], timeElapsed / totalTime);
            yield return null;
        }
    }

    IEnumerator BackgroundScroller()
    {
        while (true)
        {
            _obj2.material.mainTextureOffset += new Vector2(0, 0.05f * Time.deltaTime);
            yield return null;
        }
        
    }
}
