using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABaseState
{
    //Sert de parent à tous le states

    protected CharacterController _controller; //Remplacer par le controller du jeu

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
}
