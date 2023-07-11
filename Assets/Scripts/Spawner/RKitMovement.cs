using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RKitMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private FuelModel _fuelModel;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _fuelModel = FindObjectOfType<FuelModel>();
    }

    private void FixedUpdate()
    {
        var velocity = new Vector2(0f, -_speed * Time.fixedDeltaTime);
        _rigidbody.velocity = velocity;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _fuelModel.FuelLeak > 0f)
        {
            gameObject.SetActive(false);
            _fuelModel.GetFuelController.RepairLeak();
        }
    }
}
