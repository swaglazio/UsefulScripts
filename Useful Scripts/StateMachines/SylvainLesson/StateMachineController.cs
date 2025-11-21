using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineController : MonoBehaviour
{
    private Dictionary<EStates, ABaseState> _states = null;
    private ABaseState _currentState = null;
    private EStates _current = EStates.WANDER;
    public ABaseState CurrentState { get => _states[_current]; set => _currentState = value; }

    private void Start()
    {
        _states.Add(EStates.WANDER, new WanderState());
        _states.Add(EStates.WANDER, new DeadState());
        _states[_current].Enter();
    }

    private void Update()
    {
        CurrentState.Update();
    }
    public void ChangeState(EStates newState)
    {
        CurrentState.Exit();
        _current = newState;
        CurrentState.Enter();
    }
}

public enum EStates
{
    NONE,
    WANDER,
    DEAD
}