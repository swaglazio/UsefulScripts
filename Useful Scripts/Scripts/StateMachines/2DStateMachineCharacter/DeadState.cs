using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : ABaseState
{
    
    
    //Un constructeur n'a pas de type
    //public WanderState(){ }
    
    public DeadState(CharacterController characterController, StateMachineController stateMachine)
    {
        _character = characterController;
        _stateMachine = stateMachine;
    }
    
    public override void Enter()
    {
        //Launch death anim + sound
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        
    }
}
