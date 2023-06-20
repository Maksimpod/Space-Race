using UnityEngine;

public class RocketMovement 
{
    private RocketModel _rocketModel;

    public RocketMovement(RocketModel rocketModel)
    {
        _rocketModel = rocketModel;
    }

    public void Movement()
    {
        var velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _rocketModel.MovementSpeed, 0f);
        _rocketModel.GetRigidbody2D.velocity = velocity;
    }

    public void GetBorders()
    {
        Vector3 viewPos = _rocketModel.transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, _rocketModel.GetScreenBounds.x * -1 + _rocketModel.GetRocketWidth, _rocketModel.GetScreenBounds.x - _rocketModel.GetRocketWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, _rocketModel.GetScreenBounds.y * -1 + _rocketModel.GetRocketHeight, _rocketModel.GetScreenBounds.y - _rocketModel.GetRocketHeight);
        _rocketModel.transform.position = viewPos;
    }
}
