using UnityEngine;

public class Car : MonoBehaviour, IVehicle
{
    [SerializeField] private Rigidbody2D[] wheels;
    [SerializeField] private Fuel fuel;

    public Fuel Fuel => fuel;

    private CarData _carData;

    public void SetCarConfig(CarData carData)
    {
        _carData = carData;
    }

    public void Accelerate(float forcePercent)
    {
        if (Fuel.Value > 0)
        {
            ApplyWheelsForce(_carData.AccelerationForce * forcePercent);
            ConsumeFuel(forcePercent);
        }
    }

    public void Brake(float forcePercent)
    {
        float deltaForce = _carData.ActiveBrakeForce - _carData.PassiveBrakeForce;
        float torque = _carData.PassiveBrakeForce + deltaForce * forcePercent;

        ApplyWheelsDrag(torque);
    }

    private void ApplyWheelsForce(float force)
    {
        foreach (Rigidbody2D wheel in wheels)
        {
            wheel.AddTorque(-force);
        }
    }

    private void ApplyWheelsDrag(float drag)
    {
        foreach (Rigidbody2D wheel in wheels)
        {
            wheel.angularDrag = drag;
        }
    }

    private void ConsumeFuel(float consumptionPercent)
    {
        float consumpedFuel = _carData.FuelConsumption * consumptionPercent * Time.fixedDeltaTime;
        fuel.ApplyChange(-consumpedFuel);
    }
}
