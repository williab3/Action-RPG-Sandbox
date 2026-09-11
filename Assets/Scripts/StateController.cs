using UnityEngine;

public class StateController 
{
    public CharacterState CurrentState { get; private set; }

    public void Initialize(CharacterState initialState)
    {
        CurrentState = initialState;
        CurrentState.Enter();
    }

    public void ChangeState(CharacterState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }   
}
