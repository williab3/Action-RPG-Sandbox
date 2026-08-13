using Unity.VisualScripting;
using UnityEngine;

public abstract class EntityState 
{
    protected string stateName;
    protected StateController controller;
    private string v;


    public EntityState(StateController _controller, string v)
    {
        this.controller = _controller;
        this.v = v;
    }

    // Called when the state is entered
    public virtual void Enter() 
    {
        Debug.Log($"Entering state: {v}");
    }
    // Called when the state is exited
    public virtual void Exit() 
    {
        Debug.Log($"Exiting state: {v}");
    }

    // Called every frame the state is active
    public virtual void Update() 
    {
        Debug.Log($"Updating state: {v}");
    }
}
