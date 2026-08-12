using Unity.VisualScripting;
using UnityEngine;

public class EntityState 
{
    protected StateMachine stateMachine;

    public EntityState(StateMachine sm)
    {
        stateMachine = sm;
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
