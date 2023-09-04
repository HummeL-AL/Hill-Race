using UnityEngine;

public class GameLoopState : IState
{
    private const string GameScene = "GameLoop";
    private const string PlayerCarAssetPath = "StaticData/Cars/PlayerCarData";

    private readonly IAssetsProvider _assetsProvider;
    private readonly ISceneLoader _sceneLoader;
    private readonly IGameFactory _gameFactory;
    private readonly IBackgroundFactory _backgroundFactory;
    private readonly ICarFactory _carFactory;

    public GameLoopState()
    {
        _assetsProvider = ServiceProvider.Container.Single<AssetsProvider>();
        _sceneLoader = ServiceProvider.Container.Single<SceneLoader>();
        _gameFactory = ServiceProvider.Container.Single<GameFactory>();
        _backgroundFactory = ServiceProvider.Container.Single<BackgroundFactory>();
        _carFactory = ServiceProvider.Container.Single<CarFactory>();
    }

    public void Enter()
    {
        LoadGameScene();
    }

    public void Exit()
    {

    }

    private void LoadGameScene()
    {
        _sceneLoader.Load(GameScene, InitializeGame);
    }

    private void InitializeGame()
    {
        CreateInitialObjects();
    }

    private void CreateInitialObjects()
    {
        MapLoader map = CreateMap();
        Car playerCar = CreatePlayerCar();
        Player player = CreatePlayer(playerCar);
        CreateHud(player);

        CreateBackground().Follow(player.Camera.transform);
        player.SessionStats.OnDrivedDistanceChanged += map.UpdateForDistance;
    }

    private MapLoader CreateMap()
    {
        MapLoader map = _gameFactory.CreateMap();

        return map;
    }

    private Car CreatePlayerCar()
    {
        Vector3 spawnPos = GameObject.FindObjectOfType<PlayerSpawner>().transform.position;
        CarData carData = _assetsProvider.LoadAsset<CarData>(PlayerCarAssetPath);
        Car car = _carFactory.CreateCar(carData, spawnPos);

        return car;
    }

    private Player CreatePlayer(Car playerCar)
    {
        Player player = _gameFactory.CreatePlayer();
        player.SetCar(playerCar);

        return player;
    }

    private HUD CreateHud(Player player)
    {
        HUD hud = _gameFactory.CreateHud();
        hud.SetPlayer(player);

        return hud;
    }

    private ObjectFollower CreateBackground()
    {
        ObjectFollower background = _backgroundFactory.Create();

        return background;
    }
}
