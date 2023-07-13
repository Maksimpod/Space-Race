using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void ActivateSelf()
    {
        gameObject.SetActive(true);
    }

    public void PushAlien()
    {
        ActivateSelf();
        _rigidbody.AddForce(new Vector2(3, 3) * 10);
    }
}
