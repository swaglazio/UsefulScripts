using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class IdleState : ABaseState
{
    
    //Un constructeur n'a pas de type
    //public WanderState(){ }
    
    public IdleState(CharacterController characterController, StateMachineController stateMachine)
    {
        _character = characterController;
        _stateMachine = stateMachine;
    }
    
    public override void Enter()
    {
        //Launch Anim + sound Idle
        Debug.Log("Idle");
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        _character.Idle();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _stateMachine.ChangeState(EStates.JUMP);
            return; 
        }

        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
        {
            _stateMachine.ChangeState(EStates.WALK);
        }
        
        if (_character.Rb.linearVelocity.y < 0)
        {
            _stateMachine.ChangeState(EStates.FALL);
        }
    }
}
