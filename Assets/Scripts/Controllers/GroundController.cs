using UnityEngine;

public class GroundController : MonoBehaviour
{
    private void FixedUpdate()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y - 3f)
        {
            Destroy(gameObject);
        }
    }
}
