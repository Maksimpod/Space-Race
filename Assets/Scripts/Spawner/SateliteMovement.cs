using UnityEngine;

namespace RS2023.Scripts.Spawner
{
    public class SateliteMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody2D _rigidbody;
        private FuelModel _fuelModel;

        float alpha = 0;
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            _fuelModel = FindObjectOfType<FuelModel>();
        }

        private void FixedUpdate()
        {
            /*alpha += 0.015f;
            float X = transform.position.x + Mathf.Cos(alpha) * 0.1f;
            float Y = transform.position.y + Mathf.Sin(alpha) * 0.1f / 2;
            gameObject.transform.position = new Vector2(X, Y);
            */
            transform.RotateAround(new Vector2(0f, 0f), new Vector3(0f, 0f, 1f), _speed * Time.fixedDeltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _fuelModel.GetFuelController.DecreaseFuel();
            /*if (collision.gameObject.name == "Body" || collision.gameObject.name == "Tail")
            {
            }*/
            gameObject.SetActive(false);
        }
    }

}