using UnityEngine;

public class StateController 
{
    public EntityState CurrentState { get; private set; }

    public void Initialize(EntityState initialState)
    {
        CurrentState = initialState;
        CurrentState.Enter();
    }

    public void ChangeState(EntityState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }   
}
