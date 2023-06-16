using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - _speed * Time.deltaTime);
        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y - 5f)
        {
            gameObject.SetActive(false);
        }
    }
}
