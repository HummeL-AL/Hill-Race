using UnityEngine;

public class CarFactory : ICarFactory
{
    public const string CarAssetPath = "Car";

    private readonly IAssetsProvider _assetsProvider;

    public CarFactory()
    {
        _assetsProvider = ServiceProvider.Container.Single<AssetsProvider>();
    }

    public Car CreateCar(CarData carConfig, Vector3 spawnPos)
    {
        Car car = _assetsProvider.LoadAsset<Car>(CarAssetPath);

        Car createdCar = GameObject.Instantiate(car, spawnPos, Quaternion.identity);
        createdCar.SetCarConfig(carConfig);

        return createdCar;
    }
}
