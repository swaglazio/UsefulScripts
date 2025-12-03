using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : ABaseState
{
    public DeadState(CharacterController controller)
    {
        _controller = controller;
    }

    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }
}
