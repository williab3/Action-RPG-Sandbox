using UnityEngine;

public class StateController 
{
    public ChracterState CurrentState { get; private set; }

    public void Initialize(ChracterState initialState)
    {
        CurrentState = initialState;
        CurrentState.Enter();
    }

    public void ChangeState(ChracterState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }   
}
