using RS2023.Scripts.Controllers;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private FuelController _fuelModel;
    private RocketMovement _rocketModel;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _fuelModel = FindObjectOfType<FuelModel>().GetFuelController;
        _rocketModel = FindObjectOfType<RocketModel>().GetMovementController;
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
        _fuelModel.DecreaseFuel();
        _rocketModel.DecreaseSpeed();
        /*if (collision.gameObject.name == "Body" || collision.gameObject.name == "Tail")
        {
        }*/
        gameObject.SetActive(false);
    }
}
