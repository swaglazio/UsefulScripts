using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class JumpState : ABaseState
{
    
    //Un constructeur n'a pas de type
    //public WanderState(){ }
    
    public JumpState(CharacterController characterController, StateMachineController stateMachine)
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
        if (_character.IsGrounded())
        {
            _character.Jump();
        }
        
        _character.Move();
        
        
        if (_character.GetComponent<Rigidbody2D>().linearVelocity.y < 0)
        {
            _stateMachine.ChangeState(EStates.FALL);
        }
    }
}
