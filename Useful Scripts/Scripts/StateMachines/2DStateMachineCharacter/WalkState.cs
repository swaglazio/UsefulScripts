using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class WalkState : ABaseState
{
    
    public WalkState(CharacterController characterController, StateMachineController stateMachine)
    {
        _character = characterController;
        _stateMachine = stateMachine;
    }
    
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        _character.Move();
        
        if (Input.GetKeyDown(KeyCode.Space) && _character.IsGrounded())
        {
            _stateMachine.ChangeState(EStates.JUMP);
            return; 
        }

        if (Mathf.Abs(Input.GetAxis("Horizontal")) < 0.1f)
        {
            _stateMachine.ChangeState(EStates.IDLE);
        }
        
        if (_character.Rb.linearVelocity.y < 0)
        {
            _stateMachine.ChangeState(EStates.FALL);
        }
    }
}
