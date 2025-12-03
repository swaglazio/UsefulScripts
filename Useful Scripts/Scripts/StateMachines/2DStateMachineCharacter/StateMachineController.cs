using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EStates
{
    WALK,
    DEAD,
    IDLE,
    JUMP,
    FALL,
    NONE
};

[RequireComponent(typeof(CharacterController))]
public class StateMachineController : MonoBehaviour
{
    private CharacterController _character = null;
    
    private Dictionary<EStates, ABaseState> _states = new Dictionary<EStates, ABaseState>();
    private EStates _current = EStates.IDLE;
    public ABaseState CurrentState => _states[_current];

    void Awake()
    {
        _character = GetComponent<CharacterController>();
    }
    
    void Start()
    {
        _states.Add(EStates.WALK, new WalkState(_character, this));
        _states.Add(EStates.DEAD, new DeadState(_character, this));
        _states.Add(EStates.IDLE, new IdleState(_character, this));
        _states.Add(EStates.JUMP, new JumpState(_character, this));
        _states.Add(EStates.FALL, new FallState(_character, this));

        _states[_current].Enter();

        //_currentState = new WanderState();
    }
    
    void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }

    public void ChangeState(EStates nextState)
    {
        Debug.Log("Transition from " + _current + " to " + nextState);
        CurrentState.Exit();
        _current = nextState;
        CurrentState.Enter();
    }
}
