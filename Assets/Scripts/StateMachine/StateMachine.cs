using UnityEngine;

public class StateMachine
{
    iState currentState;

    public void ChangeState(iState newState)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter();
    }

    public void UpdateSM()
    {
        if (currentState != null)
        {
            currentState.Execute();
        }
    }
}
