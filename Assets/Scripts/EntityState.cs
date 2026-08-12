using Unity.VisualScripting;
using UnityEngine;

public abstract class EntityState 
{
    protected Unity.VisualScripting.StateMachine stateMachine;
    protected string stateName;
    private StateController stateMachine1;
    private string v;

    public  EntityState(Unity.VisualScripting.StateMachine sm, string _name)
    {
        stateMachine = sm;
        stateName = _name;
    }

    public EntityState(StateController controller, string v)
    {
        this.stateMachine1 = controller;
        this.v = v;
    }

    // Called when the state is entered
    public virtual void Enter() 
    {

    }
    // Called when the state is exited
    public virtual void Exit() 
    {

    }

    // Called every frame the state is active
    public virtual void Update() 
    {
        
    }
}
