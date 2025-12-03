using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineController : MonoBehaviour
{
    private Dictionary<EStates, ABaseState> _statesDictionnary = new Dictionary<EStates, ABaseState>();
    private EStates _current = EStates.WANDER;

    public ABaseState CurrentState { get => _statesDictionnary[_current]; }


    private CharacterController _characterController = null; //Renseigné via l'awake, c'est une possibilité parmi d'autres

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        _statesDictionnary.Add(EStates.WANDER, new WanderState(_characterController));
        _statesDictionnary.Add(EStates.DEAD, new DeadState(_characterController));
    }

    void Update()
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

public enum EStates //Autant d'enum que de states à accéder
{
    WANDER,
    DEAD,
    NONE
}
