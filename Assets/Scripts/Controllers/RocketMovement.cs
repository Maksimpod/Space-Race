using System.Collections;
using UnityEngine;

public class RocketMovement 
{
    private RocketModel _rocketModel;
    private Rigidbody2D rigidBody;
    private Vector2 screenBounds;

    public RocketMovement(RocketModel rocketModel)
    {
        _rocketModel = rocketModel;

        rigidBody = _rocketModel.GetRigidbody2D;
        screenBounds = _rocketModel.GetScreenBounds;
    }

    public void Movement()
    {
        var velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _rocketModel.MovementSpeed, 0f);
        rigidBody.velocity = velocity;
    }

    public void TouchMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touchPosition.x > _rocketModel.transform.position.x) {
                rigidBody.velocity = new Vector2(_rocketModel.MovementSpeed, 0f);
            }
            else
            {
                rigidBody.velocity = new Vector2(-_rocketModel.MovementSpeed, 0f);
            }
        }
        else
        {
            rigidBody.velocity = new Vector2(0f, 0f);
        }
    }

    public void GetBorders()
    {
        Vector3 viewPos = _rocketModel.transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + _rocketModel.GetRocketWidth, screenBounds.x - _rocketModel.GetRocketWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + _rocketModel.GetRocketHeight, screenBounds.y - _rocketModel.GetRocketHeight);
        _rocketModel.transform.position = viewPos;
    }

    public void DecreaseSpeed()
    {
        _rocketModel.StartCoroutine(DecreaseSpeedCoroutine());
    }

    public IEnumerator DecreaseSpeedCoroutine() {
        _rocketModel.MovementSpeed /= 2f;
        yield return new WaitForSeconds(1f);
        _rocketModel.MovementSpeed *= 2f;
    }
}
