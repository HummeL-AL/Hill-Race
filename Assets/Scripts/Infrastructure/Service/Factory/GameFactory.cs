using UnityEngine;

public class GameFactory : IGameFactory
{
    private const string PlayerAssetPath = "Player";
    private const string MapAssetPath = "Maps/Map";
    private const string HudAssetPath = "UI/Layouts/HUD";

    private readonly IAssetsProvider _assetsProvider;

    public GameFactory()
    {
        _assetsProvider = ServiceProvider.Container.Single<AssetsProvider>();
    }

    public Player CreatePlayer()
    {
        IInputHandler inputHandler = new MobileInputHandler();
        Player player = _assetsProvider.LoadAsset<Player>(PlayerAssetPath);

        Player createdPlayer = GameObject.Instantiate(player);
        createdPlayer.SetInputHandler(inputHandler);
        
        return createdPlayer; 
    }

    public HUD CreateHud()
    {
        HUD hud = _assetsProvider.LoadAsset<HUD>(HudAssetPath);
        return GameObject.Instantiate(hud);
    }

    public MapLoader CreateMap()
    {
        MapLoader map = _assetsProvider.LoadAsset<MapLoader>(MapAssetPath);
        return GameObject.Instantiate(map);
    }
}
