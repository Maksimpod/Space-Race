using UnityEngine;

public class RocketMovement 
{
    private RocketModel _rocketModel;
    private Rigidbody2D rigidBody;

    public RocketMovement(RocketModel rocketModel)
    {
        _rocketModel = rocketModel;

        rigidBody = _rocketModel.GetRigidbody2D;
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
        viewPos.x = Mathf.Clamp(viewPos.x, _rocketModel.GetScreenBounds.x * -1 + _rocketModel.GetRocketWidth, _rocketModel.GetScreenBounds.x - _rocketModel.GetRocketWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, _rocketModel.GetScreenBounds.y * -1 + _rocketModel.GetRocketHeight, _rocketModel.GetScreenBounds.y - _rocketModel.GetRocketHeight);
        _rocketModel.transform.position = viewPos;
    }
}
