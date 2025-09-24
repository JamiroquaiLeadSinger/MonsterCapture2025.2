using UnityEngine;

public class PatrolState : iState
{
    EnemyJumper owner;

    GameObject player;
    GameObject ai;
    Rigidbody rb;

    // Constructor
    public PatrolState(GameObject player, GameObject ai, Rigidbody rb)
    {
        this.player = player;
        this.ai = ai;
        owner = ai.GetComponent<EnemyJumper>();
        this.rb = rb;
    }

    public void Enter()
    {
        Debug.Log("Patrol state enter");
    }

    

    public void Execute()
    {
        ai.transform.rotation *= Quaternion.Euler(0f, 50 * Time.deltaTime, 0f);

        if(owner.IsFacingPlayer())
        {
            // Transition into chase state
            owner.stateMachine.ChangeState(owner.chasingState);
        }
    }

    public void Exit()
    {
        Debug.Log("Patrol state exit");
    }
}
