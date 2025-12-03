using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : ABaseState
{
    //Hérite de ABaseState donc a accès à _characterController

    public WanderState(CharacterController controller)
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

        //Ici utiliser _characterController.move() par exemple
    }
}
