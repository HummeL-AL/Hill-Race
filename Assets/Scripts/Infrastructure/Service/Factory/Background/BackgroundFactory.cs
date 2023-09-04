using UnityEngine;

public class BackgroundFactory : IBackgroundFactory
{
    private const string BackgroundPath = "Maps/Backgrounds/Map_0";

    private IAssetsProvider _assetsProvider;

    public BackgroundFactory()
    {
        _assetsProvider = ServiceProvider.Container.Single<AssetsProvider>();
    }

    public ObjectFollower Create()
    {
        ObjectFollower background = _assetsProvider.LoadAsset<ObjectFollower>(BackgroundPath);
        ObjectFollower createdBackground = GameObject.Instantiate(background);

        return createdBackground;
    }
}
