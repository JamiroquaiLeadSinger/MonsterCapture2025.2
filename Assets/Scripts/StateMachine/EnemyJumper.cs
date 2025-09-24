using UnityEngine;

public class EnemyJumper : MonoBehaviour
{
    public StateMachine stateMachine = new StateMachine();

    public ChasingState chasingState;
    public PatrolState patrolState;

    GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<PlayerMovement>().gameObject;
        chasingState = new ChasingState(player, gameObject, GetComponent<Rigidbody>());
        patrolState = new PatrolState(player, gameObject, GetComponent<Rigidbody>());

        stateMachine.ChangeState(patrolState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.UpdateSM();
    }

    public bool IsFacingPlayer()
    {
        Vector3 directionToPlayer = player.transform.position - transform.forward;
        directionToPlayer.Normalize();

        float dotResult = Vector3.Dot(directionToPlayer, transform.forward);
        return dotResult >= 0.8f;
    }
}
