public interface ICarFactory : IVehicleFactory
{
    public Car CreateCar(CarData carConfig, UnityEngine.Vector3 spawnPos);
}
