using UnityEngine;

public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
{
    public static GameBootstrapper Instance = null;

    private void Awake()
    {
        if (Instance && Instance != this)
        {
            DestroySelf();
            return;
        }

        Instance = this;
        SetGameSettings();
        BootstrapGame();

        DontDestroyOnLoad(this);
    }

    private void SetGameSettings()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    private void BootstrapGame()
    {
        RegisterServices();
        InitializeStateMachine();
    }

    private void RegisterServices()
    {
        ServiceProvider.Container.Register(new SceneLoader(this));
        ServiceProvider.Container.Register(new AssetsProvider());

        ServiceProvider.Container.Register(new GameFactory());
        ServiceProvider.Container.Register(new BackgroundFactory());
        ServiceProvider.Container.Register(new LandscapeChunkFactory());
        ServiceProvider.Container.Register(new CarFactory());
    }

    private void InitializeStateMachine()
    {
        GameStateMachine game = new GameStateMachine();
        game.Enter<BootstrapState>();
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
