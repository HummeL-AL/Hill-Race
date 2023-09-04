using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateMachine
{
    void Enter<TState>() where TState : class, IState;
    void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
}
