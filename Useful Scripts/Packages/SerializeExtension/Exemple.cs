using System;
using UnityEngine;

//Exemple d'utilisation (sérialisation d'interface)

public interface IEffect
{
    public void Trigger();
}

[Serializable]
public class ValueSet : IEffect
{
    [SerializeField] private ValueData _value;
    [SerializeField] private int _number;
    public void Trigger() 
    { 
        GameManager.Instance.SetValue(_value, _number);
    }
}

[Serializable]
public class ValueAdd : IEffect
{
    [SerializeField] private ValueData _value;
    [SerializeField] private int _number;
    public void Trigger() 
    {
        GameManager.Instance.AddValue(_value, _number);
    }
}

[Serializable]
public class ValueMultiply : IEffect
{
    [SerializeField] private ValueData _value;
    [SerializeField] private int _number;
    public void Trigger() 
    {
        GameManager.Instance.MultiplyValue(_value, _number);
    }
}

[Serializable]
public class ValueDivide : IEffect
{
    [SerializeField] private ValueData _value;
    [SerializeField] private int _number;
    public void Trigger() 
    {
        GameManager.Instance.DivideValue(_value, _number);
    }
}

[Serializable]
public class AddAspect : IEffect
{
    [SerializeField] private AspectData _aspect;
    public void Trigger() 
    { 
        GameManager.Instance.SummonAspect(_aspect);
    }
}

[Serializable]
public class RemoveAspect : IEffect
{
    [SerializeField] private AspectData _aspect;
    public void Trigger() 
    { 
        GameManager.Instance.DestroyAspect(_aspect);
    }
}

[Serializable]
public class SummonEntity : IEffect
{
    [SerializeField] private EntityData _entity;
    public void Trigger() 
    {
        GameManager.Instance.SummonEntity(_entity);
    }
}

[Serializable]
public class DestroyEntity : IEffect
{
    [SerializeField] private EntityData _entity;
    public void Trigger() 
    {
        GameManager.Instance.DestroyEntity(_entity);
    }
}

[Serializable]
public class LoadSituation : IEffect
{
    [SerializeField] private SituationData _situation;
    public void Trigger() 
    { 
        GameManager.Instance.LoadSituation(_situation);
    }
}

[Serializable]
public class TriggerScene : IEffect
{
    [SerializeField] private SDialogue[] _scene;
    public void Trigger() 
    {
        GameManager.Instance.StartCoroutine(GameManager.Instance.TriggerScene(_scene));
    }
}

[Serializable]
public class TransformAspectIntoEntity : IEffect
{
    [SerializeField] private AspectData _targetAspect;
    public void Trigger()
    {
        GameManager.Instance.FindAspect(_targetAspect)?.TransformIntoEntity();
    }
}

[Serializable]
public class TransformEntityIntoAspect : IEffect
{
    [SerializeField] private EntityData _targetEntity;
    public void Trigger()
    {
        GameManager.Instance.FindEntity(_targetEntity)?.TransformIntoAspect();
    }
}


