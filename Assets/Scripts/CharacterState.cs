using Unity.VisualScripting;
using UnityEngine;

public abstract class CharacterState 
{
    protected string stateName;
    protected StateController controller;
    protected string animParam;


    public CharacterState(StateController _controller, string paramName)
    {
        this.controller = _controller;
        this.animParam = paramName;
    }

    // Called when the state is entered
    public virtual void Enter() 
    {
        Debug.Log($"Entering state: {animParam}");
    }
    // Called when the state is exited
    public virtual void Exit() 
    {
        Debug.Log($"Exiting state: {animParam}");
    }

    // Called every frame the state is active
    public virtual void Update() 
    {
        Debug.Log($"Updating state: {animParam}");
    }
}
