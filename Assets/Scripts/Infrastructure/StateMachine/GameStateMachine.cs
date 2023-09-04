using System;
using System.Collections.Generic;

public class GameStateMachine : IGameStateMachine, IService
{
    private Dictionary<Type, IExitableState> registeredStates;
    private IExitableState currentState;

    public GameStateMachine()
    {
        registeredStates = new Dictionary<Type, IExitableState>();

        RegisterState(new BootstrapState(this));
        RegisterState(new GameLoopState());
    }

    public void Enter<TState>() where TState : class, IState
    {
        ChangeState<TState>().Enter();
    }

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
    {
        ChangeState<TState>().Enter(payload);
    }

    private void RegisterState<TState>(TState state) where TState : IExitableState =>
        registeredStates.Add(typeof(TState), state);

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
        TState state = GetState<TState>();
        currentState?.Exit();
        currentState = state;

        return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState
    {
        return registeredStates[typeof(TState)] as TState;
    }
}