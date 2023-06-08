using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _screenBounds;
    private float _objectWidth;
    private float _objectHeight;

    private void Start()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        _objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        _objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }
    void Update()
    {
        //transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, 0f, 0f));
        transform.position += new Vector3(_speed * Input.GetAxisRaw("Horizontal"), 0f, 0f);
    }

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, _screenBounds.x * -1 + _objectWidth, _screenBounds.x - _objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, _screenBounds.y * -1 + _objectHeight, _screenBounds.y - _objectHeight);
        transform.position = viewPos;
    }
}