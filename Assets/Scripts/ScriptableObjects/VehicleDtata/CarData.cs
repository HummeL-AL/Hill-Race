using UnityEngine;

[CreateAssetMenu(fileName = "CarData", menuName = "VehicleData/CarData", order = 0)]
public class CarData : VehicleData
{
    [SerializeField] private float _accelerationForce;
    [SerializeField] private float _activeBrakeForce;
    [SerializeField] private float _passiveBrakeForce;
    [SerializeField] private float _fuelConsumption;

    public float AccelerationForce => _accelerationForce;
    public float ActiveBrakeForce => _activeBrakeForce;
    public float PassiveBrakeForce => _passiveBrakeForce;
    public float FuelConsumption => _fuelConsumption;
}
