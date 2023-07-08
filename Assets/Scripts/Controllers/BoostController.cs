using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostController : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private GameObject pivot;

    private bool cycle = false;

    private void Update()
    {
        if (gameObject.transform.eulerAngles.z > 270f)
        {
            cycle = true;
        }
        else if (gameObject.transform.eulerAngles.z >= 180f)
        {
            cycle = false;
        }

        if (cycle == false)
        {
            transform.RotateAround(pivot.transform.position, Vector3.back, _rotateSpeed);
        }
        else
        {
            transform.RotateAround(pivot.transform.position, Vector3.forward, _rotateSpeed);
        }
    }

    public int GetCurrentBoost()
    {
        int multiplier = 0;

        if (gameObject.transform.eulerAngles.z >= 145f || gameObject.transform.eulerAngles.z <= 35f)
        {
            multiplier = 1;
        }
        else if (gameObject.transform.eulerAngles.z >= 110f || gameObject.transform.eulerAngles.z <= 65f)
        {
            multiplier = 2;
        }
        else
        {
            multiplier = 3;
        }

        return multiplier;
    }

    // green 145:180 ; 0:35
    // yellow 110:145 ; 35:65
    // red : 65:110;
}
