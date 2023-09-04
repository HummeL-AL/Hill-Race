using UnityEngine;

public class BootstrapState : IState
{
    private const string InitialScene = "Bootstrap";

    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoader _sceneLoader;

    public BootstrapState(IGameStateMachine stateMachine)
    {
        _stateMachine = stateMachine;

        _sceneLoader = ServiceProvider.Container.Single<SceneLoader>();
    }

    public void Enter()
    {
        _sceneLoader.Load(InitialScene, OnSceneLoaded);
    }

    public void Exit()
    {

    }

    private void OnSceneLoaded()
    {
        _stateMachine.Enter<GameLoopState>();
    }
}