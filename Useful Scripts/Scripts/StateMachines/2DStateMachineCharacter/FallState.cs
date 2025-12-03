using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class FallState : ABaseState
{
    
    //Un constructeur n'a pas de type
    //public WanderState(){ }
    
    public FallState(CharacterController characterController, StateMachineController stateMachine)
    {
        _character = characterController;
        _stateMachine = stateMachine;
    }
    
    public override void Enter()
    {
        _character.Fall();
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        _character.Move();
        
        if (_character.Rb.linearVelocity.y == 0 && _character.IsGrounded())
        {
            _stateMachine.ChangeState(EStates.IDLE);
        }
    }
}
