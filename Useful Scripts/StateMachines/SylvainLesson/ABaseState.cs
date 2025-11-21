using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ABaseState 
{
    public abstract void Enter();

    public abstract void Update();

    public abstract void Exit();



}
