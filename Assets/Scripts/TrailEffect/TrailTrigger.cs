using RS2023.Scripts.Controllers;
using System.Collections;
using UnityEngine;

namespace RS2023
{
    public class TrailTrigger : MonoBehaviour
    {
        private FuelController _fuelModel;
        private RocketMovement _rocketModel;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);
            _fuelModel = FindObjectOfType<FuelModel>().GetFuelController;
            _rocketModel = FindObjectOfType<RocketModel>().GetMovementController;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name == "Head" || collision.gameObject.name == "Body" || collision.gameObject.name == "Tail" || collision.gameObject.name == "Wings")
            {
                _fuelModel.DecreaseFuel();
                _rocketModel.DecreaseSpeed();
            }
            gameObject.SetActive(false);
        }
    }
}
