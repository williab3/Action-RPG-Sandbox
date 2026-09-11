using Unity.VisualScripting;
using UnityEngine;

public abstract class CharacterState 
{
    protected string stateName;
    protected StateController controller;
    protected string animXParam;


    public CharacterState(StateController _controller, string paramName)
    {
        this.controller = _controller;
        this.animXParam = paramName;
    }

    // Called when the state is entered
    public virtual void Enter() 
    {
        Debug.Log($"Entering state: {animXParam}");
    }
    // Called when the state is exited
    public virtual void Exit() 
    {
        Debug.Log($"Exiting state: {animXParam}");
    }

    // Called every frame the state is active
    public virtual void Update() 
    {
        Debug.Log($"Updating state: {animXParam}");
    }
}
