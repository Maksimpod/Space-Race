using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RocketModel : MonoBehaviour
{
    [Header("Movement data")]
    [SerializeField] [Range(0, 5)] private float _movementSpeed;
    
    [Header("Sprite data")]
    [SerializeField] private SpriteRenderer _boundsSprite;

    private RocketMovement _rocketMovement;
    private Rigidbody2D _rigidbody;

    private Vector2 _screenBounds;
    private float _objectWidth;
    private float _objectHeight;

    public float MovementSpeed => _movementSpeed;
    public Rigidbody2D GetRigidbody2D => _rigidbody;
    public Vector2 GetScreenBounds => _screenBounds;
    public float GetRocketWidth => _objectWidth;
    public float GetRocketHeight => _objectHeight;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        _objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        _objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        _rocketMovement = new RocketMovement(this);
    }
    
    private void FixedUpdate()
    {
        _rocketMovement.Movement();
        //_rocketMovement.TouchMovement();
    }

    private void LateUpdate()
    {
        if (_rigidbody.gravityScale != 1)
        {
            _rocketMovement.GetBorders();
        }
    }
}
