using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerBaseState CurrentState { get; private set; }

    public void Initialize(PlayerBaseState _state)
    {
        CurrentState = _state;
        CurrentState.Enter();
    }

    public void ChangeState(PlayerBaseState _state)
    {
        CurrentState?.Exit();
        CurrentState = _state;
        CurrentState?.Enter();
    }
}
